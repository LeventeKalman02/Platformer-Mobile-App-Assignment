using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    private bool playSound = false;
    [SerializeField] private AudioSource ping;

    //collecting the coins if it collides with the player object and destroy the game object
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!ping.isPlaying && other.gameObject.tag == "Player")
        {
            ping.Play();
            playSound = true;
            FindObjectOfType<GameControllerScript>().CollectCoins();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void Update()
    {
        if (playSound)
        {
            if (!ping.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}
