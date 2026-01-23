using UnityEngine;

public class coin : MonoBehaviour
{
    [SerializeField] private int value = 1;


    void OnTriggerEnter2D (Collider2D collision){  

        if (collision.CompareTag( "Player" )){ Destroy(gameObject); }

    }
}
