using UnityEngine;
using UnityEngine.Playables;

public class TimelineControl : MonoBehaviour
{
    public PlayableDirector director;  // Refer�ncia para o PlayableDirector que controla a Timeline.
    public GameObject cinemachineCamera;  // Refer�ncia para a c�mera Cinemachine a ser ativada.
    public GameObject king;  // Refer�ncia para o GameObject 'King' a ser ativado.
    public GameObject runningJack;  // Refer�ncia para o GameObject 'Running Jack' a ser ativado.

    private bool hasActivatedObjects = false;  // Para garantir que a ativa��o s� aconte�a uma vez.

    void Update()
    {
        // Verifica se a Timeline chegou ao fim e se os objetos ainda n�o foram ativados.
        if (director.state != PlayState.Playing && !hasActivatedObjects)
        {
            // Ativa a c�mera com Cinemachine.
            if (cinemachineCamera != null)
                cinemachineCamera.SetActive(true);

            // Ativa o GameObject 'King'.
            if (king != null)
                king.SetActive(true);

            // Ativa o GameObject 'Running Jack'.
            if (runningJack != null)
                runningJack.SetActive(true);

            // Marca que os objetos foram ativados para n�o repetir a ativa��o.
            hasActivatedObjects = true;
        }
    }
}