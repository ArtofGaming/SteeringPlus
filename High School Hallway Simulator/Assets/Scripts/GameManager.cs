using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject levelCompleteUI;
    public void CompleteLevel()
    {
        levelCompleteUI.SetActive(true);
    }
   public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", 2f);
        }
        
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
