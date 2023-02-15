using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool is_restart = false;    
   public void resart_game()
    {
        is_restart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SceneManager.LoadScene("level1");
        }
    }
    public void exit_game()
    {
        Application.Quit();
    }

   
}
