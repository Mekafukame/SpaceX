using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCrown : MonoBehaviour
{
    private GameObject[] SpawnPoints;
    private GameObject player, scoreBoard;
    private float cooldown = 0, respawnTime;
    void Start()
    {
        SpawnPoints = GameObject.FindGameObjectsWithTag("AmmoSpawns");
        scoreBoard = GameObject.Find("ScoreBoard");
        int pos = Random.Range(0, SpawnPoints.Length);
        gameObject.transform.position = SpawnPoints[pos].transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent.tag == "Player")
        {
            gameObject.transform.parent = collision.transform.parent.transform.Find("PlayerObject");
            gameObject.transform.position = transform.parent.position + new Vector3(0, 50, 0);
            player = collision.gameObject;
        }
    }
    private void Update()
    {
        //check if player exists
        if (player)
        {
            if (cooldown <= Time.time)
            {
                cooldown = Time.time + 1;
                scoreBoard.GetComponent<ScoreBoard>().AddScore(player.transform.parent.name);
            }
        }   
        //on player destroy change position
        else if(!player && transform.parent)
        {
            transform.position = transform.parent.transform.position;
            respawnTime = Time.time + 30;
            transform.parent = null;
        }
        //respawn if no colect in 30 seconds
        else if(respawnTime != 0 && respawnTime <= Time.time)
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        int pos = Random.Range(0, SpawnPoints.Length);
        respawnTime = 0;
        gameObject.transform.position = SpawnPoints[pos].transform.position;
        
    }
}
