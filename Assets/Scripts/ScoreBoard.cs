using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    public TMPro.TMP_Text[] ScoreTextList = new TMPro.TMP_Text[4];
    public int[] ScoreList = new int[4] { 0, 0, 0, 0 }, CheckpointList = new int[4] {0,0,0,0};
    private float[] scoreCD = { 0, 0, 0, 0 };
    public int MaxScore, NumOfPlayers, playersAlive;
    public TMPro.TMP_Text Winner;
    public GameObject[] Players = new GameObject[4];
    private GameObject Menu;
    private bool GameOver = false;
    private void Start()
    {
        MaxScore = GameObject.Find("Players").GetComponent<GameSettings>().GetMaxScore();
        NumOfPlayers = GameObject.Find("Players").GetComponent<GameSettings>().GetNumOfPlayers();
        Menu = GameObject.Find("InGameMenu").gameObject.transform.Find("Canvas").gameObject;
        Menu.SetActive(false);
        
    }
    //Add score to player that got kill
    private void Update()
    {
        //Open Menu and pause game on Escape
        if (Input.GetButtonDown("Cancel") && GameOver == false)
        {

            if (Time.timeScale == 1)
            {

                Menu.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
            }
            else if (Time.timeScale == 0)
            {
                Menu.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
            }
        }
        if (Input.GetButtonDown("Tab"))
        {
            if(gameObject.GetComponent<Canvas>().enabled == false)
                gameObject.GetComponent<Canvas>().enabled = true;
            else
                gameObject.GetComponent<Canvas>().enabled = false;
        }
        if (playersAlive == 1)
        {            
            var RoundWinner = GameObject.FindGameObjectWithTag("Ship");
            if (RoundWinner)
            {                
                AddScore(RoundWinner.transform.parent.name);
                Destroy(RoundWinner);
                playersAlive += NumOfPlayers;
                Invoke("spawnPlayers",0f);
                
            }
        }
    }
    public void AddScore(string PlayerTag)
    {
        switch (PlayerTag)
        {
            case "Player1":
                if (scoreCD[0] == 0)
                {
                    scoreCD[0] = 0.1f;
                    StartCoroutine(resetCD(0));
                    ScoreList[0]++;
                    ScoreTextList[0].text = ScoreList[0].ToString();
                    
                }
                break;
            case "Player2":
                if (scoreCD[1] == 0)
                {
                    scoreCD[1] = 0.1f;
                    StartCoroutine(resetCD(1));
                    ScoreList[1]++;
                    ScoreTextList[1].text = ScoreList[1].ToString();
                }
                break;
            case "Player3":
                if (scoreCD[2] == 0)
                {
                    scoreCD[2] = 0.1f;
                    StartCoroutine(resetCD(2));
                    ScoreList[2]++;
                    ScoreTextList[2].text = ScoreList[2].ToString();
                }
                break;
            case "Player4":
                if (scoreCD[3] == 0)
                {
                    scoreCD[3] = 0.1f;
                    StartCoroutine(resetCD(3));
                    ScoreList[3]++;
                    ScoreTextList[3].text = ScoreList[3].ToString();
                }
                break;
        }
        for(int i = 0; i< NumOfPlayers; i++)
        {
            if(ScoreList[i] == MaxScore)
            {
                GameOver = true;
                Winner.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Canvas>().enabled = true;
                Cursor.visible = true;
                Winner.text = Players[i].name;
                Time.timeScale = 0;
            }
        }
    }
    public void NextCheckpoint(int Checkpoint, string PlayerTag)
    {        
        switch (PlayerTag)
        {
            case "Player1":
                if (CheckpointList[0] == Checkpoint-1)
                {                                       
                    CheckpointList[0]++;
                    ScoreTextList[0].text = ScoreList[0].ToString() + " (" + CheckpointList[0]+")";

                }
                break;
            case "Player2":
                if (CheckpointList[1] == Checkpoint - 1)
                {
                    Debug.Log(CheckpointList[1]);
                    CheckpointList[1]++;
                    ScoreTextList[1].text = ScoreList[1].ToString() + " (" + CheckpointList[1] + ")";

                }
                break;
            case "Player3":
                if (CheckpointList[2] == Checkpoint - 1)
                {
                    Debug.Log(CheckpointList[2]);
                    CheckpointList[2]++;
                    ScoreTextList[2].text = ScoreList[2].ToString() + " (" + CheckpointList[2] + ")";

                }
                break;
            case "Player4":
                if (CheckpointList[3] == Checkpoint - 1)
                {
                    Debug.Log(CheckpointList[3]);
                    CheckpointList[3]++;
                    ScoreTextList[3].text = ScoreList[3].ToString() + " (" + CheckpointList[3] + ")";

                }
                break;
        }
        for (int i = 0; i < NumOfPlayers; i++)
        {
            if (CheckpointList[i] == 15)
            {
                CheckpointList[i] = 0;
                ScoreList[i]++;
                ScoreTextList[i].text = ScoreList[i].ToString() + " (" + CheckpointList[i] + ")";
            }
            if (ScoreList[i] == MaxScore)
            {
                GameOver = true;
                Winner.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Canvas>().enabled = true;
                Cursor.visible = true;
                Winner.text = Players[i].name;
                Time.timeScale = 0;
            }
        }
    }
    public void spawnPlayers()
    {               
        foreach (Transform child in gameObject.transform.parent.transform)
        {
            if (child.tag == "Player" && child.gameObject.activeSelf)
            {
                Debug.Log("spawnPlayers start");
                child.GetComponent<Respawn>().StartCoroutine(child.GetComponent<Respawn>().Spawn(3f));
            }
        }
    }
    public IEnumerator resetCD(int id)
    {
        yield return new WaitForSeconds(0.1f);
        scoreCD[id] = 0;
    }
}
