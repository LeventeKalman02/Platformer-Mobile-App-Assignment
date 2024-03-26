using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text coinsText;

    public void Setup(int coins)
    {
        gameObject.SetActive(true);
        Debug.Log("Game Over Screen");
        coinsText.text = coins.ToString() + " Coins";
    }
    public void ResetGameSession()
    {
        SceneManager.LoadScene(0);
        FindAnyObjectByType<GameControllerScript>().DestroyObject();
    }
}
