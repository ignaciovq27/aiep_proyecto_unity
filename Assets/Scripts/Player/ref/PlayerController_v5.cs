// IMPORT NAMESPACES
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;  // Añadir clases y recursos de Text Mesh Pro

public class PlayerController_v5 : MonoBehaviour
{
    // VARIABLES
    public float speed = 0;

    private Rigidbody rigidBody;
    private float movementX;
    private float movementY;

    private int count;

    public TextMeshProUGUI textCount;
    public GameObject panelResults;  // Definir panel de resultados desde Canvas
    public GameObject panelIntro;  // Definir panel de resultados desde Canvas

    public GameObject audioObject;  // Definir el objeto que tiene el AudioSource y AudioClip
    private AudioSource audioSource;  // Definir el AudioSource del objeto

    private bool canMove;  // Variable para controlar si el jugador puede moverse
    public float delayStart = 2.0f;  // Tiempo de retraso antes de que el jugador pueda moverse


    // FUNCTIONS
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        count = 0;

        SetTextCount();  // Al iniciar, se asigna llama a la funci�n para asignar el valor de count

        // Set de audioObject
        audioSource = audioObject.GetComponent<AudioSource>();  // Al comenzar ejecucion de programa, obtener componente AudioSource de objeto "audioObject"

        panelIntro.SetActive(true);

        canMove = false;  // Inicialmente el jugador no puede moverse

        StartCoroutine(StartMovementAfterDelay(delayStart));  // Iniciar la corrutina para permitir el movimiento despu�s de un retraso
    }

    IEnumerator StartMovementAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canMove = true;  // Permitir que el jugador se mueva despu�s del retraso
    }

    void OnMove(InputValue movementValue)
    {
        if (canMove)  // Solo actualizar los valores de movimiento si el jugador puede moverse
        {
            Vector2 movementVector = movementValue.Get<Vector2>();

            movementX = movementVector.x;
            movementY = movementVector.y;
        }
    }

    void SetTextCount()  // Nueva funcion para asignar variable count a texto de UI
    {
        textCount.text = "Count: " + count.ToString();  // Se asigna el valor de textCount a la UI textCount

        // Condicional para mostrar el panel de resultados
        if (count == 3)
        {
            // Display the win text.
            panelResults.SetActive(true);

            // Reproducir sonido de audioObject
            audioSource.Play();
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rigidBody.AddForce(movement * speed);
    }

    // Funcion para recoger objetos con TAG
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Picked Up");

            count = count + 1;

            Debug.Log("Items recogidos: " + count);
            SetTextCount();  // LLamar a funcion SetTextCount() para actualizar la informacion de count en texto TMP de Canvas
        }
    }

}
