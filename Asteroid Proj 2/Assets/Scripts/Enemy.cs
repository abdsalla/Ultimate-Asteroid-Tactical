using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movespeed; //movement speed of enemies
    public float rotatespeed; // rotation speed of enemies
    public GameObject player;
    public GameObject[] enemyUno;
    public GameObject enemyDos;

    private Transform Ptrans;
    private Vector3 enemyChase;
    
    

    
    void Start()
    {
        enemyUno = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
        Ptrans = player.GetComponent<Transform>();
        GameManager.instance.enemies.Add(this); // add enemy to list on start of game
    }

    
    void Update()
    {
        if (Ptrans.transform.position != transform.position)
        {
            enemyChase = Ptrans.transform.position - transform.position;
           transform.LookAt(Ptrans);
          //  enemyChase.Normalize();
            transform.position += enemyChase * Time.deltaTime * movespeed;
        }
    }


    void OnDestroy() //function for what happens when an enemy is destroyed
    {
       
        GameManager.instance.score += 100;
        GameManager.instance.enemies.Remove(this);
        GameManager.instance.currentEnemyCount -= 1;
        Destroy(this.gameObject);
        /*       for (var i = 0; i < enemyUno.Length; i++)
               {
                   Destroy(enemyUno[i]);
               }*/
    }
}