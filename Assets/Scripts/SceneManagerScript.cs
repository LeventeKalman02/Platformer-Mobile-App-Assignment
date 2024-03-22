using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void StartTheGame()
    {
        SceneManager.LoadScene("Scene 0");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindAnyObjectByType<GameControllerScript>().LoadNextScene();
        }
    }
}
