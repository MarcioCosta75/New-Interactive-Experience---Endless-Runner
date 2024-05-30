using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float sideSpeed = 5.0f;
    public float forwardSpeed = 7.0f;
    public float jumpForce = 7.0f;
    public Animator animator;
    public Rigidbody rb;
    public LayerMask groundLayer;
    public float groundCheckDistance = 0.1f;
    public GameObject endGamePanel;
    public BoxCollider playerCollider;

    public int currentLane = 1;  // 0 = esquerda, 1 = meio, 2 = direita
    private bool isSliding = false;
    public float[] lanesXPositions = { -1.5f, 0.0f, 1.5f };

    private Vector3 originalColliderSize;
    private Vector3 originalColliderCenter;

    // Variáveis para rastrear colisões
    public bool isCollidingWithLeft;
    public bool isCollidingWithRight;

    // Variáveis para controlar o som de corrida
    public AudioSource runningAudioSource;

    void Start()
    {
        originalColliderSize = playerCollider.size;
        originalColliderCenter = playerCollider.center;

        if (runningAudioSource == null)
        {
            runningAudioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Movimento para a nova posição na faixa
        Vector3 newPosition = new Vector3(lanesXPositions[currentLane], transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, newPosition, sideSpeed * Time.deltaTime);

        // Movimento constante para frente
        transform.Translate(0, 0, forwardSpeed * Time.deltaTime);

        // Lógica de pulo
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && IsGrounded() && !isSliding)
        {
            Jump();
        }

        // Lógica de deslizamento
        if (Input.GetKeyDown(KeyCode.DownArrow) && IsGrounded() && !isSliding)
        {
            Slide();
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            isSliding = false;
        }

        // Controla o som de corrida
        if (IsGrounded() && !isSliding && !runningAudioSource.isPlaying)
        {
            runningAudioSource.Play();
        }
        else if ((!IsGrounded() || isSliding) && runningAudioSource.isPlaying)
        {
            runningAudioSource.Pause();
        }
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        animator.SetTrigger("jump");
        playerCollider.size = new Vector3(playerCollider.size.x, 0.5f, playerCollider.size.z);
        playerCollider.center = new Vector3(playerCollider.center.x, 1.5f, playerCollider.center.z);
        StartCoroutine(ResetColliderAfterJump());
        runningAudioSource.Pause(); // Pausa o som de corrida durante o pulo
    }

    IEnumerator ResetColliderAfterJump()
    {
        // Espera pela duração da animação de pulo
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        ResetCollider();
    }

    public void Slide()
    {
        animator.SetTrigger("slide");
        isSliding = true;
        // Ajusta o collider para deslizar
        playerCollider.size = new Vector3(originalColliderSize.x, originalColliderSize.y / 4, originalColliderSize.z);
        playerCollider.center = new Vector3(originalColliderCenter.x, originalColliderCenter.y - originalColliderSize.y / 4, originalColliderCenter.z);
        StartCoroutine(ResetColliderAfterSlide());
        runningAudioSource.Pause(); // Pausa o som de corrida durante o slide
    }

    IEnumerator ResetColliderAfterSlide()
    {
        // Espera pela duração da animação de deslizamento
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
        ResetCollider();
    }

    void ResetCollider()
    {
        if (!isSliding)
        {
            // Retorna o collider ao tamanho original
            playerCollider.size = originalColliderSize;
            playerCollider.center = originalColliderCenter;
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position + new Vector3(0, 0.1f, 0), -Vector3.up, groundCheckDistance, groundLayer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        Time.timeScale = 0;
        gameObject.SetActive(false);
        endGamePanel.SetActive(true);
        runningAudioSource.Stop(); // Para o som de corrida no game over
    }

    // Método para atualizar a pista atual
    public void UpdateLane()
    {
        if (!isCollidingWithLeft && !isCollidingWithRight)
        {
            currentLane = 1; // Pista do meio
        }
    }
}