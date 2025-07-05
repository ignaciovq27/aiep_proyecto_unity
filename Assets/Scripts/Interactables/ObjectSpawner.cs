using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTA: USAR DE REFERENCIA ESTOS VALORES CON OBJETOS CREADOS EN ESCENA:

//pickupPrefab = Item_Prefab;               (prefab del objeto a instanciar)
//numberOfObjects = 10;                     (numero de objetos a instanciar)
//pickupGroup = Item_Group;                 (grupo vacio donde se instanciaran los objetos)
//basePlane = Base;                         (area donde se instanciaran los objetos)
//minDistanceBetweenPickups = 1.0f;         (distancia minima entre objetos)
//exclusionZoneRadius = 2.0f;               (radio de la zona de exclusion en el centro para evitar instancia sobre Player)
//borderMargin = 1.5f;                      (margen de distancia desde los bordes para evitar instancia en limites de area)

public class ObjectSpawner : MonoBehaviour
{

    public GameObject pickupPrefab;  // Variable tipo GameObject para definir el Prefab del objeto a instanciar
    public int numberOfObjects = 10;  // Definir N�mero de objetos a instanciar
    public GameObject pickupGroup;  // Grupo donde se instanciar�n los objetos
    public GameObject basePlane;  // Variable para definir �rea donde se instanciar�n los Objetos
    public float minDistanceBetweenPickups = 1.0f;  // Distancia m�nima entre objetos a instanciar
    public float exclusionZoneRadius = 2.0f;  // Radio de la zona de exclusi�n en el centro (para evitar instancia sobre Player)
    public float borderMargin = 1.0f;  // Margen de distancia desde los bordes (para evitar instancia en limites de �rea)
    void Start()
    {

        Vector3 planeScale = basePlane.transform.localScale;  // Obtener las dimensiones del �rea
        float planeWidth = planeScale.x * 1; // Definir Ancho del �rea
        float planeDepth = planeScale.z * 1; // Definir Alto del �rea

        // Calcular los l�mites del �rea en el espacio con el margen incluido
        float xMin = basePlane.transform.position.x - (planeWidth / 2) + borderMargin;
        float xMax = basePlane.transform.position.x + (planeWidth / 2) - borderMargin;
        float zMin = basePlane.transform.position.z - (planeDepth / 2) + borderMargin;
        float zMax = basePlane.transform.position.z + (planeDepth / 2) - borderMargin;
        float yPosition = basePlane.transform.position.y + 0.5f; // Definir distancia a elevar objeto a instanciar por encima del �rea


        List<Vector3> instantiatedObjects = new List<Vector3>();  // Lista para mantener las posiciones de los objetos instanciados

        for (int i = 0; i < numberOfObjects; i++)  // Instanciar los objetos dentro de los l�mites del �rea
        {
            Vector3 randomPosition;  // Indica una posici�n al azar en base a coordenadas de un Vector 3
            bool validPosition;  // Indicar un comprobador de si es posible instanciar o no el objeto en el lugar (bajo condiciones)

            do
            {
                float randomX = Random.Range(xMin, xMax);
                float randomZ = Random.Range(zMin, zMax);
                randomPosition = new Vector3(randomX, yPosition, randomZ);  // Se crea una posici�n al azar entre rangos para X y Z

                // Se verificar si la posici�n est� en la zona de exclusi�n central para poder instanciar el objeto
                float distanceToCenter = Vector3.Distance(new Vector3(basePlane.transform.position.x, yPosition, basePlane.transform.position.z), randomPosition);
                validPosition = distanceToCenter > exclusionZoneRadius;

                // Verificar si la posici�n est� demasiado cerca de otros pickups
                foreach (Vector3 pos in instantiatedObjects)
                {
                    if (Vector3.Distance(pos, randomPosition) < minDistanceBetweenPickups)
                    {
                        validPosition = false;  // Si no es una posici�n v�lida, se termina al ejcuci�n del c�digo y vuelve al ciclo
                        break;
                    }
                }
            }
            while (!validPosition);  // Si es una posici�n v�lida, entonces realiza la instancia del objeto

            // Instanciar el prefab en la posici�n aleatoria v�lida
            GameObject pickup = Instantiate(pickupPrefab, randomPosition, Quaternion.identity);

            // Asignar el pickup como hijo del objeto al que est� adjunto este script
            pickup.transform.parent = transform;

            // A�adir la posici�n a la lista de pickups instanciados
            instantiatedObjects.Add(randomPosition);
        }
    }
}