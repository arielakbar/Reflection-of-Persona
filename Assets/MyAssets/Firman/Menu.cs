using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Class Main Menu
public class Menu : MonoBehaviour
{
   
    //Fungsi Yang Dijalanka Ketika Kita Menekan Toombol Play
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Fungsi Yang Dijalanka Ketika Kita Menekan Toombol Quit
    public void QuitGame()
    {
        Application.Quit();
    }
}
