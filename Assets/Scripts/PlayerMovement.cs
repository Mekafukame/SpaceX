using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float myGravity = 9.8f;
    public float ThrustSpeed = 20.0f;
    public float maxSpeed = 10f; 
    public float RotationSpeed = 4.0f;       
    private Rigidbody2D myRigidbody;
    private GameObject body;    
    private KeyConfig Keys;
    public Animator flames;
    private bool canRotate = true;
    private AudioSource ThrustSound;
    void Start()
    {
        Keys = transform.parent.gameObject.GetComponent<KeyConfig>();
        myRigidbody = GetComponent<Rigidbody2D>();
        body = gameObject.transform.parent.gameObject.transform.Find("PlayerObject").gameObject;
        myRigidbody.freezeRotation = true;
        ThrustSound = GetComponent<AudioSource>();
        ThrustSound.Pause();
    }    
    void FixedUpdate()
    {
        
        //move camera with ship
        body.transform.position = gameObject.transform.position;
        //set max speed                
        if (myRigidbody.velocity.magnitude > maxSpeed)
        {
            myRigidbody.velocity = myRigidbody.velocity.normalized * maxSpeed;
        }
        if (transform.parent.name == "Player3" || transform.parent.name == "Player4")
        {
            //Thrust ship
            if (Input.GetButton(Keys.Vertical))
            {
                ThrustSound.pitch = 1.5f;
                ThrustSound.volume = 0.25f;
                if (!canRotate && !ThrustSound.isPlaying) ThrustSound.UnPause();
                if (myRigidbody.velocity.y < -200 && gameObject.transform.rotation.eulerAngles.z < 90 && gameObject.transform.rotation.eulerAngles.z > -90)
                {
                    myRigidbody.AddRelativeForce(Vector2.up * 2 * ThrustSpeed);

                }
                else if (myRigidbody.velocity.y < -100 && gameObject.transform.rotation.eulerAngles.z < 90 && gameObject.transform.rotation.eulerAngles.z > -90)
                {
                    myRigidbody.AddRelativeForce(Vector2.up * 1.5f * ThrustSpeed);

                }
                else if (myRigidbody.velocity.y < -0.1 && gameObject.transform.rotation.eulerAngles.z < 90 && gameObject.transform.rotation.eulerAngles.z > -90)
                {
                    myRigidbody.AddRelativeForce(Vector2.up * 1.2f * ThrustSpeed);

                }
                else myRigidbody.AddRelativeForce(Vector2.up * ThrustSpeed);
                if (!flames.GetBool("IsThrust"))
                {
                    flames.SetBool("IsThrust", true);
                }

            }
            //gravity
            else
            {
                ThrustSound.pitch = 2.0f;
                ThrustSound.volume = 0.1f;
                if (!canRotate && ThrustSound.isPlaying) ThrustSound.Pause();
                Physics2D.gravity = new Vector2(0, -myGravity);
                if (flames.GetBool("IsThrust"))
                {
                    flames.SetBool("IsThrust", false);
                }

            }
            //prevent form rotating at spawnpoints
            if (canRotate)
            {
                
                //Rotate ship left and right
                if (Input.GetAxisRaw(Keys.Horizontal) > 0)
                {
                    myRigidbody.transform.Rotate(Vector3.back * RotationSpeed);

                }
                if (Input.GetAxisRaw(Keys.Horizontal) < 0)
                {
                    myRigidbody.transform.Rotate(Vector3.forward * RotationSpeed);

                }
            }
        }
        else
        {
            //Thrust ship
            if (Input.GetButton(Keys.Vertical) && Input.GetAxisRaw(Keys.Vertical) > 0)
            {
                ThrustSound.pitch = 1.5f;
                ThrustSound.volume = 0.25f;
                if (!canRotate && !ThrustSound.isPlaying) ThrustSound.UnPause();
                if (myRigidbody.velocity.y < -200 && gameObject.transform.rotation.eulerAngles.z < 90 && gameObject.transform.rotation.eulerAngles.z > -90)
                {
                    myRigidbody.AddRelativeForce(Vector2.up * 2 * ThrustSpeed);

                }
                else if (myRigidbody.velocity.y < -100 && gameObject.transform.rotation.eulerAngles.z < 90 && gameObject.transform.rotation.eulerAngles.z > -90)
                {
                    myRigidbody.AddRelativeForce(Vector2.up * 1.5f * ThrustSpeed);

                }
                else if (myRigidbody.velocity.y < -0.1 && gameObject.transform.rotation.eulerAngles.z < 90 && gameObject.transform.rotation.eulerAngles.z > -90)
                {
                    myRigidbody.AddRelativeForce(Vector2.up * 1.2f * ThrustSpeed);

                }
                else myRigidbody.AddRelativeForce(Vector2.up * ThrustSpeed);
                if (!flames.GetBool("IsThrust"))
                {
                    flames.SetBool("IsThrust", true);
                }
            }
            //gravity
            else
            {
                ThrustSound.pitch = 2.0f;
                ThrustSound.volume = 0.1f;
                if (!canRotate && ThrustSound.isPlaying) ThrustSound.Pause();
                Physics2D.gravity = new Vector2(0, -myGravity);
                if (flames.GetBool("IsThrust"))
                {
                    flames.SetBool("IsThrust", false);
                }
            }
            //prevent form rotating at spawnpoints
            if (canRotate)
            {
                
                //Rotate ship left and right
                if (Input.GetButton(Keys.Horizontal) && Input.GetAxisRaw(Keys.Horizontal) > 0)
                {
                    myRigidbody.transform.Rotate(Vector3.back * RotationSpeed);

                }
                if (Input.GetButton(Keys.Horizontal) && Input.GetAxisRaw(Keys.Horizontal) < 0)
                {
                    myRigidbody.transform.Rotate(Vector3.forward * RotationSpeed);

                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "SafePlace")
        {
            canRotate = false;
            flames.SetBool("isOnSpawn", true);
            ThrustSound.Pause();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)        
    {        
        if (collision.tag == "SafePlace")
        {
            canRotate = true;
            flames.SetBool("isOnSpawn", false);
            ThrustSound.UnPause();
        }
    }
}
