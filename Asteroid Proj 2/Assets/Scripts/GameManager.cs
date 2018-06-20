using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public Player player;
    public List<Enemy> enemies; // list of enemies in scene
    public float score; // game score
    public int lives; // player lives
    public Projectile projectile;



    private void Awake()
    {
        projectile = GetComponent<Projectile>();
    }


    // Use this for initialization
    void Start()
    {
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

        if (lives < 0)
        { // what to do when lives go below 0, points back to OnGameOver
            OnGameOver();
        }
    }




    // Update is called once per frame
    void OnGameOver()
    {

    }
}
