using UnityEngine;

public class Movimentaçãoplayer : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody2D rb;

    [SerializeField] private int speed = 5;
    [SerializeField] private float jumpForce = 7f;

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime = 0.15f;
    private float coyoteTimeCounter;

    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // Atualiza o contador do coyote time
        if (isGrounded)
            coyoteTimeCounter = coyoteTime;
        else
            coyoteTimeCounter -= Time.deltaTime;

        // Pulo (com coyote time)
        if (Input.GetKeyDown(KeyCode.Space) && coyoteTimeCounter > 0f)
        {
            Jump();
            coyoteTimeCounter = 0f; // impede pulo duplo
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    // Detecta chão
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}
