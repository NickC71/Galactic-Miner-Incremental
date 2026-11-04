using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public int currentSlot = 1;

    public Inventory inventory;
    public SkillTree skillTree;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private string GetSavePath(int slot)
    {
        return Path.Combine(
            Application.persistentDataPath,
            "save" + slot + ".json");
    }

    public void SelectSlot(int slot)
    {
        if (slot < 1 || slot > 3)
            return;

        currentSlot = slot;
    }

    public bool SlotExists(int slot)
    {
        return File.Exists(GetSavePath(slot));
    }

    public void SaveGame()
    {
        if (inventory == null || skillTree == null)
        {
            Debug.LogWarning("SaveManager references are missing!");
            return;
        }

        SaveData data = new SaveData();

        data.bars = inventory.bars;
        skillTree.SaveUpgradeLevels(data);

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(GetSavePath(currentSlot), json);

        Debug.Log("Saved game to slot " + currentSlot);
    }

    public void LoadGame()
    {
        if (inventory == null || skillTree == null)
        {
            Debug.LogWarning("SaveManager references are missing!");
            return;
        }

        SaveData data = new SaveData();

        string path = GetSavePath(currentSlot);

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(json);
        }

        inventory.SetBars(data.bars);
        skillTree.LoadUpgradeLevels(data);

        Debug.Log("Loaded game from slot " + currentSlot);
    }

    public void DeleteSave(int slot)
    {
        string path = GetSavePath(slot);

        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("Deleted save slot " + slot);
        }
    }
}