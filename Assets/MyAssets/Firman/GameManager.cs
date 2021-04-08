using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Class Yang Mengatur Sebagian Besar Fitur Game
public class GameManager : MonoBehaviour
{

    public bool isPaused;
    private Rigidbody2D rb;
    public Transform respawnPosition;
    private bool died = false;
    public GameObject gameOverUi;
    public GameObject levelCompleteUi;
    public GameObject pauseUI;
    
    

    //Fungsi Disaat Player Mati
    public void GameOver()
    {
        if(died==false)
        {
            gameOverUi.SetActive(true);
            died = true;
            Time.timeScale = 0f;
        }
     
    }

    //Fungsi  Untuk Load Level Selanjutnya
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Fungsi Menampilkan UI Level Comlete
    public void LevelComplete()
    {
        levelCompleteUi.SetActive(true);  
    }

    //Fungsi Untuk Respawn Disaat Player Mati ke tempat yang sudah Ditentukan
    public  void Respawn(Rigidbody2D col)
    {
        GameObject.Find("Player").GetComponent<movement>().enabled = true;
        gameOverUi.SetActive(false);
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        col.transform.position = respawnPosition.position;
        died = false; 

    }
    //Fungsi Menuju Main Menu
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    //Fungsi Untuk Mengulang Level Dari Awal
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //GameObject.Find("Body").GetComponent<movement>().enabled = true;
        pauseUI.SetActive(false);
        

    }
    //Fungsi Untuk Pause Game
    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }
    //Fungsi Untuk Resume Game
    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }


}
