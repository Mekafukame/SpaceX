using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingRocket : MonoBehaviour
{
    private GameObject Players, Target, playerParent;
    public GameObject player, Explosion;
    public float rotSpeed = 150;
    public float RocketSpeed = 5;
    private Rigidbody2D rb;
    private string playerName;
    public AudioClip explosionSound;

    void Start()
    {
        Players = GameObject.Find("Players");
        playerParent = player.transform.parent.gameObject;
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5f);
    }

    
    void FixedUpdate()
    {
        rb.velocity = transform.up * RocketSpeed;
        if (!Target)
        {
            rb.angularVelocity = 0;
            float minDistance = 10000;
            foreach(Transform child in Players.transform)
            {

                if (child.tag == "Player" && child.name != playerParent.name)
                {
                    foreach (Transform ship in child.transform)
                    {
                        if (ship.tag == "Ship")
                        {
                            var newDistance = Vector3.Distance(ship.transform.position, gameObject.transform.position);
                            if (newDistance < 500)
                            {
                                if (newDistance < minDistance)
                                {
                                    minDistance = newDistance;
                                    Target = ship.gameObject;
                                }
                                Debug.Log("Distance:    " + newDistance);
                            }
                        }
                    }
                }
            }
        }
        else if (Target)
        {
            Vector2 dir = ((Vector2)Target.transform.position - rb.position).normalized;
            float RotateAmount = Vector3.Cross(dir, transform.up).z;
            rb.angularVelocity = -RotateAmount * rotSpeed;
            
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    private void OnDestroy()
    {
        var newExplosion = Instantiate(Explosion, transform.position, Quaternion.identity);
        newExplosion.transform.localScale = new Vector3(15, 20, 1);
        newExplosion.GetComponent<ExplosionAnimation>().playSound = explosionSound;
    }
}
