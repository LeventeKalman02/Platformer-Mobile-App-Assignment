using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //If player collides with obstacle, lose a life
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<GameControllerScript>().ProcessDeath();
        }
    }
}
