using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int points;

    PlayerController player;

    void Start()
    {
        player = FindFirstObjectByType<PlayerController>();
    }

    void Update()
    {
        
    }

    public int Collect(int score, int totalCollectables)
    {
        player.countText.text = score + " / " + totalCollectables;
        player.totalText

        Destroy(gameObject);

        return points;
    }
}
