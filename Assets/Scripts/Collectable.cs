using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectable : MonoBehaviour
{
    public int points = 1;
    public bool isGrowPowerup = false;

    PlayerController player;

    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
    }

    public int Collect(int score, int totalCollectables, int totalPoints, float totalTime)
    {
        int newTotal = points + totalPoints;

        player.countText.text = score + " / " + totalCollectables;
        player.totalText.text = "Points: " + newTotal;

        GrowPlayer();
        Destroy(gameObject);

        if(score == totalCollectables)
        {
            float newScore = newTotal - totalTime;
            float highScore = PlayerPrefs.GetFloat("HighScore");
            if(newScore > highScore)
            {
                PlayerPrefs.SetFloat("HighScore", newScore);
            }
            SceneManager.LoadScene("GameOver");
        }

        return newTotal; // One one thing can be returned
    }

    void GrowPlayer()
    {
        if(isGrowPowerup == true)
        {
            player.Grow();
        }
    }
}
