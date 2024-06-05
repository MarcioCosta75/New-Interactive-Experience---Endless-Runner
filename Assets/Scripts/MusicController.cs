using UnityEngine;

public class MusicController : MonoBehaviour
{
    public GameObject[] objectsToMonitor;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource não encontrado no GameObject.");
        }
    }

    void Update()
    {
        foreach (GameObject obj in objectsToMonitor)
        {
            if (obj.activeInHierarchy)
            {
                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
                return;
            }
        }

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}