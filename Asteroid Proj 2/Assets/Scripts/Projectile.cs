using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float travelspeed;
    public float lifespan;

    void Start()
    {
    
    } 


    void Update ()
    {
        transform.position += transform.right * travelspeed;
        Destroy(gameObject, lifespan);
	}


    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.tag.Equals ("Enemy")){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
