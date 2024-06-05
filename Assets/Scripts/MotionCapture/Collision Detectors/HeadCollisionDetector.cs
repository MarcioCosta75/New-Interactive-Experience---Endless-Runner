using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HeadCollisionDetector : MonoBehaviour
{
    private GameObject jumpCollider; // Colisor est�tico para acionar o pulo
    private PlayerController playerController; // Refer�ncia ao script PlayerController
    public string jumpAnimationTrigger = "jump"; // Nome do trigger da anima��o de pulo

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

        // Procura pelo GameObject com a tag "JumpCollider"
        jumpCollider = GameObject.FindWithTag("JumpCollider");
        if (jumpCollider != null)
        {
            Debug.Log("JumpCollider encontrado e atribu�do.");
        }
        else
        {
            Debug.LogError("GameObject com a tag 'JumpCollider' n�o encontrado.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == jumpCollider)
        {
            Debug.Log("Colis�o com o colisor de pulo detectada.");
            if (playerController != null)
            {
                playerController.animator.SetTrigger(jumpAnimationTrigger); // Aciona a anima��o de pulo
                playerController.Jump(); // Chama o m�todo Jump do PlayerController
                Debug.Log("Anima��o de pulo acionada.");
            }
        }
    }
}