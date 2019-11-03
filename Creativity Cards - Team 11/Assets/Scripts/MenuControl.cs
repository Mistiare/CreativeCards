using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject pnlCredits;

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
}
