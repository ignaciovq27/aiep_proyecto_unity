using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;  // A�adir clases y recursos de SceneManagment de Unity


public class SceneSelector : MonoBehaviour
{
    
    public string sceneName;  // Definir nombre de la escena a cambiar

    // Funci�n a llamar cuando el bot�n sea presionado por el Jugador
    public void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);  // Cargar la escena con el nombre indicado en el inspector
    }
}
