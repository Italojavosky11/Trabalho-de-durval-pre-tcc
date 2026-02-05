using UnityEngine;



public class Ataque1 : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {
            Destroy(other.gameObject); // destrói o inimigo
            Destroy(gameObject);       // destrói a bala
        }
    }
}
