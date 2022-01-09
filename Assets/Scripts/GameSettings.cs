using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{    
    static public int GameType;    
    static public int GameMode, GameScore, NumOfPlayers;
    static public string Map;    
    public string MapName;    
    public int GameTypeVar;
    public GameObject[] Maps;
    public GameObject Players, PointCrown;
    public GameObject Checkpoints;
    static public Color[] PlayerColors = new Color[4] {new Color(255f,0f,0f), new Color(0f, 0f, 255f), new Color(0f, 255f, 0f), new Color(255f, 255f, 0f) };
    public int[] cooldowns = { 0, 0, 0, 0, 0 };

    //sets setting for game Players, gamemode, etc.
    public void SetSettings(int TypeOfGame)
    {        
        var script = transform.parent.gameObject.GetComponent<LocalGameSettings>();
        GameType = TypeOfGame;
        GameMode = script.GameModeID;
        GameScore = script.Scores[script.ScoreID];
        NumOfPlayers = transform.parent.Find("NumberOfPlayers").GetComponent<TMPro.TMP_Dropdown>().value + 1;
        Map = script.Map;       

    }   
    void changeMapName(string oldName, string newName)
    {
        MapName = newName;
        Debug.Log(MapName);
    }
    void changeGameType(int oldVar, int newVar)
    {
        GameTypeVar = newVar;
        Debug.Log(GameTypeVar);
    }
    public void SetColor(Color color, string playerName)
    {
        switch (playerName)
        {
            case "Player1Config":
                PlayerColors[0] = color;
                break;
            case "Player2Config":
                PlayerColors[1] = color;
                break;
            case "Player3Config":
                PlayerColors[2] = color;
                break;                
            case "Player4Config":
                PlayerColors[3] = color;
                break;
        }
    }
    public Color GetColor(string PlayerName)
    {
        Color color = new Color(0,0,0);
        switch (PlayerName)
        {
            case "Player1":
                color = PlayerColors[0];               
                break;
            case "Player2":
                color = PlayerColors[1];
                break;
            case "Player3":
                color = PlayerColors[2];
                break;
            case "Player4":
                color = PlayerColors[3];
                break;
        }
        return color;
    }
    //load settings for game
    public void LoadSettings()
    {
        if (GameTypeVar == 0) GameTypeVar = GameType;
        if (GameTypeVar == 0)
        {
            
            var ScoreBoard = Players.transform.Find("ScoreBoard").gameObject.transform.Find("Panel").gameObject;
            ScoreBoard.GetComponent<RectTransform>().sizeDelta = new Vector2(125, 20 + 15f * NumOfPlayers);
            //activate Map
            foreach (GameObject obj in Maps)
            {                
                if (obj.name == Map)
                {
                    obj.SetActive(true);
                }
            }
            Checkpoints = GameObject.Find("RaceCheckpoints");
            //activate players
            for (int i = 1; i <= NumOfPlayers; i++)
            {                
                Players.transform.Find("Player" + i).gameObject.SetActive(true);
                ScoreBoard.transform.Find("Label" + i).gameObject.SetActive(true);
            }
            //SplitScreen           
            switch (NumOfPlayers)
            {
                case 1:
                    for (int i = 1; i <= NumOfPlayers; i++)
                    {
                        var playerCam = Players.transform.Find("Player" + i).gameObject.transform.Find("PlayerObject").gameObject.transform.Find("PlayerCam").gameObject.GetComponent<Camera>();
                        playerCam.rect = new Rect(0, 0, 1, 1);


                    }
                    break;
                case 2:
                    for (int i = 1; i <= NumOfPlayers; i++)
                    {
                        var playerCam = Players.transform.Find("Player" + i).gameObject.transform.Find("PlayerObject").gameObject.transform.Find("PlayerCam").gameObject.GetComponent<Camera>();

                        switch (i)
                        {
                            case 1:
                                playerCam.rect = new Rect(0, 0, 0.5f, 1);
                                break;
                            case 2:
                                playerCam.rect = new Rect(0.5f, 0, 0.5f, 1);
                                break;
                        }
                    }
                    break;
                case 3:
                    for (int i = 1; i <= NumOfPlayers; i++)
                    {
                        var playerCam = Players.transform.Find("Player" + i).gameObject.transform.Find("PlayerObject").gameObject.transform.Find("PlayerCam").gameObject.GetComponent<Camera>();

                        switch (i)
                        {
                            case 1:
                                playerCam.rect = new Rect(0, 0, 1 / 3f, 1);
                                break;
                            case 2:
                                playerCam.rect = new Rect(1 / 3f, 0, 1 / 3f, 1);
                                break;
                            case 3:
                                playerCam.rect = new Rect(2 / 3f, 0, 1 / 3f, 1);
                                break;
                        }
                    }
                    break;
                case 4:
                    for (int i = 1; i <= NumOfPlayers; i++)
                    {
                        var playerCam = Players.transform.Find("Player" + i).gameObject.transform.Find("PlayerObject").gameObject.transform.Find("PlayerCam").gameObject.GetComponent<Camera>();

                        switch (i)
                        {
                            case 1:
                                playerCam.rect = new Rect(0, 0, 0.5f, 0.5f);
                                break;
                            case 2:
                                playerCam.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
                                break;
                            case 3:
                                playerCam.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
                                break;
                            case 4:
                                playerCam.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                                break;
                        }
                    }
                    break;
            }
            if (GameMode == 0)
            {
                Checkpoints.SetActive(false);
            }
            else if (GameMode == 1)
            {

            }
            else if (GameMode == 2)
            {
                PointCrown.SetActive(true);
                Checkpoints.SetActive(false);
            }
            else if (GameMode == 3)
            {
                ScoreBoard.transform.parent.GetComponent<ScoreBoard>().playersAlive = NumOfPlayers;
                Checkpoints.SetActive(false);
            }

        }
        else if (GameTypeVar == 1)
        {            
            var ScoreBoard = Players.transform.Find("ScoreBoard").gameObject.transform.Find("Panel").gameObject;
            ScoreBoard.GetComponent<RectTransform>().sizeDelta = new Vector2(125, 20 + 15f * NumOfPlayers);
            //activate Map
            foreach (GameObject obj in Maps)
            {
                Debug.Log(MapName + "     " + obj.name);
                if (obj.name == MapName)
                {
                    obj.SetActive(true);
                }
            }
            Checkpoints = GameObject.Find("RaceCheckpoints");            
            if (GameMode == 0)
            {
                Checkpoints.SetActive(false);
            }
            else if (GameMode == 1)
            {

            }
            else if (GameMode == 2)
            {
                PointCrown.SetActive(true);
                Checkpoints.SetActive(false);
            }
            else if (GameMode == 3)
            {
                ScoreBoard.transform.parent.GetComponent<ScoreBoard>().playersAlive = NumOfPlayers;
                Checkpoints.SetActive(false);
            }
        }
    }
    
    public int GetMaxScore()
    {
        return GameScore;
    }
    public int GetGameMode()
    {
        return GameMode;
    }
    public int GetNumOfPlayers()
    {
        return NumOfPlayers;
    }
    public int GetGameType()
    {
        return GameType;
    }

}
