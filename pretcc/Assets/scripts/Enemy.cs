using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool musicPlayed = false;

    void OnBecameVisible()
    {
        if (musicPlayed) return;

        FindObjectOfType<MusicManager>().PlayEnemyMusic();
        musicPlayed = true;
    }
}
