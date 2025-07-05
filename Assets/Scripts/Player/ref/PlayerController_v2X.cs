// IMPORT NAMESPACES
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController_v2X : MonoBehaviour
{
    // VARIABLES
    public float speed = 0;

    private Rigidbody rigidBody;

    private float movementX;
    private float movementY;

    private int count;  // Definir variable para contar (en numeros enteros)

    // FUNCTIONS
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();

        count = 0;  // Al iniciar, count sera de valor 0
        Debug.Log(count);
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


    // Funcion para recoger objetos con TAG
    private void OnTriggerEnter(Collider other)  // Funcion que se ejecuta cuando el Player colisiona y entra en el trigger de otro Objeto
    {


        if (other.gameObject.CompareTag("PickUp"))  // Definir condicional para comparar solo con TAG indicado
        {
            other.gameObject.SetActive(false);  // Establecer "False" para desactivar Objecto con el cual colisiono el Player
            Debug.Log("Picked Up");  //Mostrar Print en consola

            count = count + 1;  // Sumar el valor 1 a la variable count cada vez que se recoge un PickUp
            //count++;

            Debug.Log("Items recogidos: " + count);  // Mostrar en consola el valor actual de count
        }
    }

}
