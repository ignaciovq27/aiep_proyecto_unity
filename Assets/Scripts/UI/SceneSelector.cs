using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;  // Añadir clases y recursos de SceneManagment de Unity


public class SceneSelector : MonoBehaviour
{
    
    public string sceneName;  // Definir nombre de la escena a cambiar

    // Función a llamar cuando el botón sea presionado por el Jugador
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);  // Cargar la escena con el nombre indicado en el inspector
    }
}
