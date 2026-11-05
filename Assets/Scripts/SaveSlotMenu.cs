
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SaveSlotMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject saveSelectionPanel;

    public GameObject deleteConfirmationPanel;
    public TMP_Text deleteConfirmationText;

    public Button slot1Button;
    public Button slot2Button;
    public Button slot3Button;

    private int slotToDelete = -1;

    void Start()
    {
        saveSelectionPanel.SetActive(false);
        deleteConfirmationPanel.SetActive(false);
        UpdateSlotButtons();
    }

    public void OpenSaveSelection()
    {
        mainMenuPanel.SetActive(false);
        saveSelectionPanel.SetActive(true);

        UpdateSlotButtons();
    }

    public void CloseSaveSelection()
    {
        saveSelectionPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    void UpdateSlotButtons()
    {
        UpdateSlotButton(slot1Button, 1);
        UpdateSlotButton(slot2Button, 2);
        UpdateSlotButton(slot3Button, 3);
    }

    void UpdateSlotButton(Button button, int slot)
    {
        TMP_Text buttonText =
            button.GetComponentInChildren<TMP_Text>();

        if (SaveManager.Instance.SlotExists(slot))
        {
            buttonText.text = "Slot " + slot + "\nContinue";
        }
        else
        {
            buttonText.text = "Slot " + slot + "\nNew Game";
        }
    }

    public void SelectSlot1()
    {
        StartGame(1);
    }

    public void SelectSlot2()
    {
        StartGame(2);
    }

    public void SelectSlot3()
    {
        StartGame(3);
    }

    public void DeleteSlot1()
    {
        ConfirmDelete(1);
    }

    public void DeleteSlot2()
    {
        ConfirmDelete(2);
    }

    public void DeleteSlot3()
    {
        ConfirmDelete(3);
    }

    void ConfirmDelete(int slot)
    {
        slotToDelete = slot;

        deleteConfirmationPanel.SetActive(true);

        deleteConfirmationText.text =
            "Delete Save Slot " + slot + "?\nThis cannot be undone.";
    }

    public void ConfirmDeleteYes()
    {
        if (slotToDelete >= 1 && slotToDelete <= 3)
        {
            SaveManager.Instance.DeleteSave(slotToDelete);
            UpdateSlotButtons();
        }

        slotToDelete = -1;
        deleteConfirmationPanel.SetActive(false);
    }

    public void ConfirmDeleteNo()
    {
        slotToDelete = -1;
        deleteConfirmationPanel.SetActive(false);
    }

    void StartGame(int slot)
    {
        SaveManager.Instance.SelectSlot(slot);
        SceneManager.LoadScene("MiningArea");
    }
}
