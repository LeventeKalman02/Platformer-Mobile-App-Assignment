using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{
    [SerializeField] private float waitTime = 1f;

    public void LoadNextLevel()
    {
        StartCoroutine("LoadNextLevelWithDelay");
    }

    IEnumerator LoadNextLevelWithDelay()
    {
        yield return new WaitForSeconds(waitTime);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync((currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings);
    }
}
