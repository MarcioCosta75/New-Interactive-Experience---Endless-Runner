using UnityEngine;

public class HeadCollisionDetector : MonoBehaviour
{
    public GameObject jumpCollider; // Colisor est�tico para acionar o pulo
    public PlayerController playerController; // Refer�ncia ao script PlayerController
    public string jumpAnimationTrigger = "jump"; // Nome do trigger da anima��o de pulo

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == jumpCollider)
        {
            Debug.Log("Colis�o com o colisor de pulo detectada.");
            playerController.animator.SetTrigger(jumpAnimationTrigger); // Aciona a anima��o de pulo
            playerController.Jump(); // Chama o m�todo Jump do PlayerController
        }
    }
}