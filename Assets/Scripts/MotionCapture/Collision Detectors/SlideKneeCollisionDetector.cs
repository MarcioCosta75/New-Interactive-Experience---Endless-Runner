using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SlideKneeCollisionDetector : MonoBehaviour
{
    private GameObject slideCollider; // Colisor estático para acionar o deslizamento
    private PlayerController playerController; // Referência ao script PlayerController
    public string slideAnimationTrigger = "slide"; // Nome do trigger da animação de deslizamento

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

        // Procura pelo GameObject com a tag "SlideCollider"
        slideCollider = GameObject.FindWithTag("SlideCollider");
        if (slideCollider != null)
        {
            Debug.Log("SlideCollider encontrado e atribuído.");
        }
        else
        {
            Debug.LogError("GameObject com a tag 'SlideCollider' não encontrado.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == slideCollider)
        {
            Debug.Log("Colisão com o colisor de deslizamento detectada.");
            if (playerController != null)
            {
                playerController.animator.SetTrigger(slideAnimationTrigger); // Aciona a animação de deslizamento
                playerController.Slide(); // Chama o método Slide do PlayerController
                Debug.Log("Animação de deslizamento acionada.");
            }
        }
    }
}