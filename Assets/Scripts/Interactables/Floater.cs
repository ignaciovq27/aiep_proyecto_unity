using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{
    private Vector3 startPosition;  // Definir variable para obtener posicion inicial de Objeto
    public float floatSpeed = 0f;  // Definir variable publica tipo float (numero) para establecer Velocidad de la flotacion del objeto
    public float floatAmplitude = 0f;  // Definir variable publica tipo float (numero) para establecer Amplitud de la flotacion del objeto

    void Start()
    {
        startPosition = transform.position;  // Obtener la posicion inicial del objeto (para calculo posterior de flotacion) en los 3 ejes
    }

    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;  // Calcular la nueva posicion para el efecto de flotacion en eje Y

        transform.position = new Vector3(startPosition.x, newY, startPosition.z);  // Aplicar la nueva posicion al objeto de forma constante
    }
}
