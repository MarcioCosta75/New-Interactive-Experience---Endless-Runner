using UnityEngine;

public class GameEndController : MonoBehaviour
{
    public GameObject endGamePanel; // Referência para o painel que será ativado

    void Start()
    {
        if (endGamePanel != null)
            endGamePanel.SetActive(false); // Garante que o painel esteja desativado inicialmente
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameObject.CompareTag("GameFinal"))
        {
            Time.timeScale = 0; // Congela o jogo parando o tempo
            endGamePanel.SetActive(true); // Ativa o painel de fim de jogo
        }
    }
}