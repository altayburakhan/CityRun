using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource music;
    private PlayerController playerscript;
    private bool stplayed = false;
    private bool ndplayed = false;
    private bool rdplayed = false;
    public AudioClip levelone;
    public AudioClip leveltwo;
    public AudioClip levelthree;
    
    void Start()
    {
        music = GetComponent<AudioSource>();
        playerscript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

   
    void Update()
    {
        if(playerscript.time >= 0 && playerscript.time < 119.5f && !stplayed)
        {
           music.PlayOneShot(levelone); 
           stplayed = true;
        }
        
        else if(playerscript.time > 119.5f && playerscript.time < 241 && !ndplayed)
        {
            music.Stop();
            music.PlayOneShot(leveltwo);
            ndplayed = true;
        }
        else if(playerscript.time > 241 && !rdplayed)
        {
            music.Stop();
            music.PlayOneShot(levelthree);
            rdplayed = true;
        }
    }
   

}
