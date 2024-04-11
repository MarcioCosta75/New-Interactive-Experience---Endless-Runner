using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject endGamePanel;  // Painel de fim de jogo
    public float collisionTolerance = 0.5f;  // Toler�ncia de colis�o em metros
    public Animator animator;  // Animator do jogador

    private bool isJumping = false;
    private bool isSliding = false;

    private void Update()
    {
        // Atualiza os estados baseado nas anima��es ou triggers
        isJumping = animator.GetCurrentAnimatorStateInfo(0).IsName("jump");
        isSliding = animator.GetCurrentAnimatorStateInfo(0).IsName("slide");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            HandleObstacleCollision(collision);
        }
    }

    void HandleObstacleCollision(Collision collision)
    {
        ObstacleType obstacleType = collision.gameObject.GetComponent<ObstacleBehavior>().type;

        // Verifica o tipo de obst�culo e a condi��o do jogador
        switch (obstacleType)
        {
            case ObstacleType.LowBarrier:
                if (!isSliding)
                {
                    TriggerGameOver();
                }
                break;
            case ObstacleType.HighBarrier:
                if (!isJumping)
                {
                    TriggerGameOver();
                }
                break;
            default:
                TriggerGameOver();
                break;
        }
    }

    void TriggerGameOver()
    {
        FreezeGame();
        ActivateEndGamePanel();
    }

    void FreezeGame()
    {
        Time.timeScale = 0;  // Congela o jogo
    }

    void ActivateEndGamePanel()
    {
        endGamePanel.SetActive(true);  // Ativa o painel de fim de jogo
    }
}

public enum ObstacleType
{
    LowBarrier,
    HighBarrier
}

public class ObstacleBehavior : MonoBehaviour
{
    public ObstacleType type;  // Definido no Inspector para cada obst�culo
}