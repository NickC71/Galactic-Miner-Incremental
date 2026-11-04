using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class Inventory : MonoBehaviour
{
    public int bars = 0;
    public TMP_Text barsText;

    void Start()
    {
        
        UpdateBarsText();
    }
    public void AddOreBars(int amount)
    {
        bars += amount;
        UpdateBarsText();
    }

    public bool SpendBars(int amount)
    {
        if (bars >= amount)
        {
            bars -= amount;
            UpdateBarsText();
            return true;
        }
        return false;
    }

    public void SetBars(int amount)
    {
        bars = Mathf.Max(0, amount);
        UpdateBarsText();
    }

    void UpdateBarsText()
    {
        barsText.text = "Bars: " + bars;
    }
}
