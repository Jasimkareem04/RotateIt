using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;

public class GameManager : MonoBehaviour
{
   public static bool GameOver = false;
    public GameObject GameOverMenu;
   public void EndGame()
   {
        GameOverMenu.SetActive(true);
        GameOver = true;
        Debug.Log("Game Over");
       // Invoke("Restart",1);
   }

   public void Restart()
   {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

}