
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MiningRunManager : MonoBehaviour
{
    public GameObject skillTreeScreen;
    public GameObject runSummaryPanel;
    public GameObject controls;
    public PlayerMining playerMining;
    public PlayerMovement playerMovement;
    public TMP_Text timerText;
    public TMP_Text barsEarnedText;
    public Button startRunButton;
    public Button continueButton;
    public Inventory inventory;
    public Transform player;
    public Vector3 startingPosition = Vector3.zero;
    public float runTime = 60f;

    private Rigidbody2D playerRigidbody;
    private float timeRemaining;
    private int startingBars;
    private bool runActive = false;

    void Start()
    {
        skillTreeScreen.SetActive(true);
        runSummaryPanel.SetActive(false);
        controls.SetActive(false);
        playerMining.enabled = false;
        playerMovement.enabled = false;

        playerRigidbody = player.GetComponent<Rigidbody2D>();

        startRunButton.onClick.AddListener(StartRun);
        continueButton.onClick.AddListener(ContinueToSkillTree);

        UpdateTimerText();
    }

    void Update()
    {
        if (!runActive)
            return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            EndRun();
        }

        UpdateTimerText();
    }

    void StartRun()
    {
        timeRemaining = runTime;
        runActive = true;

        player.transform.position = startingPosition;

        if (playerRigidbody != null)
        {
            playerRigidbody.linearVelocity = Vector2.zero;
            playerRigidbody.angularVelocity = 0f;
        }

        skillTreeScreen.SetActive(false);
        runSummaryPanel.SetActive(false);
        controls.SetActive(true);
        playerMining.enabled = true;
        playerMovement.enabled = true;

        UpdateTimerText();
    }

    void EndRun()
    {
        runActive = false;

        int barsEarned = inventory.bars - startingBars;
        barsEarnedText.text = "Bars Earned: " + barsEarned;

        player.transform.position = startingPosition;

        if (playerRigidbody != null)
        {
            playerRigidbody.linearVelocity = Vector2.zero;
            playerRigidbody.angularVelocity = 0f;
        }

        playerMining.enabled = false;
        playerMovement.enabled = false;
        controls.SetActive(false);

        skillTreeScreen.SetActive(false);
        runSummaryPanel.SetActive(true);
    }

    void ContinueToSkillTree()
    {
        runSummaryPanel.SetActive(false);
        skillTreeScreen.SetActive(true);
    }

    void UpdateTimerText()
    {
        timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining);
    }
}
