using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private int numOfHearts = 3;
    [SerializeField] private Image[] hearts;

    void Start()
    {
        DisplayHealth(FindAnyObjectByType<GameControllerScript>().playerLives);
    }

    public void DisplayHealth(int currentLives)
    {
        Debug.Log("Display Health");
        if (currentLives < numOfHearts)
        {
            for ( int i = hearts.Length -1; i >= 0; i--)
            {
                if (i >= currentLives)
                {
                    hearts[i].gameObject.SetActive(false);
                }
            }            
        }
    }
}
