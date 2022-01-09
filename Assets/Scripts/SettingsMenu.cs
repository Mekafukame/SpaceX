using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider MasterSlider, MusicSlider, EffectsSlider;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public float MasterValue, MusicValue, EffectsValue;
    public int currentResolutionIndex;
    public bool Fullscreen;
    public ChangePlayerColor[] playerColors;
    Resolution[] resolutions;
    void Start()
    {                 

        Fullscreen = Screen.fullScreen;
        audioMixer.GetFloat("MasterVolume",out MasterValue);
        MasterSlider.value = MasterValue;
        audioMixer.GetFloat("MusicVolume", out MusicValue);
        MusicSlider.value = MusicValue;
        audioMixer.GetFloat("EffectsVolume", out EffectsValue);
        EffectsSlider.value = EffectsValue;
        Invoke("LoadSettingsFromFile", 0f);

    }
    void LoadGraphicSettings()
    {
        resolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == 60).ToArray();
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        Fullscreen = Screen.fullScreen;
        Screen.SetResolution(resolutions[currentResolutionIndex].width, resolutions[currentResolutionIndex].height, Screen.fullScreen);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Fullscreen = isFullscreen;
        Screen.fullScreen = isFullscreen;
    }
    public void setResolution(int resolutionIndex)
    {
        currentResolutionIndex = resolutionIndex;
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
    }    
    public void SetMasterVolume(float volume)
    {
        if (volume == -20) volume = -80;
        MasterValue = volume;
        audioMixer.SetFloat("MasterVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        if (volume == -20) volume = -80;
        MusicValue = volume;
        audioMixer.SetFloat("MusicVolume", volume);
    }
    public void SetEffectsVolume(float volume)
    {
        if (volume == -20) volume = -80;
        EffectsValue = volume;
        audioMixer.SetFloat("EffectsVolume", volume);
    }    
    public void SaveSettingToFile()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/GameConfig.cfg";
        FileStream stream = new FileStream(path, FileMode.Create);
        GameData data = new GameData(this);
        formatter.Serialize(stream, data);
        stream.Close();
    }
    public void LoadSettingsFromFile()
    {
        string path = Application.persistentDataPath + "/GameConfig.cfg";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            Fullscreen = data.isFullscreen;
            currentResolutionIndex = data.currentresolutionIndex;
            MasterValue = data.MasterVolume;
            audioMixer.SetFloat("MasterVolume", MasterValue);
            MasterSlider.value = MasterValue;
            MusicValue = data.MusicVolume;
            audioMixer.SetFloat("MusicVolume", MusicValue);
            MusicSlider.value = MusicValue;
            EffectsValue = data.EffectsVolume;
            EffectsSlider.value = EffectsValue;
            audioMixer.SetFloat("EffectsVolume", EffectsValue);
            playerColors[0].colorName = data.color[0];
            playerColors[1].colorName = data.color[1];
            playerColors[2].colorName = data.color[2];
            playerColors[3].colorName = data.color[3];
        }
        else
        {
            Debug.Log("File does not Exist!");           
        }
    }
    public void ExitGame()
    {
        Invoke("SaveSettingToFile", 0f);
        Application.Quit();
    }
}
