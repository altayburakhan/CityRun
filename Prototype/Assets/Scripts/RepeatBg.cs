using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBg : MonoBehaviour
{
    private Vector3 startPos;
    private SpriteRenderer sprite;
    private PlayerController pointtext;
    private float repeatWidth;
    public Sprite desert;
    public Sprite city;
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
        pointtext = GameObject.Find("Player").GetComponent<PlayerController>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        if(pointtext.time > 119.5f)
        {
            sprite.sprite = desert;
        }
        
        if(pointtext.time > 241)
        {
            sprite.sprite = city;
        }

        if(transform.position.x < startPos.x - repeatWidth)
        {
            transform.position = startPos;
        }
    }
}
