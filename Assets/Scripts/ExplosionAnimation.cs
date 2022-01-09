using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimation : MonoBehaviour
{
    private Animator animator;
    public AudioClip playSound;
    private void Start()
    {
        if (playSound)
        {
            GetComponent<AudioSource>().clip = playSound;
            GetComponent<AudioSource>().Play();
        }
        Destroy(gameObject, 0.7f);
    }


}
