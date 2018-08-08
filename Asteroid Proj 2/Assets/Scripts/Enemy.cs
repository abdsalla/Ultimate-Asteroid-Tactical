using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movespeed; //movement speed of enemies
    public float rotatespeed; // rotation speed of enemies

    private Transform Ptrans;
    private GameManager gm;
    
    void Start()
    {
        gm = GameManager.instance; // gm is equal to GameManager.instance, this is only to save space
        Ptrans = gm.player.GetComponent<Transform>();
        gm.enemies.Add(this); // add enemy to list on start of game
    }
    
    void Update()
    {
        if (Ptrans.transform.position != transform.position) // if the Player's position is not equal to the Enemy's position
        {
            Vector3 enemyChase = Ptrans.transform.position - transform.position;
            transform.right = Ptrans.position - transform.position;
            enemyChase.Normalize();
            transform.position += enemyChase * Time.deltaTime * movespeed;
        }
        /* Make the Enemy
         * move towards
         * the Player's
         * position
         */
    }

    void OnDestroy() //function for what happens when an enemy is destroyed, aka score increase and delete the Enemy from the gm's list
    {
        gm.score += 100;
        gm.enemies.Remove(this);
        Debug.Log("Removing Enemies");
        Destroy(this.gameObject);
    }
}