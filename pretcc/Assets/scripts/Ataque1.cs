using UnityEngine;

public class Ataque1 : MonoBehaviour
{
    [SerializeField] private float velocidade = 10f;
    private Vector2 direcao = Vector2.right; // valor padrão

    public void SetDirecao(Vector2 dir)
    {
        direcao = dir.normalized;
    }

    void Update()
    {
        transform.Translate(direcao * velocidade * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }
}
