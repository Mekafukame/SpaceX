using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSwitch : MonoBehaviour
{
    private ToggleGroup toggles; 
    public GameObject ActualMap;
    public GameObject ActualMapName;
    public LocalGameSettings GameSettings;
    private string MapName;
    private void Start()
    {
        //load toggle group
        toggles = GetComponent<ToggleGroup>();
        //check wich toggle is active and set actual map
        foreach (Toggle toggle in toggles.ActiveToggles())
        {
            MapName = toggle.name;
            ActualMap.GetComponent<Image>().sprite = toggle.transform.Find("Map").GetComponent<Image>().sprite;
            ActualMap.transform.rotation = toggle.transform.Find("Map").rotation;
            ActualMapName.GetComponent<TMPro.TMP_Text>().text = toggle.transform.Find("Label").GetComponent<TMPro.TMP_Text>().text;
        }
        //save selcected map
        GameSettings.Map = MapName;
    }
    public void ChangeMap()
    {
        //check wich toggle is active and set actual map
        foreach (Toggle toggle in toggles.ActiveToggles())
        {
            MapName = toggle.name;            
            ActualMap.GetComponent<Image>().sprite = toggle.transform.Find("Map").GetComponent<Image>().sprite;
            ActualMap.transform.rotation = toggle.transform.Find("Map").rotation;
            ActualMapName.GetComponent<TMPro.TMP_Text>().text = toggle.transform.Find("Label").GetComponent<TMPro.TMP_Text>().text;
        }
        Debug.Log(MapName);
        //save selcected map
        GameSettings.Map = MapName;
    }
}
