using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public static bool isGamePause = false;
    [SerializeField] 
    public GameObject pasuemenu;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isGamePause)
            {
                Resumegame();
            }else
            {
                PauseGame();
            }
        }
    }
    public void Resumegame()
    {
        pasuemenu.SetActive(false);
        Time.timeScale = 1f;
        isGamePause = false;
    }
    public void PauseGame()
    {
        pasuemenu.SetActive(true);
        Time.timeScale = 0f;
        isGamePause = true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        SoluongDan.Soluong = 120;
        SoluongBom.Soluong = 30;

    }
    public void QutiGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
