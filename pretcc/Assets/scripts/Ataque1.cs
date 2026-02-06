using UnityEngine;

public class Ataque1 : MonoBehaviour
{
    public float speed = 7f;
    private float direcao = 1f;
    private float lifetime = 1f;

    public void SetDirecao(float novaDirecao)
    {
        direcao = novaDirecao;

        // Espelha o sprite se for esquerda
        if (direcao < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * direcao * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
