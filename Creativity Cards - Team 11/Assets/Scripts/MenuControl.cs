using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject pnlCredits;
    public GameObject pnlPaused;
    private bool IsPaused = false;

    public void Play()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Quit()
    {
        Debug.Log("Quit Successful");
        //Application.Quit();
    }
    
    public void ShowCredits()
    {
        pnlCredits.SetActive(true);
    }

    public void HideCredits()
    {
        pnlCredits.SetActive(false);
    }

    void Update()
    {
        //Don't Hardcode Billy >:(
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (IsPaused == true)
            {
                pnlPaused.SetActive(false);
                Time.timeScale = 1;
            }
            if (IsPaused == false)
            {
                pnlPaused.SetActive(true);
                Time.timeScale = 0;
            }

            IsPaused = !IsPaused;
        }
    }
}
