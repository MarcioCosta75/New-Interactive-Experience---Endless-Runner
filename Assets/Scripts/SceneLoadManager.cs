using UnityEngine;
using UnityEngine.SceneManagement; // Necess�rio para carregar cenas

public class SceneLoadManager : MonoBehaviour
{
    // Fun��o p�blica para carregar uma cena com base em seu �ndice
    public void LoadSceneByIndex(int sceneIndex)
    {
        Time.timeScale = 1; // Certifique-se de que o tempo est� normal antes de carregar a cena
        SceneManager.LoadScene(sceneIndex);
    }

    // Fun��o para reiniciar a cena atual
    public void RestartCurrentScene()
    {
        Time.timeScale = 1; // Certifique-se de que o tempo est� normal antes de reiniciar
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}