using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour

{
    // VARIABLES ////////////////////////////////////////////////////////////////
    public Vector3 rotationAngle = new Vector3(0, 0, 0);  // Variable p�blica para definir el �ngulo de rotaci�n
    public float rotationSpeed = 0.0f;  // Definir variable float (n�mero) para velocidad de rotaci�n de objeto

    // FUNCTIONS ////////////////////////////////////////////////////////////////
    void Update()
    {
        // Rotar el objeto de forma constante
        transform.Rotate(rotationSpeed * Time.deltaTime * rotationAngle);  // Realizar el transform.Rotate con rotationSpeed, Time.deltaTime y vector3Rotation para rotaci�n constante del objeto
    }
}
