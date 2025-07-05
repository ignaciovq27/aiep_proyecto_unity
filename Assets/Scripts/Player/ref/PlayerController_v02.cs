// IMPORT NAMESPACES
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController_v02 : MonoBehaviour
{
    // VARIABLES ///
    public float speed = 20;

    private int itemsCount;  // Definir variable para contar items

    // MOVIMIENTO DEL PLAYER 
    private Rigidbody rigidBody;
    private float movementX;
    private float movementY;

    // FUNCTIONS  ///
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rigidBody.AddForce(movement * speed);
    }

    // FUNCIONES DE COLISIONES CON TRIGGERS ///
    void OnTriggerEnter(Collider other)  // Funcion que se ejecuta cuando el Player colisiona y entra en el trigger de otro Objeto
    {
        if (other.gameObject.CompareTag("Item"))  // Si el objeto que colisiona con el Player tiene la etiqueta "Item"
        {
            other.gameObject.SetActive(false);  // Desactivar el objeto
            itemsCount++;  // Incrementar el contador de items +1
            Debug.Log("Collision: Item");  // Imprimir en consola el mensaje de colision
            Debug.Log("Items collected: " + itemsCount);  // Imprimir en consola el mensaje de items colectados
        }

        if (other.gameObject.CompareTag("Wall"))  // Si el objeto que colisiona con el Player tiene la etiqueta "Wall"
        {
            Debug.Log("Collision: Wall");  // Imprimir en consola el mensaje de colision
        }
    }

    // FUNCIONES DE COLISIONES CON COLLIDERS ///

    // void OnTriggerExit(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Item"))
    //     {
    //         Debug.Log("Exit: Item");
    //     }
    // }

    // void OnTriggerStay(Collider other)
    // {
    //     if (other.gameObject.CompareTag("Item"))
    //     {
    //         Debug.Log("Stay: Item");
    //     }
    // }

    // void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Wall"))
    //     {
    //         Debug.Log("Collision: Wall");
    //     }
    // }

    // void OnCollisionExit(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Wall"))
    //     {
    //         Debug.Log("Exit: Wall");
    //     }
    // }

    // void OnCollisionStay(Collision collision)
    // {
    //     if (collision.gameObject.CompareTag("Wall"))
    //     {
    //         Debug.Log("Stay: Wall");
    //     }
    // }
}





