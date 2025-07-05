// IMPORT NAMESPACES
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;  // Añadir clases y recursos de Text Mesh Pro

public class PlayerController_v4_2 : MonoBehaviour
{
    // VARIABLES
    public float speed = 0;

    private Rigidbody rigidBody;
    private float movementX;
    private float movementY;

    private int count;

    public TextMeshProUGUI textCount; 
    public GameObject panelResults;  // Definir panel de resultados desde Canvas

    public GameObject audioObject;  // Definir el objeto que tiene el AudioSource y AudioClip
    private AudioSource audioSource;  // Definir el AudioSource del objeto

    //lógica de carga de materiales desde ejecución
    public Material nuevoMaterial;  // Definir nuevo material de Player
    public Material nuevoMaterialDesdeCarpeta;  // Definir nuevo material de Player

    private Renderer playerRenderer;  // Renderer del objeto Player para cambiar el material



    // FUNCTIONS
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        count = 0;

        SetTextCount();  // Al iniciar, se asigna llama a la función para asignar el valor de count

        // Set de audioObject
        audioSource = audioObject.GetComponent<AudioSource>();  // Al comenzar ejecución de programa, obtener componente AudioSource de objeto "audioObject"

        // Obtener el Renderer del objeto Player para cambiar su material
        playerRenderer = GetComponent<Renderer>();

        // Cargar el material desde Resources/Materiales/mimaterial
        nuevoMaterialDesdeCarpeta = Resources.Load<Material>("Player/Materials/Player_Smile_3");
    }


    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetTextCount()  // Nueva función para asignar variable count a texto de UI
    {
        textCount.text = "Count: " + count.ToString();  // Se asigna el valor de textCount a la UI textCount

        // Condicional para mostrar el panel de resultados
        if (count == 3)
        {
            // Display the win text.
            //panelResults.SetActive(true);

            // Reproducir sonido de audioObject
            //audioSource.Play();


            // Cambiar el material del Player al nuevo material
            if (playerRenderer != null && nuevoMaterial != null)
            {
                playerRenderer.material = nuevoMaterial;
            }
        }

        if (count == 4)
        {
            // Cambiar el material del Player al nuevo material
            if (playerRenderer != null && nuevoMaterialDesdeCarpeta != null)
            {
                playerRenderer.material = nuevoMaterialDesdeCarpeta;  // Asigna el material cargado desde Resources
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rigidBody.AddForce(movement * speed);
    }

    // Función para recoger objetos con TAG
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            Debug.Log("Picked Up");

            count = count + 1;

            Debug.Log("Items recogidos: " + count);
            SetTextCount();  // LLamar a funcion SetTextCount() para actualizar la información de count en texto TMP de Canvas
        }
    }

}
