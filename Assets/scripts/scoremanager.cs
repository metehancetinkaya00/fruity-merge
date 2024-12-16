using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class scoremanager : MonoBehaviour
{
    public TMP_Text scoretext;
    public TMP_Text highscoretext;
    public int scorecount;
    public static int highscorecount;
    // Start is called before the first frame update
    void Start()
    {
       if(PlayerPrefs.HasKey("HighScore"))
        {
            highscorecount = PlayerPrefs.GetInt("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(scorecount>highscorecount)
        {
            highscorecount = scorecount;
            PlayerPrefs.SetInt("HighScore", highscorecount);
        }

        scoretext.text = "Score: " + scorecount;
        highscoretext.text = "High Score: " + highscorecount;
    }
}
