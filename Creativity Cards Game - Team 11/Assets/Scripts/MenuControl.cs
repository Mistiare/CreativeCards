using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject pnlCredits;
    public GameObject pnlPaused;
    private bool IsPaused = false;

    [SerializeField] CanvasGroup BlackScreen;

    public void StartGame()
    {
        StartCoroutine(FadeInScene());
        Debug.Log("Coroutine Started");
    }

    public void Quit()
    {
        Debug.Log("Quit Successful");
        Application.Quit();
    }
    
    public void ShowCredits()
    {
        pnlCredits.SetActive(true);
    }

    public void HideCredits()
    {
        pnlCredits.SetActive(false);
    }

    IEnumerator FadeInScene()
    {
        while (BlackScreen.alpha < 1)
        {
            BlackScreen.alpha += 0.4f * Time.deltaTime;
            yield return null;
        }

        if (BlackScreen.alpha == 1) { SceneManager.LoadScene(1); }

        yield return null;
    }

    void Update()
    {
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
