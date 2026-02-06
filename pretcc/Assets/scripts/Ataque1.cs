using UnityEngine;
using UnityEngine.SceneManagement;

public class Ataque1 : MonoBehaviour
{
    public float speed = 5f;
    private float timeDestroy;
    private float direcao = 1f;

    void Start()
    {
        timeDestroy = 1.0f;
        Destroy(gameObject, timeDestroy);
    }

    void Update()
    {
        transform.Translate(Vector2.right * direcao * speed * Time.deltaTime);
    }

    public void SetDirecao(float novaDirecao)
    {
        direcao = novaDirecao;

        Vector3 escala = transform.localScale;
        escala.x = Mathf.Abs(escala.x) * novaDirecao;
        transform.localScale = escala;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            ReiniciarParamenu();
        }
    }

    void ReiniciarParamenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("menu");
    }
}
