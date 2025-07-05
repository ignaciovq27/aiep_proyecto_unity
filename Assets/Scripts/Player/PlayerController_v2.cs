// IMPORT NAMESPACES
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_v2 : MonoBehaviour
{
    // VARIABLES ///
    public float speed = 20;

    private int itemCount = 0;

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

    // FUNCIONES DE COLISION DEL PLAYER CON OTROS OBJETOS EN BASE A "TRIGGERS"
    void OnTriggerEnter(Collider other)  // Función de collision TRIGGER de Player al ENTRAR en contacto con objeto "other"
    {
        if (other.gameObject.CompareTag("Item"))  // Condición para definir la colisión con tag ITEM
        {
            // Debug.Log("COLISION ENTER: ITEM");  // Mostrar un PRINT en CONSOLA de la colisión
            other.gameObject.SetActive(false);  // Desactivar al objeto OTHER al colisionar

            //Contador de Item recogidos
            // itemCount = itemCount + 1;
            itemCount++;
            Debug.Log("⭐" + itemCount);

            // Destroy(other.gameObject, 1);  // Destruir el objeto OTHER al colisionar

        }
    }

    // void OnTriggerStay(Collider other)  // Función de collision TRIGGER de Player al MANTERSE en contacto con objeto "other"
    // {
    //     if (other.gameObject.CompareTag("Item"))  // Condición para definir la colisión con tag ITEM
    //     {
    //         Debug.Log("COLISION STAY: ITEM");  // Mostrar un PRINT en CONSOLA de la colisión

    //     }
    // }

    // void OnTriggerExit(Collider other)  // Función de collision TRIGGER de Player al SALIR del contacto con objeto "other"
    // {
    //     if (other.gameObject.CompareTag("Item"))  // Condición para definir la colisión con tag ITEM
    //     {
    //         Debug.Log("COLISION EXIT: ITEM");  // Mostrar un PRINT en CONSOLA de la colisión
    //         // other.gameObject.SetActive(false);  // Desactivar al objeto OTHER al colisionar
    //     }
    // }
    // void OnCollisionEnter(Collision collision)  // Función de collision COLLISION de Player con objeto "other"
    // {
    //     if (collision.gameObject.CompareTag("Wall"))  // Condición para definir la colisión con tag WALL
    //     {
    //         Debug.Log("COLISION CON: WALL");  // Mostrar un PRINT en CONSOLA de la colisión
    //     }
    // }

}









