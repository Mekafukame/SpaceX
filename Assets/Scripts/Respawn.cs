using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject player, CameraMountPoint;   
    private GameObject newPlayer, RaceSpawnPoint, Players;    
    private Animator respawnAnimation;
    public int cooldown = 10;    

    
    private void Start()
    {
        //set all spawnpoints
        Players = GameObject.Find("Players");        
        if(Players.GetComponent<GameSettings>().GameTypeVar == 1)
        {
            gameObject.transform.parent = Players.transform;
            gameObject.name = "Player" + (Players.transform.childCount-1).ToString();            
            
            Transform cameraTransform = Camera.main.gameObject.transform;  //Find main camera which is part of the scene instead of the prefab
            cameraTransform.parent = CameraMountPoint.transform;  //Make the camera a child of the mount point                ;
            cameraTransform.position = CameraMountPoint.transform.position;  //Set position/rotation same as the mount point     
            cameraTransform.position += new Vector3(0, 0, -100);
            
        }        
        spawnPoints = new GameObject[5];
        RaceSpawnPoint = GameObject.FindGameObjectWithTag("RaceSpawnPoint");
        respawnAnimation = transform.Find("RespawnAnimation").GetComponent<Animator>();
        int i = 0;
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Respawn"))
        {            
            spawnPoints[i] = obj;
            i++;
        }
        if (transform.parent.GetComponent<GameSettings>().GetGameMode() == 3)
        {
            cooldown = 1;

        }
        StartCoroutine(Spawn());
    }    
    //spawn object if spawn has no cooldown
    public IEnumerator Spawn(float delay = 0)
    {
        if(delay != 0)
        {
            yield return new WaitForSeconds(delay);
        }
        //spawn for race
        if (transform.parent.GetComponent<GameSettings>().GetGameMode() == 1)
        {
            int playerNum = int.Parse(gameObject.name.Remove(0, 6));
            var spawnPos = RaceSpawnPoint.transform.position + new Vector3(40 * playerNum - 100,0,0);
            gameObject.transform.position = spawnPos;
            gameObject.transform.Find("PlayerObject").position = transform.position;
            respawnAnimation.SetTrigger("Respawn");
            yield return new WaitForSeconds(0.8f);
            
            newPlayer = Instantiate(player, spawnPos, new Quaternion(0, 0, 0, 0), gameObject.transform);            
            newPlayer.layer = newPlayer.transform.parent.gameObject.layer;
            newPlayer.GetComponent<SpriteRenderer>().color = transform.parent.gameObject.GetComponent<GameSettings>().GetColor(gameObject.name);
            transform.Find("Canvas").gameObject.GetComponent<PlayerUI>().NewShip();
            
        }
        //spawn for the rest
        else
        {            
            int i = 0;
            bool end = false;
            var cooldowns = transform.parent.GetComponent<GameSettings>().cooldowns;
            i = Random.Range(0, 5);
            
            if (cooldowns[i] == 0)
            {                
                cooldowns[i] = cooldown;                
                gameObject.transform.position = spawnPoints[i].transform.position;
                gameObject.transform.Find("PlayerObject").position = transform.position;
                respawnAnimation.SetTrigger("Respawn");
                yield return new WaitForSeconds(0.8f);
                newPlayer = Instantiate(player, spawnPoints[i].transform.position, new Quaternion(0, 0, 0, 0), gameObject.transform);
                
                newPlayer.layer = newPlayer.transform.parent.gameObject.layer;
                newPlayer.GetComponent<SpriteRenderer>().color = transform.parent.gameObject.GetComponent<GameSettings>().GetColor(gameObject.name);
                transform.Find("Canvas").gameObject.GetComponent<PlayerUI>().NewShip();
                StartCoroutine(resetCooldown(i));
                end = true;                
            }
            if (end == false)
            {
                StartCoroutine(SpawnAgain());
            }            
        }
    }
    private IEnumerator SpawnAgain()
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(Spawn());
    }
    //reset spawner cooldown after cooldown time
    private IEnumerator resetCooldown(int i)
    {
        yield return new WaitForSeconds(cooldown);
        transform.parent.GetComponent<GameSettings>().cooldowns[i] = 0;
       

    }
}
