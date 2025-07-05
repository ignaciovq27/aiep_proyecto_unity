using UnityEngine;

public class test : MonoBehaviour
{
    // Sejecuta 1 sola vez antes de Start
    void Awake()
    {
        Debug.Log("AWAKE");
    }

    // Se ejecuta 1 sola vez al iniciar el juego, antes de Update.
    void Start()
    {
        Debug.Log("START");
    }

    // Se ejecuta para calculos de fisicas
    void FixedUpdate()
    {
        Debug.Log("FIXED UPDATE");
    }

    // Se ejecuta 1 vez por frame de ejecución del juego.
    void Update()
    {
        Debug.Log("UPDATE");
    }

    // Se ejecuta al final de todo el comportamiento de Update
    void LateUpdate()
    {
        Debug.Log("LATE UPDATE");
    }
}