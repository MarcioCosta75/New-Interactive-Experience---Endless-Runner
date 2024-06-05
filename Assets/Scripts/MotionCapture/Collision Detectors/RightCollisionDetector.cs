using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class RightCollisionDetector : MonoBehaviour
{
    private GameObject rightCollider; // Colisor estático para mover à direita
    private PlayerController playerController; // Referência ao script PlayerController

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
                    Debug.Log("PlayerController encontrado e atribuído.");
                }
                else
                {
                    Debug.LogError("PlayerController não encontrado no GameObject com a tag 'Player'.");
                }
            }
            else
            {
                Debug.LogError("GameObject com a tag 'Player' não encontrado.");
            }
            yield return new WaitForSeconds(1.0f); // Espera um segundo antes de tentar novamente
        }

        // Procura pelo GameObject com a tag "RightCollider"
        rightCollider = GameObject.FindWithTag("RightCollider");
        if (rightCollider != null)
        {
            Debug.Log("RightCollider encontrado e atribuído.");
        }
        else
        {
            Debug.LogError("GameObject com a tag 'RightCollider' não encontrado.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == rightCollider)
        {
            Debug.Log("Colisão com o colisor de direita detectada.");
            if (playerController != null)
            {
                playerController.currentLane = 2; // Mova para a faixa direita
                playerController.isCollidingWithRight = true;
                playerController.UpdateLane(); // Chame UpdateLane diretamente
                Debug.Log("currentLane definido para: " + playerController.currentLane);
                Debug.Log("isCollidingWithRight definido para: " + playerController.isCollidingWithRight);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == rightCollider)
        {
            Debug.Log("Saída da colisão com o colisor de direita.");
            if (playerController != null)
            {
                playerController.isCollidingWithRight = false;
                playerController.UpdateLane();
                Debug.Log("isCollidingWithRight definido para: " + playerController.isCollidingWithRight);
            }
        }
    }
}
