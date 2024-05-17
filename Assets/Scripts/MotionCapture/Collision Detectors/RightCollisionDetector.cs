using UnityEngine;

public class RightCollisionDetector : MonoBehaviour
{
    public GameObject rightCollider; // Colisor estático para mover à direita
    public PlayerController playerController; // Referência ao script PlayerController

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == rightCollider)
        {
            Debug.Log("Colisão com o colisor de direita detectada.");
            playerController.currentLane = 2; // Mova para a faixa direita
            playerController.isCollidingWithRight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == rightCollider)
        {
            Debug.Log("Saída da colisão com o colisor de direita.");
            playerController.isCollidingWithRight = false;
            playerController.UpdateLane();
        }
    }
}