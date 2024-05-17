using UnityEngine;

public class SlideKneeCollisionDetector : MonoBehaviour
{
    public GameObject slideCollider; // Colisor estático para acionar o deslizamento
    public PlayerController playerController; // Referência ao script PlayerController
    public string slideAnimationTrigger = "slide"; // Nome do trigger da animação de deslizamento

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == slideCollider)
        {
            Debug.Log("Colisão com o colisor de deslizamento detectada.");
            playerController.animator.SetTrigger(slideAnimationTrigger); // Aciona a animação de deslizamento
            playerController.Slide(); // Chama o método Slide do PlayerController
        }
    }
}