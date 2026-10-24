using UnityEngine;

public class SkillTreeToggle : MonoBehaviour
{
    public GameObject SkillTreeScreen;

    void Start()
    {
        SkillTreeScreen.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SkillTreeScreen.SetActive(!SkillTreeScreen.activeSelf);
        }
    }
}
