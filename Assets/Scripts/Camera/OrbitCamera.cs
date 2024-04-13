using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    public Transform target;                // O objeto que a câmera deve orbitar.
    public float rotationSpeed = 50.0f;     // Velocidade de rotação ao redor do alvo.
    public float radius = 5.0f;             // Distância da câmera até o alvo.
    public float angle = 180f;              // Amplitude do arco de movimento em graus.
    public float height = 2.0f;             // Altura da câmera em relação ao plano base do alvo.
    public float tilt = 10.0f;              // Inclinação vertical da câmera em graus.
    public float startDelay = 3.0f;         // Tempo de espera antes de começar a orbitar.
    public Vector3 finalPositionAfterOrbit = new Vector3(-0.00627984f, 1.999626f, -7.17f);  // Posição final após a rotação.
    public float smoothTransitionDuration = 2.0f;  // Duração da transição suave para a nova posição.

    private float currentAngle = 0.0f;      // Ângulo atual da câmera.
    private float timer = 0.0f;             // Temporizador para controle do delay.
    private bool rotationCompleted = false; // Verifica se a rotação foi completada.
    private Quaternion finalRotation;       // Rotação final após completar a órbita.
    private float smoothTimer = 0f;         // Temporizador para a interpolação suave.

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
            rotationCompleted = true;  // Indica que a rotação completou.
            finalRotation = transform.rotation;  // Armazena a rotação final.
        }

        if (rotationCompleted)
        {
            if (smoothTimer < smoothTransitionDuration)
            {
                smoothTimer += Time.deltaTime;
                float lerpFactor = smoothTimer / smoothTransitionDuration;
                transform.position = Vector3.Lerp(transform.position, finalPositionAfterOrbit, lerpFactor);
                transform.rotation = finalRotation;  // Mantém a rotação constante.
            }
            else
            {
                transform.position = finalPositionAfterOrbit;  // Garante que a posição final é atingida.
            }
        }
    }
}