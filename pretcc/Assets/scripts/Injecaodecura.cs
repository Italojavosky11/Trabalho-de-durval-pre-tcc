using UnityEngine;

public class Injecaodecura : MonoBehaviour
{
    [SerializeField] private AudioClip injecaoSound;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(injecaoSound, transform.position);
            Destroy(gameObject);
        }
    }
}
