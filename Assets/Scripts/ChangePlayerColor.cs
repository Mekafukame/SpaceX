using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayerColor : MonoBehaviour
{
    public ToggleGroup toggles;
    public Color color;    
    public int playerID;
    public string colorName;
    private void Start()
    {                
        if (colorName == string.Empty)
        {
            foreach (Toggle toggle in toggles.ActiveToggles())
            {
                color = toggle.transform.Find("Background").GetComponent<Image>().color;
                colorName = toggle.name;
                transform.parent.GetComponent<GameSettings>().SetColor(color, gameObject.name);
            }
        }
        else
        {
            GameObject.Find(colorName).GetComponent<Toggle>().isOn = true;
        }
    }
    public void ChangeColor()
    {
        foreach (Toggle toggle in toggles.ActiveToggles())
        {
            color = toggle.transform.Find("Background").GetComponent<Image>().color;
            colorName = toggle.name;
        }
        transform.parent.GetComponent<GameSettings>().SetColor(color, gameObject.name);
    }
}
