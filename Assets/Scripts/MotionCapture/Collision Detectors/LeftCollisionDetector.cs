using UnityEngine;

public class LeftCollisionDetector : MonoBehaviour
{
    public GameObject leftCollider; // Colisor est�tico para mover � esquerda
    public PlayerController playerController; // Refer�ncia ao script PlayerController

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == leftCollider)
        {
            Debug.Log("Colis�o com o colisor de esquerda detectada.");
            playerController.currentLane = 0; // Mova para a faixa esquerda
            playerController.isCollidingWithLeft = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == leftCollider)
        {
            Debug.Log("Sa�da da colis�o com o colisor de esquerda.");
            playerController.isCollidingWithLeft = false;
            playerController.UpdateLane();
        }
    }
}