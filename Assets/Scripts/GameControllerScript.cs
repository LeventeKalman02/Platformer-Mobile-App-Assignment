using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    private int playerLives = 3;
    private int coinsCollected;

    private void Awake()
    {
        int numGameControllers = FindObjectsOfType<GameControllerScript>().Length;
        if (numGameControllers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Lives: " + playerLives);
        Debug.Log("Coins Collected: " + coinsCollected);
    }

    public void CollectCoins()
    {
        coinsCollected++;
        Debug.Log("Coins Collected: " + coinsCollected);
    }

    public void ProcessDeath()
    {
        if (playerLives > 1)
        {
            TakeOneLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void TakeOneLife()
    {
        playerLives--;
        Debug.Log("Player Lives: " + playerLives);
        ReloadCurrentLevel();
    }

    public void ReloadCurrentLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
