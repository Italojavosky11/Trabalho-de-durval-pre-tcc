using UnityEngine;

public class coin : MonoBehaviour
{
    [SerializeField] private int value = 1;
    [SerializeField] private AudioClip coinSound;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(coinSound, transform.position);
            Destroy(gameObject);
        }
    }
}
