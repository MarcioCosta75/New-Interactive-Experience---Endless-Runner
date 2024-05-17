using UnityEngine;

public class HeadCollisionDetector : MonoBehaviour
{
    public GameObject jumpCollider; // Colisor estático para acionar o pulo
    public PlayerController playerController; // Referência ao script PlayerController
    public string jumpAnimationTrigger = "jump"; // Nome do trigger da animação de pulo

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == jumpCollider)
        {
            Debug.Log("Colisão com o colisor de pulo detectada.");
            playerController.animator.SetTrigger(jumpAnimationTrigger); // Aciona a animação de pulo
            playerController.Jump(); // Chama o método Jump do PlayerController
        }
    }
}