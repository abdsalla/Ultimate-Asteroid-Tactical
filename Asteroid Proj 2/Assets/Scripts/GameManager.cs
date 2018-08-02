using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance; // created GameManager
    public List<Enemy> enemies; // list of enemies in scene
    public float score; // game score
    public int lives; // player lives
    private Player Pref; 
    private int randint; 
    public List<Vector3> spawnpoints;
    private Vector3 spawnpointV;
    public Transform Eprefab;
    private int Enemycount = 3; // this is the count that is matched towards enemy count
    public int currentEnemyCount = 0;


    void Awake()
    {
        Pref = GetComponent<Player>();
    }


    
    void Start()
    {
        int randint = Random.Range(0, 3);


            Instantiate(Eprefab, spawnpoints[randint], Quaternion.identity);
            currentEnemyCount++;
  

      
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








    void Update()
    {
        if (currentEnemyCount < Enemycount)
        {
            randint = Random.Range(0, 3);
            Instantiate(Eprefab, spawnpoints[randint], Quaternion.identity);
            currentEnemyCount++;
        }




             if (lives < 0)
            {
              OnGameOver();
           }
    }




    
    void OnGameOver()
    {
        Application.Quit();
    }
}
