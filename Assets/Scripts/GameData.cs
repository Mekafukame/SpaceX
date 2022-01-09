using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int currentresolutionIndex;
    public float MasterVolume, MusicVolume, EffectsVolume;
    public bool isFullscreen;
    public string[] color;
   
        
    public GameData(SettingsMenu settings)
    {
        color = new string[4];
        currentresolutionIndex = settings.currentResolutionIndex;
        MasterVolume = settings.MasterValue;
        MusicVolume = settings.MusicValue;
        EffectsVolume = settings.EffectsValue;
        isFullscreen = settings.Fullscreen;       
        foreach(ChangePlayerColor TheColor in settings.playerColors)
        {
            color[TheColor.playerID] = TheColor.colorName;
            
        }
    }
}
