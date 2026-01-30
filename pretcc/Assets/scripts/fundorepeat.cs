using UnityEngine;

public class fundorepeat : MonoBehaviour
{
    [SerializeField] private float velocidade = 5f;
    private float largura;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        largura = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        
        transform.position += Vector3.left * velocidade * Time.deltaTime;

        
        if (transform.position.x < -largura)
        {
            transform.position = new Vector3(largura, transform.position.y, transform.position.z);
        }
    }
    
}
