using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartNewGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void GoToSettingsMenu(){
        SceneManager.LoadScene("SettingsMenu");
    }
    public void GoToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGame(){
        SceneManager.LoadScene("LoadGame");
    }

    public void QuitGame(){
        Application.Quit();
    }
    
}
