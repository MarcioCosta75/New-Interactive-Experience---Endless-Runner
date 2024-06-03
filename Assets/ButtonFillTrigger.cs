using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFillTrigger : MonoBehaviour
{
    public Image fillImage;
    public float fillTime = 2.0f;
    private float currentFill = 0.0f;
    private bool isFilling = false;

    private void Update()
    {
        if (isFilling)
        {
            currentFill += Time.deltaTime / fillTime;
            if (fillImage != null)
            {
                fillImage.fillAmount = currentFill;
            }

            if (currentFill >= 1.0f)
            {
                isFilling = false;
                ExecuteButtonClick();
                ResetFill();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interactive"))
        {
            isFilling = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Interactive"))
        {
            isFilling = false;
            ResetFill();
        }
    }

    private void ResetFill()
    {
        currentFill = 0.0f;
        if (fillImage != null)
        {
            fillImage.fillAmount = 0.0f;
        }
    }

    private void ExecuteButtonClick()
    {
        // Simula o clique do botão
        Button button = fillImage.GetComponentInParent<Button>();
        if (button != null)
        {
            button.onClick.Invoke();
        }
    }
}