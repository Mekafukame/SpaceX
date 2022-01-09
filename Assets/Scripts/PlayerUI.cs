using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private Shoot ShootScript;
    public GameObject Player;
    public TMPro.TMP_Text Weapon, Ammo, Speed;
    void Start()
    {
        
    }
    void Update()
    {
        //check ammo type and ammunition
        if (ShootScript)
        {            
            Weapon.text = ShootScript.Weapons[ShootScript.WeaponId];
            if(ShootScript.Ammunition == 0)
            {
                Ammo.text = "-";
            }
            else Ammo.text = ShootScript.Ammunition.ToString();            
        }
        if (Player)
        {
            foreach (Transform child in Player.transform)
            {
                if (child.gameObject.tag == "Ship")
                {

                    var speed = Mathf.RoundToInt(child.GetComponent<Rigidbody2D>().velocity.magnitude);
                    if(speed < 5)
                    {
                        Speed.text = "0";
                    }
                    else Speed.text = speed.ToString();
                }
            }
        }
    }
    //set variables after respawn
    public void NewShip()
    {
        foreach (Transform child in Player.transform)
        {
            if (child.gameObject.tag == "Ship")
            {                
                ShootScript = child.Find("PlayerGun").gameObject.GetComponent<Shoot>();
            }
        }
    }
}
