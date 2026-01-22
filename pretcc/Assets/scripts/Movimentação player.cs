using UnityEngine;

public class Movimentaçãoplayer : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody2D rb;

    [SerializeField] private int speed = 5;

   



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); // A/D ou ←/→
        
    }
    

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }


    // Update is called once per frame
    
}
