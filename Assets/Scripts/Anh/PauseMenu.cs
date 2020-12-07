using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool pause = false ;
    public GameObject pauseMenu;

    private bool isMuted;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);

        isMuted = PlayerPrefs.GetInt("MUTED") == 1;
        AudioListener.pause = isMuted;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = !pause;
        }

        if (pause)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if(pause == false)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
    
    public void ReSume()
    {
        pause = false;
    }
    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void MuteAudio()
    {
        isMuted = !isMuted;
        AudioListener.pause = isMuted;
        PlayerPrefs.SetInt("MUTED", isMuted ? 1 : 0);
    }
}
