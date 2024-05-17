using UnityEngine;

public class SlideKneeCollisionDetector : MonoBehaviour
{
    public GameObject slideCollider; // Colisor est�tico para acionar o deslizamento
    public PlayerController playerController; // Refer�ncia ao script PlayerController
    public string slideAnimationTrigger = "slide"; // Nome do trigger da anima��o de deslizamento

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == slideCollider)
        {
            Debug.Log("Colis�o com o colisor de deslizamento detectada.");
            playerController.animator.SetTrigger(slideAnimationTrigger); // Aciona a anima��o de deslizamento
            playerController.Slide(); // Chama o m�todo Slide do PlayerController
        }
    }
}