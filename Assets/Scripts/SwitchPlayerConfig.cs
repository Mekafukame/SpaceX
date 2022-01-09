using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayerConfig : MonoBehaviour
{
    public GameObject[] PlayersConfigs = new GameObject[4];
    void Start()
    {
        PlayersConfigs[gameObject.GetComponent<TMPro.TMP_Dropdown>().value].SetActive(true);
    }

    public void switchConfig()
    {
        foreach(GameObject obj in PlayersConfigs)
        {
            obj.SetActive(false);
        }
        PlayersConfigs[gameObject.GetComponent<TMPro.TMP_Dropdown>().value].SetActive(true);
    }
}
