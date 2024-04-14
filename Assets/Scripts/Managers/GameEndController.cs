using UnityEngine;

public class GameEndController : MonoBehaviour
{
    public GameObject endGamePanel; // Refer�ncia para o painel que ser� ativado

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