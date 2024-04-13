using UnityEngine;
using TMPro;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    public TMP_Text label;

    void Start()
    {
        // Pega o �ndice do personagem selecionado de PlayerPrefs.
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");

        // Verifica se o �ndice selecionado est� dentro do intervalo para evitar erros de indexa��o.
        if (selectedCharacter < 0 || selectedCharacter >= characterPrefabs.Length)
        {
            Debug.LogError("Selected character index is out of range. Defaulting to 0.");
            selectedCharacter = 0; // Define para 0 ou outro valor padr�o que fa�a sentido para o seu jogo.
        }

        // Carrega o prefab do personagem com base no �ndice selecionado.
        GameObject prefab = characterPrefabs[selectedCharacter];

        // Instancia o personagem na posi��o do ponto de spawn.
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
