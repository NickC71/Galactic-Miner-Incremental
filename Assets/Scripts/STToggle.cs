using UnityEngine;

public class SkillTreeToggle : MonoBehaviour
{
    public GameObject SkillTreePanel;

    void Start()
    {
        SkillTreePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SkillTreePanel.SetActive(!SkillTreePanel.activeSelf);
        }
    }
}
