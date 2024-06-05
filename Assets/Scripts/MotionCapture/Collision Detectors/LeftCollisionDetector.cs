using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LeftCollisionDetector : MonoBehaviour
{
    private GameObject leftCollider; // Colisor est�tico para mover � esquerda
    private PlayerController playerController; // Refer�ncia ao script PlayerController

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        StartCoroutine(FindPlayerController());
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(FindPlayerController());
    }

    private IEnumerator FindPlayerController()
    {
        while (playerController == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                playerController = player.GetComponent<PlayerController>();
                if (playerController != null)
                {
                    Debug.Log("PlayerController encontrado e atribu�do.");
                }
                else
                {
                    Debug.LogError("PlayerController n�o encontrado no GameObject com a tag 'Player'.");
                }
            }
            else
            {
                Debug.LogError("GameObject com a tag 'Player' n�o encontrado.");
            }
            yield return new WaitForSeconds(1.0f); // Espera um segundo antes de tentar novamente
        }

        // Procura pelo GameObject com a tag "LeftCollider"
        leftCollider = GameObject.FindWithTag("LeftCollider");
        if (leftCollider != null)
        {
            Debug.Log("LeftCollider encontrado e atribu�do.");
        }
        else
        {
            Debug.LogError("GameObject com a tag 'LeftCollider' n�o encontrado.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == leftCollider)
        {
            if (playerController != null)
            {
                playerController.currentLane = 0; // Mova para a faixa esquerda
                playerController.isCollidingWithLeft = true;
                playerController.UpdateLane(); // Chame UpdateLane diretamente
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == leftCollider)
        {
            if (playerController != null)
            {
                playerController.isCollidingWithLeft = false;
                playerController.UpdateLane();
            }
        }
    }
}