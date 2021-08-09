using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Loads the maze scene when the Play button is pressed
    /// </summary>
    public void PlayMaze(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    /// <summary>
    /// Closes game window when Quit button is pressed
    /// </summary>
    public void QuitMaze(){
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
