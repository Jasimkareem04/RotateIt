using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour
{
   public Text HgScore;
   private void Start() 
   {
      HgScore.text =""+ PlayerPrefs.GetInt("HS");
   }
   public void playGame()
   {
    SceneManager.LoadSceneAsync(1);
   }
}
