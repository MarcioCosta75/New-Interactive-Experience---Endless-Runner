using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public GameObject leftCollider; 
    public GameObject rightCollider; 
    public GameObject jumpTrigger; 
    public GameObject slideTrigger; 
    public PlayerController playerController; 
    public string jumpAnimationTrigger = "jump"; 
    public string slideAnimationTrigger = "slide"; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == leftCollider)
        {
            playerController.currentLane = 0; 
        }
        else if (other.gameObject == rightCollider)
        {
            playerController.currentLane = 2; 
        }
        else if (other.gameObject == jumpTrigger)
        {
            playerController.animator.SetTrigger(jumpAnimationTrigger); 
            playerController.Jump();
        }
        else if (other.gameObject == slideTrigger)
        {
            playerController.animator.SetTrigger(slideAnimationTrigger); 
            playerController.Slide();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == leftCollider || other.gameObject == rightCollider)
        {
            playerController.currentLane = 1; 
        }
    }
}