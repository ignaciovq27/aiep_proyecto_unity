using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivation : MonoBehaviour
{
    // Variables de Button
    private Animator buttonAnimator;  // Definir variable para el Animator de Button
    private Collider buttonCollider;  // Definir variable para el Collider de Button

    // Variables de Door
    public GameObject door;  // Definir variable para utilizar el Animator de un GameObject.
    private Vector3 doorStartLocalPosition;  // Almacenar la posición inicial local de door
    private Vector3 doorTargetLocalPosition;  // Almacenar la posición objetivo local de door
    public Vector3 doorMoveOffset;  // Definir Vector 3 para determinar Posición desplazamiento de la door
    public float doorMoveSpeed = 0.0f;  // Definir Velocidad del movimiento de la puerta
    private bool doorActivation = false;  // Definir variable condicional de acción de botón

    public GameObject audioObject;  // Definir el objeto que tiene el AudioSource y AudioClip
    private AudioSource audioSource;  // Definir el AudioSource del objeto


    void Start()
    {
        // Al iniciar ejecución de juego...
        doorStartLocalPosition = door.transform.localPosition;  // Almacenar la posición inicial local de door en variable
        doorTargetLocalPosition = doorStartLocalPosition + doorMoveOffset;  // Calcular la posición objetivo local de door
        buttonAnimator = gameObject.GetComponent<Animator>();  // Obtener el componente Animator del objeto door
        buttonCollider = gameObject.GetComponent<Collider>();  // Obtener el componente Animator del objeto door

        audioSource = audioObject.GetComponent<AudioSource>();  // Al comenzar ejecución de programa, obtener componente AudioSource de objeto "audioObject"
    }

    void FixedUpdate()
    {
        if (doorActivation)  // Si se completa la condición (de activar door)
        {
            MoveDoor();  // Llamar a función MoveDoor que realiza la acción
        }
    }

    // Función para recoger objetos con TAG
    private void OnTriggerEnter(Collider other)
    {
        // Condicional de Door
        if (other.gameObject.CompareTag("Player"))  // Comparar colisión  de objeto "Button" con "Player"
        {
            doorActivation = true;  // Se define condición de activación a true
            DisableChildColliders(); // Desactivar los colliders de los hijos de door
            buttonAnimator.SetTrigger("ON");  // Activar la animación con el trigger "ON" de Button
            buttonCollider.enabled = false;

            audioSource.Play();  // Se reproduce audio desde componente audioSource del objeto asignado en "audioObject"
        }
    }

    // Función de acción de movimiento de door
    void MoveDoor()  
    {
        if (Vector3.Distance(door.transform.localPosition, doorTargetLocalPosition) > 0.01f)  // Condición para comprobar posición actual de puerta frente a posición deseada en Vector doorTargetLocalPosition
        {
            door.transform.localPosition = Vector3.MoveTowards(door.transform.localPosition, doorTargetLocalPosition, doorMoveSpeed * Time.deltaTime);  // Desplazamiento de door bajo parametros Vector3 de forma constante, por medio de la función FixedUpdate.
        }
        else
        {
            doorActivation = false; // Detener el movimiento de la puerta una vez que alcanza la posición indicada en doorTargetLocalPosition
            door.SetActive(false); // Desactivar el objeto door al llegar a la posición indicada

        }
    }

    void DisableChildColliders()  // Función para desactivar los colliders de los hijos del objeto Door
    {
        Collider[] childColliders = door.GetComponentsInChildren<Collider>();
        foreach (Collider collider in childColliders)
        {
            collider.enabled = false;  // Por cada collider de hijo que encuentre en el objeto, los desactivará.
        }
    }
}
