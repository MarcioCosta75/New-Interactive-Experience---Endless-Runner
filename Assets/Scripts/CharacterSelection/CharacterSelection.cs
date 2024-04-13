using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] characters; // Array dos personagens
    public string[] sceneNames; // Nomes das cenas que correspondem aos personagens
    public int selectedCharacter = 0; // Personagem atualmente selecionado

    void Start()
    {
        // Seleciona o personagem baseado no índice armazenado ou o padrão
        SelectCharacter(PlayerPrefs.GetInt("selectedCharacter", selectedCharacter));
    }

    void SelectCharacter(int index)
    {
        // Desativa todos os personagens
        foreach (GameObject character in characters)
        {
            character.SetActive(false);
        }

        // Ativa apenas o personagem selecionado
        if (index >= 0 && index < characters.Length)
        {
            characters[index].SetActive(true);
            selectedCharacter = index;
        }
        else
        {
            Debug.LogError("Selected character index is out of bounds: " + index);
        }
    }

    public void NextCharacter()
    {
        int nextIndex = (selectedCharacter + 1) % characters.Length;
        SelectCharacter(nextIndex);
        PlayerPrefs.SetInt("selectedCharacter", nextIndex);
    }

    public void PreviousCharacter()
    {
        int prevIndex = (selectedCharacter - 1 + characters.Length) % characters.Length;
        SelectCharacter(prevIndex);
        PlayerPrefs.SetInt("selectedCharacter", prevIndex);
    }

    public void StartGame()
    {
        // Assegura que o índice selecionado não exceda o array de cenas
        if (selectedCharacter < sceneNames.Length)
        {
            SceneManager.LoadScene(sceneNames[selectedCharacter], LoadSceneMode.Single);
        }
        else
        {
            Debug.LogError("No scene is assigned for the selected character index: " + selectedCharacter);
        }
    }
}