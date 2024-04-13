using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target;                // O objeto que a c�mera deve orbitar.
    public float rotationSpeed = 50.0f;     // Velocidade de rota��o ao redor do alvo.
    public float radius = 5.0f;             // Dist�ncia da c�mera at� o alvo.
    public float angle = 180f;              // Amplitude do arco de movimento em graus.
    public float height = 2.0f;             // Altura da c�mera em rela��o ao plano base do alvo.
    public float tilt = 10.0f;              // Inclina��o vertical da c�mera em graus.
    public float startDelay = 3.0f;         // Tempo de espera antes de come�ar a orbitar.
    public Vector3 finalPositionAfterOrbit = new Vector3(-0.00627984f, 1.999626f, -7.17f);  // Posi��o final ap�s a rota��o.
    public float smoothTransitionDuration = 2.0f;  // Dura��o da transi��o suave para a nova posi��o.

    private float currentAngle = 0.0f;      // �ngulo atual da c�mera.
    private float timer = 0.0f;             // Temporizador para controle do delay.
    private bool rotationCompleted = false; // Verifica se a rota��o foi completada.
    private Quaternion finalRotation;       // Rota��o final ap�s completar a �rbita.
    private float smoothTimer = 0f;         // Temporizador para a interpola��o suave.

    private void Update()
    {
        if (target == null)
            return;

        timer += Time.deltaTime;
        if (timer < startDelay)
            return;

        if (currentAngle < angle)
        {
            currentAngle += rotationSpeed * Time.deltaTime;
            currentAngle = Mathf.Clamp(currentAngle, 0, angle);

            float radianAngle = currentAngle * Mathf.Deg2Rad;
            Vector3 offset = new Vector3(Mathf.Sin(radianAngle), 0, Mathf.Cos(radianAngle)) * radius;
            transform.position = target.position + offset + Vector3.up * height;
            transform.LookAt(target.position + Vector3.up * tilt);
        }
        else if (!rotationCompleted)
        {
            rotationCompleted = true;  // Indica que a rota��o completou.
            finalRotation = transform.rotation;  // Armazena a rota��o final.
        }

        if (rotationCompleted)
        {
            if (smoothTimer < smoothTransitionDuration)
            {
                smoothTimer += Time.deltaTime;
                float lerpFactor = smoothTimer / smoothTransitionDuration;
                transform.position = Vector3.Lerp(transform.position, finalPositionAfterOrbit, lerpFactor);
                transform.rotation = finalRotation;  // Mant�m a rota��o constante.
            }
            else
            {
                transform.position = finalPositionAfterOrbit;  // Garante que a posi��o final � atingida.
            }
        }
    }
}