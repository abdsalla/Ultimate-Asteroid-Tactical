using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySpace : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.GetComponent<GameObject>().tag != "Player")
        {
            Destroy(other.gameObject);
        }
    }

    /* When the
     * Outside
     * border of
     * the game
     * collides with
     * something that
     * isn't the player,
     * Destroy that object
     */
}

