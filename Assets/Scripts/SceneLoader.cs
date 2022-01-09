using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject InGameMenu;
    public AudioSource explosionSound;
    public void ChangeToMenu()
    {
        if(explosionSound)explosionSound.mute = true;
        SceneManager.LoadScene("Menu");
        Cursor.visible = true;
    }
    public void ChangeToGame()
    {
        
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
        Cursor.visible = false;
    }   
    public void CloseMenu()
    {
        GameObject.Find("InGameMenu").gameObject.transform.Find("Canvas").gameObject.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;

    }
    public void ChangeToOnlineGame()
    {

        SceneManager.LoadScene("OnlineGame");
        Time.timeScale = 1;
        Cursor.visible = false;
    }

}
