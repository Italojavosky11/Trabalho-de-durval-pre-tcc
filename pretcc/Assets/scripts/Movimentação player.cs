using UnityEngine;

public class Movimentaçãoplayer : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Ataque")]
    [SerializeField] private GameObject balaPrefab;
    [SerializeField] private Transform firePoint;


    [SerializeField] private int speed = 5;
    [SerializeField] private float jumpForce = 7f;

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime = 0.15f;
    private float coyoteTimeCounter;

    private SpriteRenderer spriteRenderer;
    private bool isGrounded;

   
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        // Coyote Time
        if (isGrounded)
            coyoteTimeCounter = coyoteTime;
        else
            coyoteTimeCounter -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && coyoteTimeCounter > 0f)
        {
            Jump();
            coyoteTimeCounter = 0f;
        }

        // Ataque (Z)
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetBool("atacando", true);
            Tiro(); // chama o tiro
        }

        if (Input.GetKeyUp(KeyCode.Z))
            anim.SetBool("atacando", false);

        // Animações
        anim.SetBool("running", horizontalInput != 0 && isGrounded);
        anim.SetBool("jumping", !isGrounded);

        // Flip
        if (horizontalInput > 0)
            spriteRenderer.flipX = false;
        else if (horizontalInput < 0)
            spriteRenderer.flipX = true;
    }

    void Tiro()
    {
        Instantiate(
            balaPrefab,
            transform.position + Vector3.right,
            Quaternion.identity
        );
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    public void Atirar()
    {
        GameObject bala = Instantiate(balaPrefab, firePoint.position, Quaternion.identity);

        // Define a direção baseada no flip
        float direcao = spriteRenderer.flipX ? -1f : 1f;

        bala.GetComponent<Ataque1>().SetDirecao(direcao);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
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
