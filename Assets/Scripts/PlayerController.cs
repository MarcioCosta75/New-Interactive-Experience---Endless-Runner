using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float sideSpeed = 5.0f;  // Velocidade de movimento lateral
    public float forwardSpeed = 7.0f;  // Velocidade constante de movimento para frente
    public float jumpForce = 7.0f;
    public Animator animator;
    public Rigidbody rb;
    public LayerMask groundLayer;  // Layer do ch�o
    public float groundCheckDistance = 0.1f;  // Dist�ncia para verificar o ch�o

    private bool isSliding = false;
    private float horizontalMovement;

    // Start is called before the first frame update
    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * sideSpeed;
        transform.Translate(horizontalMovement * Time.deltaTime, 0, forwardSpeed * Time.deltaTime);

        // Debugging to view the raycast in the Scene view
        Debug.DrawRay(transform.position + new Vector3(0, 0.1f, 0), -Vector3.up * groundCheckDistance, Color.red);

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded())
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Slide();
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            StopSliding();
        }
    }

    void Jump()
    {
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        animator.SetTrigger("jump");
    }

    void Slide()
    {
        if (!isSliding)
        {
            animator.SetTrigger("slide");
            isSliding = true;
            // Implementar mec�nicas de deslizar, como mudar a colis�o
        }
    }

    void StopSliding()
    {
        isSliding = false;
        // Resetar mudan�as de colis�o se necess�rio
    }

    bool IsGrounded()
    {
        Vector3 rayStart = transform.position + new Vector3(0, 0.1f, 0);
        return Physics.Raycast(rayStart, -Vector3.up, groundCheckDistance, groundLayer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Este m�todo � suficiente para a maioria dos casos se configurado corretamente
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            // Fazer algo se necess�rio quando tocar o ch�o
        }
    }
}