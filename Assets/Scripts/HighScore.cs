using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public TMP_Text highScoreText;

    void Start()
    {
       // PlayerPrefs.SetFloat("HighScore", 0);
        //PlayerPrefs.Save();

        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + PlayerPrefs.GetFloat("HighScore");
        }
    }

    void Update()
    {
        
    }
}
