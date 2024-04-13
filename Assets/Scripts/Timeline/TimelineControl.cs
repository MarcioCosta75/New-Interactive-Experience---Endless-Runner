using UnityEngine;
using UnityEngine.Playables;

public class TimelineControl : MonoBehaviour
{
    public PlayableDirector director;  // Referência para o PlayableDirector que controla a Timeline.
    public GameObject cinemachineCamera;  // Referência para a câmera Cinemachine a ser ativada.
    public GameObject king;  // Referência para o GameObject 'King' a ser ativado.
    public GameObject runningJack;  // Referência para o GameObject 'Running Jack' a ser ativado.

    private bool hasActivatedObjects = false;  // Para garantir que a ativação só aconteça uma vez.

    void Update()
    {
        // Verifica se a Timeline chegou ao fim e se os objetos ainda não foram ativados.
        if (director.state != PlayState.Playing && !hasActivatedObjects)
        {
            // Ativa a câmera com Cinemachine.
            if (cinemachineCamera != null)
                cinemachineCamera.SetActive(true);

            // Ativa o GameObject 'King'.
            if (king != null)
                king.SetActive(true);

            // Ativa o GameObject 'Running Jack'.
            if (runningJack != null)
                runningJack.SetActive(true);

            // Marca que os objetos foram ativados para não repetir a ativação.
            hasActivatedObjects = true;
        }
    }
}