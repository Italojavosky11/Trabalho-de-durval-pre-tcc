using UnityEngine;

public class Movimentaçãoplayer : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private int speed = 5;
    [SerializeField] private float jumpForce = 7f;

    [SerializeField] private GameObject balaPrefab;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float coyoteTime = 0.15f;
    private float coyoteTimeCounter;

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

        if (isGrounded)
            coyoteTimeCounter = coyoteTime;
        else
            coyoteTimeCounter -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && coyoteTimeCounter > 0f)
        {
            Jump();
            coyoteTimeCounter = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Z))
            anim.SetBool("atacando", true);

        if (Input.GetKeyUp(KeyCode.Z))
            anim.SetBool("atacando", false);

        anim.SetBool("running", horizontalInput != 0 && isGrounded);
        anim.SetBool("jumping", !isGrounded);

        if (horizontalInput > 0)
        {
            spriteRenderer.flipX = false;
            firePoint.localPosition = new Vector3(
                Mathf.Abs(firePoint.localPosition.x),
                firePoint.localPosition.y,
                firePoint.localPosition.z
            );
        }
        else if (horizontalInput < 0)
        {
            spriteRenderer.flipX = true;
            firePoint.localPosition = new Vector3(
                -Mathf.Abs(firePoint.localPosition.x),
                firePoint.localPosition.y,
                firePoint.localPosition.z
            );
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

    public void Atirar()
    {
        GameObject bala = Instantiate(balaPrefab, firePoint.position, Quaternion.identity);

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
