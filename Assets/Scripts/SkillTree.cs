using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillTree : MonoBehaviour
{
    public PlayerMining playerMining;
    public Projectile projectile;
    public Inventory inventory;
    public MiningRunManager runManager;

    public Button oreValueButton;

    public Button fireRateButton;
    public Button rangeButton;
    public Button miningPowerButton;

    public Button fireRateIIButton;
    public Button rangeIIButton;
    public Button miningPowerIIButton;
    public Button runDurationButton;
    private int lastSavedBars;
    private int lastSavedUpgradeLevels;

    private int oreValueLevel = 0;

    private int fireRateLevel = 0;
    private int rangeLevel = 0;
    private int miningPowerLevel = 0;

    private int fireRateIILevel = 0;
    private int rangeIILevel = 0;
    private int miningPowerIILevel = 0;
    private int runDurationLevel = 0;
   

    private int[] oreValueCosts = { 50, 150, 300, 500 };

    private int[] basicCosts = { 10, 20, 30, 40, 50 };
    private int[] powerCosts = { 15, 30, 45, 60, 75 };
    private int[] advancedCosts = { 150, 250, 400 };
    private int[] advancedPowerCosts = { 200, 350, 500 };
    private int[] durationCosts = { 5, 10, 20, 35, 55, 80 };

    void Update()
    {
        UpdateButton(fireRateButton, fireRateLevel, basicCosts, true);
        UpdateButton(rangeButton, rangeLevel, basicCosts, true);
        UpdateButton(miningPowerButton, miningPowerLevel, powerCosts, true);

        UpdateButton(oreValueButton, oreValueLevel, oreValueCosts, true);

        UpdateButton(fireRateIIButton, fireRateIILevel, advancedCosts,
            fireRateLevel == 5);
        UpdateButton(rangeIIButton, rangeIILevel, advancedCosts,
            rangeLevel == 5);
        UpdateButton(miningPowerIIButton, miningPowerIILevel,
            advancedPowerCosts, miningPowerLevel == 5);

        UpdateButton(runDurationButton, runDurationLevel, durationCosts, true);

        UpdateButtonText(fireRateButton, "Fire Rate I",
            fireRateLevel, basicCosts, true);

        UpdateButtonText(rangeButton, "Range I",
            rangeLevel, basicCosts, true);

        UpdateButtonText(miningPowerButton, "Mining Power I",
            miningPowerLevel, powerCosts, true);

        UpdateButtonText(oreValueButton, "Ore Value",
            oreValueLevel, oreValueCosts, true);

        UpdateButtonText(fireRateIIButton, "Fire Rate II",
            fireRateIILevel, advancedCosts, fireRateLevel == 5);

        UpdateButtonText(rangeIIButton, "Range II",
            rangeIILevel, advancedCosts, rangeLevel == 5);

        UpdateButtonText(miningPowerIIButton, "Mining Power II",
            miningPowerIILevel, advancedPowerCosts, miningPowerLevel == 5);

        UpdateButtonText(runDurationButton, "Run Duration",
            runDurationLevel, durationCosts, true);
    }

    void LateUpdate()
    {
        if (SaveManager.Instance == null)
            return;

        if (inventory == null)
            return;

        if (inventory.bars != lastSavedBars ||
            GetTotalUpgradeLevels() != lastSavedUpgradeLevels)
        {
            SaveManager.Instance.SaveGame();

            lastSavedBars = inventory.bars;
            lastSavedUpgradeLevels = GetTotalUpgradeLevels();
        }
    }

    void UpdateButton(Button button, int level, int[] costs, bool unlocked)
    {
        if (button == null)
            return;

        Outline outline = button.GetComponent<Outline>();

        if (outline == null)
            return;

        if (level >= costs.Length)
        {
            outline.effectColor = Color.yellow;
        }
        else if (!unlocked)
        {
            outline.effectColor = Color.gray;
        }
        else if (inventory.bars >= costs[level])
        {
            outline.effectColor = Color.green;
        }
        else
        {
            outline.effectColor = Color.red;
        }
    }

    void UpdateButtonText(Button button, string upgradeName,
    int level, int[] costs, bool unlocked)
    {
        if (button == null)
            return;

        TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>(true);

        if (buttonText == null)
            return;

        if (level >= costs.Length)
        {
            buttonText.text = upgradeName + "\nMAXED";
        }
        else if (!unlocked)
        {
            buttonText.text = upgradeName + "\nLOCKED";
        }
        else
        {
            buttonText.text = upgradeName + " (" +
                level + "/" + costs.Length + ")\n" +
                costs[level] + " Bars";
        }
    }

    public void FireRateUpgrade()
    {
        if (fireRateLevel >= 5)
            return;

        if (inventory.SpendBars(basicCosts[fireRateLevel]))
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayUpgrade();
            }
            playerMining.fireRate =
                Mathf.Max(0.1f, playerMining.fireRate - 0.05f);

            fireRateLevel++;
        }
    }

    public void RangeUpgrade()
    {
        if (rangeLevel >= 5)
            return;

        if (inventory.SpendBars(basicCosts[rangeLevel]))
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayUpgrade();
            }
            projectile.lifetime += 0.1f;
            rangeLevel++;
        }
    }

    public void MiningPowerUpgrade()
    {
        if (miningPowerLevel >= 5)
            return;

        if (inventory.SpendBars(powerCosts[miningPowerLevel]))
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayUpgrade();
            }
            playerMining.miningPower += 1;
            miningPowerLevel++;
        }
    }

    public void FireRateIIUpgrade()
    {
        if (fireRateLevel < 5 || fireRateIILevel >= 3)
            return;

        if (inventory.SpendBars(advancedCosts[fireRateIILevel]))
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayUpgrade();
            }
            playerMining.fireRate =
                Mathf.Max(0.1f, playerMining.fireRate - 0.1f);

            fireRateIILevel++;
        }
    }

    public void RangeIIUpgrade()
    {
        if (rangeLevel < 5 || rangeIILevel >= 3)
            return;

        if (inventory.SpendBars(advancedCosts[rangeIILevel]))
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayUpgrade();
            }
            projectile.lifetime += 0.5f;
            rangeIILevel++;
        }
    }

    public void MiningPowerIIUpgrade()
    {
        if (miningPowerLevel < 5 || miningPowerIILevel >= 3)
            return;

        if (inventory.SpendBars(advancedPowerCosts[miningPowerIILevel]))
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayUpgrade();
            }
            playerMining.miningPower += 3;
            miningPowerIILevel++;
        }
    }

    public void RunDurationUpgrade()
    {
        if (runDurationLevel >= 6)
            return;

        if (inventory.SpendBars(durationCosts[runDurationLevel]))
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayUpgrade();
            }
            runManager.runTime += 5f;
            runDurationLevel++;
        }
    }

    public void OreValueUpgrade()
    {
        if (oreValueLevel >= 4)
            return;

        if (inventory.SpendBars(oreValueCosts[oreValueLevel]))
        {
            if (AudioManager.Instance != null)
            {
                AudioManager.Instance.PlayUpgrade();
            }
            oreValueLevel++;
            inventory.oreValue = 1 + oreValueLevel;
        }
    }

    int GetTotalUpgradeLevels()
    {
        return fireRateLevel +
               rangeLevel +
               miningPowerLevel +
               fireRateIILevel +
               rangeIILevel +
               miningPowerIILevel +
               runDurationLevel +
               oreValueLevel;
    }

    public void SaveUpgradeLevels(SaveData data)
    {
        data.fireRateLevel = fireRateLevel;
        data.rangeLevel = rangeLevel;
        data.miningPowerLevel = miningPowerLevel;

        data.fireRateIILevel = fireRateIILevel;
        data.rangeIILevel = rangeIILevel;
        data.miningPowerIILevel = miningPowerIILevel;

        data.runDurationLevel = runDurationLevel;
        data.oreValueLevel = oreValueLevel;
    }

    public void LoadUpgradeLevels(SaveData data)
    {
        fireRateLevel = Mathf.Clamp(data.fireRateLevel, 0, 5);
        rangeLevel = Mathf.Clamp(data.rangeLevel, 0, 5);
        miningPowerLevel = Mathf.Clamp(data.miningPowerLevel, 0, 5);

        fireRateIILevel = Mathf.Clamp(data.fireRateIILevel, 0, 3);
        rangeIILevel = Mathf.Clamp(data.rangeIILevel, 0, 3);
        miningPowerIILevel = Mathf.Clamp(data.miningPowerIILevel, 0, 3);

        runDurationLevel = Mathf.Clamp(data.runDurationLevel, 0, 6);
        oreValueLevel = Mathf.Clamp(data.oreValueLevel, 0, 4);
        inventory.oreValue = 1 + oreValueLevel;

        // Rebuild player stats from the saved levels.
        playerMining.fireRate = Mathf.Max(0.1f,
            0.6f - fireRateLevel * 0.05f
                 - fireRateIILevel * 0.1f);

        playerMining.miningPower =
            1 + miningPowerLevel + miningPowerIILevel * 3;

        projectile.lifetime =
            0.1f + rangeLevel * 0.1f
                 + rangeIILevel * 0.5f;

        runManager.runTime = 30f + runDurationLevel * 5f;
    }

    public void ResetAutosaveTracking()
    {
        lastSavedBars = inventory.bars;
        lastSavedUpgradeLevels = GetTotalUpgradeLevels();
    }
}