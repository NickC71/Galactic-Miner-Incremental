using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    public PlayerMining playerMining;
    public Projectile projectile;
    public Inventory inventory;

    public Button fireRateButton;
    public Button rangeButton;
    public Button miningPowerButton;
    private Outline fireRateOutline;
    private Outline rangeOutline;
    private Outline miningPowerOutline;

    void Start()
    {
        fireRateOutline = fireRateButton.GetComponent<Outline>();
        rangeOutline = rangeButton.GetComponent<Outline>();
        miningPowerOutline = miningPowerButton.GetComponent<Outline>();
        UpdateFireRateColor();
        UpdateRangeColor();
        UpdateMiningPowerColor();
    }

    void Update()
    {
        UpdateFireRateColor();
        UpdateRangeColor();
        UpdateMiningPowerColor();
    }
    public void FireRateUpgrade()
    {
        if(inventory.SpendBars(10))
        {
            playerMining.fireRate -= 0.05f;
        }
    }

    public void RangeUpgrade()
    {
        if (inventory.SpendBars(10))
        {
            projectile.lifetime += 0.1f;
        }
    }

    public void MiningPowerUpgrade()
    {
        if (inventory.SpendBars(15))
        {
            playerMining.miningPower += 1;
        }
    }

    void UpdateFireRateColor()
    {
        if(inventory.bars >= 10)
        {
            fireRateOutline.effectColor = Color.green;
        }
        else
        {
            fireRateOutline.effectColor = Color.red;
        }
    }

    void UpdateRangeColor()
    {
        if (inventory.bars >= 10)
        {
            rangeOutline.effectColor = Color.green;
        }
        else
        {
            rangeOutline.effectColor = Color.red;
        }
    }

    void UpdateMiningPowerColor()
    {
        if (inventory.bars >= 15)
        {
            miningPowerOutline.effectColor = Color.green;
        }
        else
        {
            miningPowerOutline.effectColor = Color.red;
        }
    }
}
