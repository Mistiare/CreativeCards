using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public GameObject pnlCredits;
    public GameObject pnlPaused;
    private bool IsPaused = false;

    [SerializeField] Image BlackScreen;

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
        float alpha = 0;
        while (BlackScreen.color.a < 1)
        {         
            alpha += 0.01f;
            print(alpha);

            BlackScreen.color = new Vector4(BlackScreen.color.r, BlackScreen.color.g, BlackScreen.color.b, alpha);
            yield return new WaitForEndOfFrame();
        }

        if (BlackScreen.color.a > 1) { SceneManager.LoadScene(1); }

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
