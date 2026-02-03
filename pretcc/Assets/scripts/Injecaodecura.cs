using UnityEngine;

public class Injecaodecura : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) { Destroy(gameObject); }

    }
}
