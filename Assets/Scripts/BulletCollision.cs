using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public GameObject player , ScoreBoard, playerParent;
    public int Bounciness = 0;
    private float bulletspeed;
    Vector3 lastVelocity;
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        //destroy ship when hit
        if (player)
        {
            if (collision.gameObject != player && collision.gameObject.tag == "Ship")
            {                
                //Add point in deathmatch
                if (playerParent.transform.parent.gameObject.GetComponent<GameSettings>().GetGameMode() == 0)
                {
                    ScoreBoard.GetComponent<ScoreBoard>().AddScore(playerParent.name);
                }                
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }        
        else
        {
            if (collision.gameObject.tag == "Ship")
            {                
                if (playerParent.transform.parent.gameObject.GetComponent<GameSettings>().GetGameMode() == 0)
                {
                    ScoreBoard.GetComponent<ScoreBoard>().AddScore(playerParent.name);
                }
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
        
        //destroy bullet on collision with map
        if (collision.gameObject.tag == "Map")
        {
            if (Bounciness == 0)
            {
                Destroy(gameObject);
            }            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (player)
        {
            if (collision.gameObject == player )
            {
                Physics2D.IgnoreCollision(collision.collider, collision.otherCollider, true);
            }
            else if (collision.gameObject != player && collision.gameObject.tag == "Ship")
            {
                Debug.Log(ScoreBoard);
                //Add point in deathmatch
                if (playerParent.transform.parent.gameObject.GetComponent<GameSettings>().GetGameMode() == 0)
                {
                    ScoreBoard.GetComponent<ScoreBoard>().AddScore(playerParent.name);
                }
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }
        }
        
        if (collision.gameObject.tag == "Map" || collision.gameObject.tag == "SafePlace")
        {
            if (Bounciness == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                var speed = lastVelocity.magnitude;
                var dir = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);
                gameObject.GetComponent<Rigidbody2D>().velocity = dir * Mathf.Max(bulletspeed, 0f) ;
                Bounciness--;
            }
        }        
       
    }
    private void Update()
    {
        lastVelocity = GetComponent<Rigidbody2D>().velocity;
    }   
    private void Start()
    {
                
        bulletspeed = gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
    }    
}