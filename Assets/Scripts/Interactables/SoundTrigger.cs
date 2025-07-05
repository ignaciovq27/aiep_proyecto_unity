using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public GameObject audioObject;  // Definir el objeto que tiene el AudioSource y AudioClip
    private AudioSource audioSource;  // Definir el AudioSource del objeto

    void Start()
    {
        audioSource = audioObject.GetComponent<AudioSource>();  // Al comenzar ejecuci�n de programa, obtener componente AudioSource de objeto "audioObject"
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Comparar colisi�n con Tag "Player" para realizar la acci�n de reproducir audio
        {
                audioSource.Play();  // Se reproduce audio desde componente audioSource del objeto asignado en "audioObject"
        }
    }
}