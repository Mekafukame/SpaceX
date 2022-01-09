using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip[] MusicList;
    void Start()
    {
        int rand = Random.Range(0, MusicList.Length - 1);
        GetComponent<AudioSource>().clip = MusicList[rand];
        GetComponent<AudioSource>().Play();
    }
    private void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            int rand = Random.Range(0, MusicList.Length - 1);
            GetComponent<AudioSource>().clip = MusicList[rand];
        }
    }
}
