using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private ScoreBoard ScoreBoardScript;
    private void Start()
    {
        ScoreBoardScript = GameObject.Find("ScoreBoard").GetComponent<ScoreBoard>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        int number = int.Parse(gameObject.name.Remove(0, 10));        
        ScoreBoardScript.NextCheckpoint(number, collision.transform.parent.name);
    }
}
