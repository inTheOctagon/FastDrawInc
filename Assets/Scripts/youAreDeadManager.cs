using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class youAreDeadManager : MonoBehaviour
{
    [SerializeField] GameObject firstText;
    [SerializeField] GameObject secondText;
    [SerializeField] GameObject thirdText;
    [SerializeField] GameObject tryAgainButton;
    [SerializeField] GameObject exitButton;
    [SerializeField] GameObject panelFadeIn;

    private void Awake()
    {

        firstText.GetComponent<Animator>().SetTrigger("FadeIn");
        secondText.GetComponent<Animator>().SetTrigger("FadeIn");
        thirdText.GetComponent<Animator>().SetTrigger("FadeIn");

        tryAgainButton.GetComponent<Animator>().SetTrigger("FadeIn");
        exitButton.GetComponent<Animator>().SetTrigger("FadeIn");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void tryAgainFunc()
    {
        StartCoroutine("tryAgainNumerator");
        

    }

    IEnumerator tryAgainNumerator()
    {
        if(GameObject.FindGameObjectWithTag("Clock Tower") != null)
        {
            GameObject.FindGameObjectWithTag("Clock Tower").GetComponent<ClockTowerManager>().background = false;
        }
        
        panelFadeIn.SetActive(true);
        panelFadeIn.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Main Menu");
    }

    public void exitFunc()
    {
        Application.Quit();
    }

}
