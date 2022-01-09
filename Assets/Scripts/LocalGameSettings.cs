using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalGameSettings : MonoBehaviour
{
    public GameObject[] GameModesScores = new GameObject[4]; //list of dropdown lists for each gamemode
    public TMPro.TMP_Dropdown GameModeDropdown; //gamemode dropdown
    public GameObject ScoresObj;    //object with all dropdown lists for each score
    public string[] GameModes = new string[4]; //names of gamemodes
    public int[] Scores = new int[5]; //values of score for actual gamemode
    public int GameModeID = 0, ScoreID = 0; //id of gamemode and score
    public string Map = "BlueMoon"; // selected map
    void Start()
    {                                                               
        //get gamemodes names to the list
        for (int j = 0; j < 4; j++)
        {
            GameModes[j] = GameModeDropdown.options[j].text;
        }
        //selected gamemode
        GameModeDropdown.value = GameModeID;
        //default selected score for every score list
        foreach(Transform child in ScoresObj.transform)
        {
            child.GetComponent<TMPro.TMP_Dropdown>().value = ScoreID;
        }
        //activates actual gamemode scorelist
        GameModesScores[GameModeID].SetActive(true);
        for (int j = 0; j < 5; j++)
        {
            Scores[j] = int.Parse(GameModesScores[GameModeID].GetComponent<TMPro.TMP_Dropdown>().options[j].text);
        }

    }
       
    public void SetGameMode(int GameMode)
    {
        GameModesScores[GameModeID].SetActive(false);
        GameModeID = GameMode;
        GameModesScores[GameModeID].SetActive(true);
        for (int j = 0; j < 5; j++)
        {
            Scores[j] = int.Parse(GameModesScores[GameModeID].GetComponent<TMPro.TMP_Dropdown>().options[j].text);
        }

    }
    public void SetPoints(int Score)
    {
        ScoreID = Score;
    }
}
