using UnityEngine;

public class LeftCollisionDetector : MonoBehaviour
{
    public GameObject leftCollider; // Colisor estático para mover à esquerda
    public PlayerController playerController; // Referência ao script PlayerController

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == leftCollider)
        {
            Debug.Log("Colisão com o colisor de esquerda detectada.");
            playerController.currentLane = 0; // Mova para a faixa esquerda
            playerController.isCollidingWithLeft = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == leftCollider)
        {
            Debug.Log("Saída da colisão com o colisor de esquerda.");
            playerController.isCollidingWithLeft = false;
            playerController.UpdateLane();
        }
    }
}