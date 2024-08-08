using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform Player;
    public Text ScoreText;
    public int number;

   
    // Update is called once per frame
    void Start()
    {
        
    }
    void Update()
    {
        number = (int)Player.position.z ;
        ScoreText.text = number.ToString("00"); 
        if (number > PlayerPrefs.GetInt("HS"))
        {
            PlayerPrefs.SetInt("HS",number);
        }
    }
}
