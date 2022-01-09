using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public string[] Weapons = new string[7] { "One-Shot", "Double-Shot", "Triple-Shot", "Quad-Shot", "Spray", "Rocket", "Bouncy-Shot" }; //Ammo Types
    public int WeaponId = 0;
    public int Ammunition = 0;
    public GameObject Bullet, Rocket; //Bullet Prefabs
    private float nextShot; //shoot cooldown
    public float bulletSpeed = 20f;
    GameObject newBullet, Parent;
    private KeyConfig Keys;
    private AudioSource shootSound;
    public AudioClip BulletshotClip, RocketShotClip;
    void Start()
    {
        Keys = transform.parent.gameObject.transform.parent.gameObject.GetComponent<KeyConfig>();
        shootSound = GetComponent<AudioSource>();
        
    }
    private void Awake()
    {
        Parent = transform.parent.transform.parent.gameObject;
    }
    void FixedUpdate()
    {
        if (Input.GetButton(Keys.Fire) && nextShot <= Time.time)
        {
            shootSound.pitch = 0.3f;
            //normal ammo shoot
            if (Ammunition == 0)
            {
                shootSound.PlayOneShot(BulletshotClip);
                nextShot = Time.time + 0.5f;                
                newBullet = Instantiate(Bullet, gameObject.transform.position,gameObject.transform.rotation);
                newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed * 10);
                newBullet.GetComponent<BulletCollision>().player = gameObject.transform.parent.gameObject;
                newBullet.GetComponent<BulletCollision>().ScoreBoard = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.Find("ScoreBoard").gameObject;
                newBullet.GetComponent<BulletCollision>().playerParent = gameObject.transform.parent.gameObject.transform.parent.gameObject;
                newBullet.GetComponent<TrailRenderer>().startColor = gameObject.transform.parent.GetComponent<SpriteRenderer>().color;
               
            }
            //special ammo shoot
            else
            {
                var rotation = gameObject.transform.rotation;
                switch (WeaponId)
                {
                    //double-shot
                    case 1:
                        shootSound.PlayOneShot(BulletshotClip);
                        nextShot = Time.time + 0.5f;
                        Ammunition -= 2;
                        rotation = gameObject.transform.rotation;
                        rotation *= Quaternion.Euler(0, 0, 5);                                          
                        newBullet = Instantiate(Bullet, gameObject.transform.position, rotation);                        
                        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed * 10);
                        newBullet.GetComponent<BulletCollision>().player = gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<BulletCollision>().ScoreBoard = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.Find("ScoreBoard").gameObject;
                        newBullet.GetComponent<BulletCollision>().playerParent = gameObject.transform.parent.gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<TrailRenderer>().startColor = gameObject.transform.parent.GetComponent<SpriteRenderer>().color;
                        

                        rotation = gameObject.transform.rotation;
                        rotation *= Quaternion.Euler(0, 0, -5);
                        newBullet = Instantiate(Bullet, gameObject.transform.position, rotation);                       
                        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed * 10);
                        newBullet.GetComponent<BulletCollision>().player = gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<BulletCollision>().ScoreBoard = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.Find("ScoreBoard").gameObject;
                        newBullet.GetComponent<BulletCollision>().playerParent = gameObject.transform.parent.gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<TrailRenderer>().startColor = gameObject.transform.parent.GetComponent<SpriteRenderer>().color;
                        
                        break;
                    //triple-shot
                    case 2:
                        shootSound.PlayOneShot(BulletshotClip);
                        nextShot = Time.time + 0.5f;
                        Ammunition -= 3;
                        rotation = gameObject.transform.rotation;
                        rotation *= Quaternion.Euler(0, 0, 5);                        
                        newBullet = Instantiate(Bullet, gameObject.transform.position, rotation);
                        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed * 10);
                        newBullet.GetComponent<BulletCollision>().player = gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<BulletCollision>().ScoreBoard = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.Find("ScoreBoard").gameObject;
                        newBullet.GetComponent<BulletCollision>().playerParent = gameObject.transform.parent.gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<TrailRenderer>().startColor = gameObject.transform.parent.GetComponent<SpriteRenderer>().color;
                       

                        rotation = gameObject.transform.rotation;
                        newBullet = Instantiate(Bullet, gameObject.transform.position, rotation);
                        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed * 10);
                        newBullet.GetComponent<BulletCollision>().player = gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<BulletCollision>().ScoreBoard = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.Find("ScoreBoard").gameObject;
                        newBullet.GetComponent<BulletCollision>().playerParent = gameObject.transform.parent.gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<TrailRenderer>().startColor = gameObject.transform.parent.GetComponent<SpriteRenderer>().color;
                        

                        rotation = gameObject.transform.rotation;
                        rotation *= Quaternion.Euler(0, 0, -5);
                        newBullet = Instantiate(Bullet, gameObject.transform.position, rotation);
                        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed * 10);
                        newBullet.GetComponent<BulletCollision>().player = gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<BulletCollision>().ScoreBoard = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.Find("ScoreBoard").gameObject;
                        newBullet.GetComponent<BulletCollision>().playerParent = gameObject.transform.parent.gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<TrailRenderer>().startColor = gameObject.transform.parent.GetComponent<SpriteRenderer>().color;
                        
                        break;
                    //quad-shot
                    case 3:
                        shootSound.PlayOneShot(BulletshotClip);
                        nextShot = Time.time + 0.5f;
                        Ammunition -= 4;
                        rotation = gameObject.transform.rotation;
                        rotation *= Quaternion.Euler(0, 0, 7.5f);                        
                        newBullet = Instantiate(Bullet, gameObject.transform.position, rotation);
                        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed * 10);
                        newBullet.GetComponent<BulletCollision>().player = gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<BulletCollision>().ScoreBoard = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.Find("ScoreBoard").gameObject;
                        newBullet.GetComponent<BulletCollision>().playerParent = gameObject.transform.parent.gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<TrailRenderer>().startColor = gameObject.transform.parent.GetComponent<SpriteRenderer>().color;
                        

                        rotation = gameObject.transform.rotation;
                        rotation *= Quaternion.Euler(0, 0, 2.5f);
                        newBullet = Instantiate(Bullet, gameObject.transform.position, rotation);
                        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed * 10);
                        newBullet.GetComponent<BulletCollision>().player = gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<BulletCollision>().ScoreBoard = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.Find("ScoreBoard").gameObject;
                        newBullet.GetComponent<BulletCollision>().playerParent = gameObject.transform.parent.gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<TrailRenderer>().startColor = gameObject.transform.parent.GetComponent<SpriteRenderer>().color;
                        
                        

                        rotation = gameObject.transform.rotation;
                        rotation *= Quaternion.Euler(0, 0, -2.5f);
                        newBullet = Instantiate(Bullet, gameObject.transform.position, rotation);
                        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed * 10);
                        newBullet.GetComponent<BulletCollision>().player = gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<BulletCollision>().ScoreBoard = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.Find("ScoreBoard").gameObject;
                        newBullet.GetComponent<BulletCollision>().playerParent = gameObject.transform.parent.gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<TrailRenderer>().startColor = gameObject.transform.parent.GetComponent<SpriteRenderer>().color;
                        

                        rotation = gameObject.transform.rotation;
                        rotation *= Quaternion.Euler(0, 0, -7.5f);
                        newBullet = Instantiate(Bullet, gameObject.transform.position, rotation);
                        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed * 10);
                        newBullet.GetComponent<BulletCollision>().player = gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<BulletCollision>().ScoreBoard = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.Find("ScoreBoard").gameObject;
                        newBullet.GetComponent<BulletCollision>().playerParent = gameObject.transform.parent.gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<TrailRenderer>().startColor = gameObject.transform.parent.GetComponent<SpriteRenderer>().color;
                        

                        break;
                    //spray-shot
                    case 4:
                        shootSound.PlayOneShot(BulletshotClip);
                        nextShot = Time.time + 0.1f;
                        Ammunition -= 1;
                        var ang = Random.Range(-10, 10);
                        rotation = gameObject.transform.rotation;
                        rotation *= Quaternion.Euler(0, 0, ang);
                        newBullet = Instantiate(Bullet, gameObject.transform.position, rotation);
                        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed * 10);
                        newBullet.GetComponent<BulletCollision>().player = gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<BulletCollision>().ScoreBoard = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.Find("ScoreBoard").gameObject;
                        newBullet.GetComponent<BulletCollision>().playerParent = gameObject.transform.parent.gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<TrailRenderer>().startColor = gameObject.transform.parent.GetComponent<SpriteRenderer>().color;
                        
                        break;
                    case 5:
                        //rocket-shot
                        shootSound.pitch = 1.8f;
                        shootSound.PlayOneShot(RocketShotClip);
                        nextShot = Time.time + 1f;
                        Ammunition -= 1;                        
                        rotation = gameObject.transform.rotation;                       
                        newBullet = Instantiate(Rocket, gameObject.transform.position, rotation);
                        //newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed * 1);
                        newBullet.GetComponent<BulletCollision>().player = gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<BulletCollision>().ScoreBoard = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.Find("ScoreBoard").gameObject;
                        newBullet.GetComponent<BulletCollision>().playerParent = gameObject.transform.parent.gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<HomingRocket>().player = gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<TrailRenderer>().startColor = gameObject.transform.parent.GetComponent<SpriteRenderer>().color;
                        newBullet.transform.Find("RocketFlame").GetComponent<SpriteRenderer>(). color = gameObject.transform.parent.GetComponent<SpriteRenderer>().color;
                        
                        break;
                    case 6:
                        shootSound.PlayOneShot(BulletshotClip);
                        nextShot = Time.time + 0.5f;
                        Ammunition -= 1;
                        newBullet = Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);
                        newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletSpeed * 10);
                        newBullet.GetComponent<BulletCollision>().player = gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<BulletCollision>().ScoreBoard = gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.Find("ScoreBoard").gameObject;
                        newBullet.GetComponent<BulletCollision>().playerParent = gameObject.transform.parent.gameObject.transform.parent.gameObject;
                        newBullet.GetComponent<TrailRenderer>().startColor = gameObject.transform.parent.GetComponent<SpriteRenderer>().color;
                        newBullet.GetComponent<BulletCollision>().Bounciness = 5;
                        newBullet.GetComponent<CircleCollider2D>().isTrigger = false;
                        

                        break;
                }
                if(Ammunition == 0)
                {
                    WeaponId = 0;
                }
            }
        }
    }
}
