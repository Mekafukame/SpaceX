using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class GameStart : MonoBehaviour
{
    private GameSettings settings;    
    void Start()
    {        
        settings = GetComponent<GameSettings>();
        settings.LoadSettings();
    }

    
}
