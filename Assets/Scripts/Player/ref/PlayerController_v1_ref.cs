// IMPORT NAMESPACES
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;  // Añadir namespace InputSystem

public class PlayerController_v1_ref : MonoBehaviour
{
    // VARIABLES
    public float speed = 20;  // Definir variable de velocidad de movimiento de Player
    public float jumpForce = 7f;  // Fuerza del salto
    private bool isGrounded = true;  // Controla si el jugador está en el suelo

    private Rigidbody rigidBody;  // Definir variable tipo Rigidbody

    private float movementX;  // Definir valor de movimiento horizontal X
    private float movementY;  // Definir valor de movimiento horizontal Y * Nota: Será usado como valor en eje Z


    // FUNCTIONS
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();  // Obtener Rigidbody asignado a objeto Player (en inspector)
    }

    void OnMove(InputValue movementValue)  // Función para obtener el valor de movimiento del jugador
    {
        Vector2 movementVector = movementValue.Get<Vector2>();  // Convertir el valor del input a un vector de 2 coordenadas para movimiento de player

        movementX = movementVector.x;  // Asignar valor de movimiento "movementX" en base a vector X de Player
        movementY = movementVector.y;  // Asignar valor de movimiento "movementY" en base a vector Y de Player
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);  // Crear nuevo vector de movimiento de 3 cordenadas ( eje Y vertical es 0)

        rigidBody.AddForce(movement * speed);  // Añadir fuerza a rigidbody del objeto en base a variables de Vector3 "movement" y valor de velocidad "speed"
    }

    void OnJump(InputValue jumpValue)  // Función para el salto usando Input System
    {
        // Solo saltar si está en el suelo
        if (isGrounded)
        {
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Si colisiona con el suelo, permitir saltar de nuevo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
