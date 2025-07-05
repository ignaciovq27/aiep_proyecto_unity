using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
        // Salir del juego
        Application.Quit();

        // Solo para el editor de Unity (opcional, para que se vea el efecto al probar en el editor)
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
