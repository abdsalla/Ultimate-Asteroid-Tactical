using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform trans; // creating a variable  to store GetComponent inside of it
    public float movespeed = 5.0f; // making a float variable that will represent the speed that the ship moves forward
    public float rotatespeed = 2.0f; // making a float variable that will represent the speed that the ship rotates
    public float spawndistance;
    public Projectile projectile;

    void Start()
    {
        projectile = GetComponent<Projectile>();
        trans = GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A)) // check at every frame drop for A being pressed
        {
            trans.Rotate(Vector3.forward * rotatespeed); // rotates ship left if A is pressed
        }
        if (Input.GetKey(KeyCode.D)) // check at every frame drop for D being pressed
        {
            trans.Rotate(Vector3.back * rotatespeed); // rotates ship in the opposite direction if D is pressed, aka right
        }
        if (Input.GetKey(KeyCode.W)) // check at every frame drop for W being pressed
        {
            transform.position += transform.right * movespeed; // moves ship in the direction it is facing when W is pressed
        }
        if (Input.GetKey(KeyCode.S)) // check at every frame drop for W being pressed
        {
            transform.position -= transform.right * movespeed; // moves ship in the direction it is facing when W is pressed
        }
        if (Input.GetKey(KeyCode.Space)) // check at every frame drop for W being pressed
        {

            Instantiate(projectile, (trans.position + (trans.right * spawndistance)), GetComponent<Transform>().rotation);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
}