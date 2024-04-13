using UnityEngine;
using TMPro;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    public TMP_Text label;

    void Start()
    {
        // Pega o índice do personagem selecionado de PlayerPrefs.
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");

        // Verifica se o índice selecionado está dentro do intervalo para evitar erros de indexação.
        if (selectedCharacter < 0 || selectedCharacter >= characterPrefabs.Length)
        {
            Debug.LogError("Selected character index is out of range. Defaulting to 0.");
            selectedCharacter = 0; // Define para 0 ou outro valor padrão que faça sentido para o seu jogo.
        }

        // Carrega o prefab do personagem com base no índice selecionado.
        GameObject prefab = characterPrefabs[selectedCharacter];

        // Instancia o personagem na posição do ponto de spawn.
        GameObject clone = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

        // Atualiza o texto da label com o nome do prefab do personagem.
        if (label != null)
        {
            label.text = prefab.name;
        }
        else
        {
            Debug.LogError("Label is not set on the LoadCharacter script.");
        }
    }
}
