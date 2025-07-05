// IMPORT NAMESPACES
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_v1 : MonoBehaviour
{
    // VARIABLES ///
    public float speed = 20;  // Definir variable de velocidad de movimiento de Player

    // MOVIMIENTO DEL PLAYER 
    private Rigidbody rigidBody;  // Definir variable tipo Rigidbody
    private float movementX;  // Definir valor de movimiento horizontal X
    private float movementY;  // Definir valor de movimiento horizontal Y * Nota: Será usado como valor en eje Z

    // FUNCTIONS  ///
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();  // Obtener Rigidbody asignado a objeto Player (en inspector)
    }

    void OnMove(InputValue movementValue)  // Función automática de Unity para obtener el valor de movimiento del jugador desde el Input System
    {
        Vector2 movementVector = movementValue.Get<Vector2>();  // Convertir el valor del input a un vector de 2 coordenadas para movimiento de player

        movementX = movementVector.x;  // Asignar valor de movimiento "movementX" en base a vector X de Player
        movementY = movementVector.y;  // Asignar valor de movimiento "movementY" en base a vector Z de Player
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);  // Crear nuevo vector de movimiento de 3 cordenadas ( eje Y vertical es 0)

        rigidBody.AddForce(movement * speed);  // Añadir fuerza a rigidbody del objeto en base a variables de Vector3 "movement" y valor de velocidad "speed"
    }
}
