using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    public int AmmoType, Ammo;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //destroy box when ship collects it
        if(collision.gameObject.tag == "Ship")
        {            
            GetComponent<AudioSource>().Play();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject,0.5f);
            collision.gameObject.transform.Find("PlayerGun").gameObject.GetComponent<Shoot>().WeaponId = AmmoType;
            collision.gameObject.transform.Find("PlayerGun").gameObject.GetComponent<Shoot>().Ammunition = Ammo;
        }
    }
    void Start()
    {
        StartCoroutine(demolish());
    }
    //destroy after 90 second
    private IEnumerator demolish()
    {
        yield return new WaitForSeconds(90);
        Destroy(gameObject);
    }

}
