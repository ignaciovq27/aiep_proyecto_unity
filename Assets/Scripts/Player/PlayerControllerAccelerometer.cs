using UnityEngine;
using TMPro;

public class PlayerControllerAccelerometer : MonoBehaviour
{
    // Variables de movimiento
    public float speed = 10f;
    public float smoothness = 5f; // Suavizado del movimiento
    public float tiltThreshold = 0.1f; // Umbral mínimo para detectar inclinación

    // Referencias a componentes
    private Rigidbody rigidBody;
    private Vector3 currentAcceleration;
    private Vector3 targetAcceleration;

    // Variables del juego
    private int count;
    public TextMeshProUGUI textCount;
    public GameObject panelResults;
    public GameObject panelIntro;
    public GameObject audioObject;
    private AudioSource audioSource;

    // Control de inicio
    private bool canMove;
    public float delayStart = 2.0f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        count = 0;
        SetTextCount();

        if (audioObject != null)
        {
            audioSource = audioObject.GetComponent<AudioSource>();
        }

        if (panelIntro != null)
        {
            panelIntro.SetActive(true);
        }

        canMove = false;
        StartCoroutine(StartMovementAfterDelay(delayStart));
    }

    System.Collections.IEnumerator StartMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canMove = true;
    }

    void Update()
    {
        if (!canMove) return;

        // Obtener la aceleración del dispositivo
        Vector3 acceleration = Input.acceleration;

        // Ajustar la aceleración para el modo vertical
        // En modo vertical, usamos el eje X para movimiento horizontal y el eje Y para movimiento vertical
        targetAcceleration = new Vector3(
            acceleration.x, // Inclinación izquierda/derecha
            0f,
            acceleration.y // Inclinación adelante/atrás
        );

        // Suavizar el movimiento
        currentAcceleration = Vector3.Lerp(currentAcceleration, targetAcceleration, Time.deltaTime * smoothness);

        // Aplicar el movimiento solo si supera el umbral
        if (Mathf.Abs(currentAcceleration.x) > tiltThreshold || Mathf.Abs(currentAcceleration.z) > tiltThreshold)
        {
            Vector3 movement = new Vector3(currentAcceleration.x, 0.0f, currentAcceleration.z);
            rigidBody.AddForce(movement * speed);
        }
    }

    void SetTextCount()
    {
        if (textCount != null)
        {
            textCount.text = "Count: " + count.ToString();
        }

        if (count >= 3 && panelResults != null)
        {
            panelResults.SetActive(true);
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Picked Up");

            count++;
            Debug.Log("Items recogidos: " + count);
            SetTextCount();
        }
    }
} 