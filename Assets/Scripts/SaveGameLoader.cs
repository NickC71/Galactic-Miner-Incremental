using UnityEngine;

public class SaveGameLoader : MonoBehaviour
{
    public Inventory inventory;
    public SkillTree skillTree;

    void Start()
    {
        SaveManager.Instance.inventory = inventory;
        SaveManager.Instance.skillTree = skillTree;

        SaveManager.Instance.LoadGame();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SaveManager.Instance.SaveGame();
        }
    }
}