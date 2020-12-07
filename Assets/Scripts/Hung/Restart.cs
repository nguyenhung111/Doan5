using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public static bool isGameRestart = false;
    [SerializeField]
    public GameObject Restartmenu;
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Resumegame()
    {
        Restartmenu.SetActive(false);
        Time.timeScale = 1f;
        isGameRestart = false;
    }
    public void PauseGame()
    {
        Restartmenu.SetActive(true);
        Time.timeScale = 0f;
        isGameRestart = true;
    }
    public void LoadMenu()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoluongDan.Soluong = 50;
        SoluongBom.Soluong = 20;

    }
    public void QuitGame()
    {
        Application.Quit();
        
    }
}
