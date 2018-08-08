using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float travelspeed; // speed of bullet defined by the designer
    public float lifespan; // how long the bullet stays airborne
    public GameObject projectile; // bullet plug in at Inspector

    void Start()
    {
        projectile = this.gameObject; // the projectile is the object that this script is attached to
    }

    void Update ()
    {
        transform.position += transform.right * travelspeed; // every frame accelerater the bullet forward
        Destroy(gameObject, lifespan); // Destroy the bullet after the lifespan passes
	}

    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.tag.Equals ("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    /* On Trigger Enter 2D
     *  if this object 
     *  collides with an 
     *  Enemy, Destroy
     *  the other object
     *  first, then destroy 
     *  this object
     */


}
