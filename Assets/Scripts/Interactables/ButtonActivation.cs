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
    private Vector3 doorStartLocalPosition;  // Almacenar la posici�n inicial local de door
    private Vector3 doorTargetLocalPosition;  // Almacenar la posici�n objetivo local de door
    public Vector3 doorMoveOffset;  // Definir Vector 3 para determinar Posici�n desplazamiento de la door
    public float doorMoveSpeed = 0.0f;  // Definir Velocidad del movimiento de la puerta
    private bool doorActivation = false;  // Definir variable condicional de acci�n de bot�n

    public GameObject audioObject;  // Definir el objeto que tiene el AudioSource y AudioClip
    private AudioSource audioSource;  // Definir el AudioSource del objeto


    void Start()
    {
        // Al iniciar ejecuci�n de juego...
        doorStartLocalPosition = door.transform.localPosition;  // Almacenar la posici�n inicial local de door en variable
        doorTargetLocalPosition = doorStartLocalPosition + doorMoveOffset;  // Calcular la posici�n objetivo local de door
        buttonAnimator = gameObject.GetComponent<Animator>();  // Obtener el componente Animator del objeto door
        buttonCollider = gameObject.GetComponent<Collider>();  // Obtener el componente Animator del objeto door

        audioSource = audioObject.GetComponent<AudioSource>();  // Al comenzar ejecuci�n de programa, obtener componente AudioSource de objeto "audioObject"
    }

    void FixedUpdate()
    {
        if (doorActivation)  // Si se completa la condici�n (de activar door)
        {
            MoveDoor();  // Llamar a funci�n MoveDoor que realiza la acci�n
        }
    }

    // Funci�n para recoger objetos con TAG
    private void OnTriggerEnter(Collider other)
    {
        // Condicional de Door
        if (other.gameObject.CompareTag("Player"))  // Comparar colisi�n  de objeto "Button" con "Player"
        {
            doorActivation = true;  // Se define condici�n de activaci�n a true
            DisableChildColliders(); // Desactivar los colliders de los hijos de door
            buttonAnimator.SetTrigger("ON");  // Activar la animaci�n con el trigger "ON" de Button
            buttonCollider.enabled = false;

            audioSource.Play();  // Se reproduce audio desde componente audioSource del objeto asignado en "audioObject"
        }
    }

    // Funci�n de acci�n de movimiento de door
    void MoveDoor()  
    {
        if (Vector3.Distance(door.transform.localPosition, doorTargetLocalPosition) > 0.01f)  // Condici�n para comprobar posici�n actual de puerta frente a posici�n deseada en Vector doorTargetLocalPosition
        {
            door.transform.localPosition = Vector3.MoveTowards(door.transform.localPosition, doorTargetLocalPosition, doorMoveSpeed * Time.deltaTime);  // Desplazamiento de door bajo parametros Vector3 de forma constante, por medio de la funci�n FixedUpdate.
        }
        else
        {
            doorActivation = false; // Detener el movimiento de la puerta una vez que alcanza la posici�n indicada en doorTargetLocalPosition
            door.SetActive(false); // Desactivar el objeto door al llegar a la posici�n indicada

        }
    }

    void DisableChildColliders()  // Funci�n para desactivar los colliders de los hijos del objeto Door
    {
        Collider[] childColliders = door.GetComponentsInChildren<Collider>();
        foreach (Collider collider in childColliders)
        {
            collider.enabled = false;  // Por cada collider de hijo que encuentre en el objeto, los desactivar�.
        }
    }
}
