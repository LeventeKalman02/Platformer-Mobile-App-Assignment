using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    private PlayerMovement player;
    private GameControllerScript gameController;
    public Text coinsText;
    [SerializeField]private GameObject gameOverScreen;

    private void Awake()
    {
        //find reference to player movement script
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        gameController = FindAnyObjectByType<GameControllerScript>();
    }

    //make the game over screen active whenever you go through the last portal.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //set the game over screen to active
        gameOverScreen.SetActive(true);
        //make the player stop moving 
        player.isAlive = false;
        //get the coins from the game controller script
        int coins = gameController.coinsCollected;
        coinsText.text = coins.ToString() + " Coins";
    }

    //reset the game session when button is clicked
    public void RestartGame()
    {
        gameController.ResetGameSession();
    }
}
