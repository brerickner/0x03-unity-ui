using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

    }
    
    /// <summary>
    /// Loads the maze scene when the Play button is pressed
    /// </summary>
    public void PlayMaze(){
        SceneManager.LoadScene(0);
    }
}
