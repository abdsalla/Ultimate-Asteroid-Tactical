using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movespeed;
    public float rotatespeed;

    // Use this for initialization
    void Start()
    {
       // GameManager.instance.enemies.Add(this); // add enemy to list on start of game
    }

    // Update is called once per frame
    void Update()
    {
      //  transform.position += transform.right * movespeed;
    }

    void OnDestroy() //function for what happens when an enemy is destroyed
    {
     //   GameManager.instance.enemies.Remove(this);
    }
}