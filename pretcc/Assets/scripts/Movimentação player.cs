using UnityEngine;

public class Movimentaçãoplayer : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private int speed = 5;
    [SerializeField] private float jumpForce = 7f;

    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime = 0.15f;
    private float coyoteTimeCounter;

    private SpriteRenderer spriteRenderer;

    [Header("Ataque")]
    [SerializeField] private GameObject balaPrefab;
    [SerializeField] private Transform firePoint;

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

        // ATAQUE (tecla Z)
        if (Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetBool("atacando", true);
            Atirar();
        }

        if (Input.GetKeyUp(KeyCode.Z))
            anim.SetBool("atacando", false);

        // Animações
        anim.SetBool("running", horizontalInput != 0 && isGrounded);
        anim.SetBool("jumping", !isGrounded);

        // Flip do personagem
        if (horizontalInput > 0)
            spriteRenderer.flipX = false;
        else if (horizontalInput < 0)
            spriteRenderer.flipX = true;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * speed, rb.linearVelocity.y);
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    void Atirar()
    {
        GameObject bala = Instantiate(balaPrefab, firePoint.position, Quaternion.identity);

        Vector2 direcao = spriteRenderer.flipX ? Vector2.left : Vector2.right;

        Ataque1 ataque = bala.GetComponent<Ataque1>();

        if (ataque != null)
            ataque.SetDirecao(direcao);
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
