using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    //collecting the coins if it collides with the player object and destroy the game object
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<GameControllerScript>().CollectCoins();
            Destroy(gameObject);
        }
    }
}
