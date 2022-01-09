using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollider : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject parent;
    private PlayerMovement pm;
    private Respawn res;
    private ScoreBoard scoreBoard;
    public GameObject Explosion;
    public AudioClip explosionSound;
    bool isQuiting = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pm = GetComponent<PlayerMovement>();        
        parent = gameObject.transform.parent.gameObject;
        res = parent.GetComponent<Respawn>();
        scoreBoard = GameObject.Find("ScoreBoard").GetComponent<ScoreBoard>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //down side of ship colide with spawn - check speed
        if (collision.otherCollider.name == "DownSide" && collision.gameObject.tag == "SafePlace")
        {          
            if (collision.relativeVelocity.magnitude > pm.maxSpeed / 2)
            {
                Destroy(gameObject);                
            }
            else
            {
                
                if(gameObject.transform.eulerAngles.z > 15 && gameObject.transform.eulerAngles.z < 345)
                {
                    
                    Destroy(gameObject);
                }
                else gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        //rest of ship colide with spawn - destroy
        else if (collision.otherCollider.name != "DownSide" && collision.gameObject.tag == "SafePlace")
        {
            Destroy(gameObject);            
        }
       
        //ship collide with other ship or with map - destroy
        else if (collision.gameObject.tag == "Map" || collision.gameObject.tag == "Ship")
        {
            Destroy(gameObject);            
        }

    }
    private void OnApplicationQuit()
    {
        isQuiting = true;
    }
    // respawn after 3 seconds
    private void OnDestroy()
    {
        if (!isQuiting)
        {
            if (transform.parent.transform.parent.GetComponent<GameSettings>().GetGameMode() == 3)
            {
                scoreBoard.playersAlive--;
            }
            else res.StartCoroutine(res.Spawn(3f));
            var newExplosion = Instantiate(Explosion, transform.position, Quaternion.identity);
            newExplosion.GetComponent<ExplosionAnimation>().playSound = explosionSound;
        }
    }
}
