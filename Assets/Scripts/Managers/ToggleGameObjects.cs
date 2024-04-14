using UnityEngine;

public class ToggleGameObjects : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject objectToDeactivate;

    public void ToggleObjects()
    {
        if (objectToActivate != null)
            objectToActivate.SetActive(true);

        if (objectToDeactivate != null)
            objectToDeactivate.SetActive(false);
    }
}