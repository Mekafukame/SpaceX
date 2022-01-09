using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AmmoSpawn : MonoBehaviour
{
    public GameObject[] AmmoBoxes = new GameObject[6];
    public GameObject Players;
    public int cooldown = 30, range = 150;
    private Animator respawnAnimation;
    void Start()
    {
        respawnAnimation = transform.Find("RespawnAnimation").GetComponent<Animator>();
        StartCoroutine(spawnAmmo());
    }
    //spawns ammo in range of ammospawn
    private IEnumerator spawnAmmo() 
    {
        yield return new WaitForSeconds(cooldown/3);
        var i = Random.Range(0, 100);
        var randposx = Random.Range(-range, range);
        var randposy = Random.Range(-range, range);
        var pos = gameObject.transform.position+ new Vector3(randposx ,randposy,0);
        transform.Find("RespawnAnimation").position = pos;
        respawnAnimation.SetTrigger("Respawn");
        yield return new WaitForSeconds(0.8f);
        //spawn rocketbox
        if (i < 5)
        {
            var box = Instantiate(AmmoBoxes[4], pos, Quaternion.identity);
            
        }
        //spawn spraybox
        else if (i < 20)
        {
            var box = Instantiate(AmmoBoxes[3], pos, Quaternion.identity);
            
        }
        //spawn BouncyBox
        else if (i < 35)
        {
            var box = Instantiate(AmmoBoxes[5], pos, Quaternion.identity);
            
        }
        //spawn doublebox
        else if (i < 65)
        {
            var box = Instantiate(AmmoBoxes[0], pos, Quaternion.identity);
           
        }
        //spawn triplebox
        else if (i < 85)
        {
            var box = Instantiate(AmmoBoxes[1], pos, Quaternion.identity);
            
        }
        //spawn quadbox
        else if (i < 100)
        {
            var box = Instantiate(AmmoBoxes[2], pos, Quaternion.identity);
            
        }
        yield return new WaitForSeconds(cooldown*2 / 3);               
        StartCoroutine(spawnAmmo());
    }


}