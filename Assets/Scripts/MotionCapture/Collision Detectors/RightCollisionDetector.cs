using UnityEngine;

public class RightCollisionDetector : MonoBehaviour
{
    public GameObject rightCollider; // Colisor est�tico para mover � direita
    public PlayerController playerController; // Refer�ncia ao script PlayerController

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == rightCollider)
        {
            Debug.Log("Colis�o com o colisor de direita detectada.");
            playerController.currentLane = 2; // Mova para a faixa direita
            playerController.isCollidingWithRight = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == rightCollider)
        {
            Debug.Log("Sa�da da colis�o com o colisor de direita.");
            playerController.isCollidingWithRight = false;
            playerController.UpdateLane();
        }
    }
}