using System.Collections;  // AHH esto sirve para...
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //VARIABLES ////////////////////////
    public GameObject player;  // Definir variable p�blica tipo GameObject "player" para referenciar el objeto Player desde inspector
    public Vector3 offset;  // Definir variable tipo Vector3 para establecer distancia de posici�n de seguimiento entre Camera y Player

    //FUNCIONES
    void LateUpdate()  // Funci�n para actualizar posici�n luego de la ejecuci�n de todas las funciones Updates
    {
        transform.position = player.transform.position + offset;  // Actualizar y Mantener posici�n de objeto Camera en base a posici�n de player y offset cada frame
    }
}
