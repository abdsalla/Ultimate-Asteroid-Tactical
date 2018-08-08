using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // created GameManager
    public List<Enemy> enemies; // list of enemies in scene
    public float score; // game score
    public int lives; // player lives
    public List<Vector3> spawnpoints;
    public Transform Eprefab;
    public GameObject firstEnemy;
    public GameObject player;

    //private Player Pref;
    private int randint;
    private Vector3 spawnpointV;// Never used
    private int Enemycount = 3; // this is the count that is matched towards enemy count

    void Awake()
    {
        //Pref = GetComponent<Player>();
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        int randint = Random.Range(0, 3);
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // do not destroy this GameManager in different scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private float lastTime;
    private float currTime;
    private float spawnDelay = 2.0f;

    void Update()
    {
        currTime += Time.deltaTime;
        if (enemies.Count < Enemycount && (currTime - lastTime) >= spawnDelay)             
        {                                                                                    
            lastTime = currTime;                                                             
            Debug.Log("Making Enemies " + enemies.Count + " : " + Enemycount);
            randint = Random.Range(0, 3);
            Instantiate(Eprefab, spawnpoints[randint], Quaternion.identity);
        }

        if (lives < 0)
        {
            OnGameOver();
        }

        /* Spawn Enemeies
         * pick random spawn 
         * points in the list
         * with the random integer
         */

    }
    
    void OnGameOver()
    {
        Debug.Log("YOU LOSE!");
        score = 0;
        lives = 3;
        foreach(Enemy e in enemies)
        {
            Destroy(e.gameObject);
        }
        player.transform.position = new Vector3(0, 0, 0);
        Application.Quit();
    }
}
