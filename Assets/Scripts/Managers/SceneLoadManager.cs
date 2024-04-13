using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para carregar cenas

public class SceneLoadManager : MonoBehaviour
{
    // Função pública para carregar uma cena com base em seu índice
    public void LoadSceneByIndex(int sceneIndex)
    {
        Time.timeScale = 1; // Certifique-se de que o tempo está normal antes de carregar a cena
        SceneManager.LoadScene(sceneIndex);
    }

    // Função para reiniciar a cena atual
    public void RestartCurrentScene()
    {
        Time.timeScale = 1; // Certifique-se de que o tempo está normal antes de reiniciar
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}