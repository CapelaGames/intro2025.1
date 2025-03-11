using Unity.VisualScripting;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int points = 1;
    public bool isGrowPowerup = false;

    PlayerController player;

    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
    }

    public int Collect(int score, int totalCollectables, int totalPoints)
    {
        int newTotal = points + totalPoints;

        player.countText.text = score + " / " + totalCollectables;
        player.totalText.text = "Points: " + newTotal;

        GrowPlayer();
        Destroy(gameObject);

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
