using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource enemySource;

    [Header("Clips")]
    [SerializeField] private AudioClip bgm;
    [SerializeField] private AudioClip enemyMusic;

    void Start()
    {
        bgmSource.clip = bgm;
        bgmSource.Play();
    }

    public void PlayEnemyMusic()
    {
        if (enemySource.isPlaying) return;

        bgmSource.Pause();
        enemySource.clip = enemyMusic;
        enemySource.Play();

        StartCoroutine(ReturnToBGM());
    }

    IEnumerator ReturnToBGM()
    {
        yield return new WaitForSeconds(enemyMusic.length);
        bgmSource.UnPause();
    }
}
