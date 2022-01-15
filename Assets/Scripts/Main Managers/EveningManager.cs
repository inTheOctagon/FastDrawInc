using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveningManager : MonoBehaviour
{

    [Header("The Evening of The Duel #1")]
    [SerializeField] GameObject theEveningText;
   
    [Header("Main Options Panel Variables")]
    [SerializeField] GameObject optionsFirstBit;
    [SerializeField] GameObject optionsSecondBit;
    bool mainSecondBitCon = false;
    bool mainOptionsCon = false;
    [SerializeField] GameObject mainPressAnyKeyText;
    [SerializeField] GameObject buttonOne;
    [SerializeField] GameObject buttonTwo;

    // optionOnePanel
    [SerializeField] GameObject optionOnePanel;
    bool pathOneSecondBitCon = false;
    [SerializeField] GameObject pathOneFirstBit;
    [SerializeField] GameObject pathOneSecondBit;
    [SerializeField] GameObject pathOnePressAnyKeyText;
    bool pathOneExit = false;
    // optionTwoPanel
    [SerializeField] GameObject optionTwoPanel;
    bool pathTwoSecondBitCon = false;
    [SerializeField] GameObject pathTwoFirstBit;
    [SerializeField] GameObject pathTwoSecondBit;
    [SerializeField] GameObject pathTwoPressAnyKeyText;
    bool pathTwoExit = false;
    [Header("Sound Variables")]
    public bool firstEvening = false;
    [SerializeField] AudioClip doorShutClip;
    GameObject clockTower;
    [SerializeField] GameObject exteriorSource;
    private bool exteriorSourceBool = false;
    

    [Header("Tournament Manager")]
    [SerializeField] GameObject tournamentManager;
    
    

    private void Awake()
    {
        StartCoroutine("OptionsPanelSetter");
        clockTower = GameObject.FindGameObjectWithTag("Clock Tower");
        //clockTower.GetComponent<ClockTowerManager>().background = false;
        
    }

    private void Update()
    {

        
        

        
        if (Input.anyKeyDown && mainSecondBitCon)
        {
            optionsSecondBit.GetComponent<Animator>().SetTrigger("FadeIn");
            mainSecondBitCon = false;
            mainOptionsCon = true;
        }
        else if (Input.anyKeyDown && !mainSecondBitCon && mainOptionsCon)
        {
            mainPressAnyKeyText.GetComponent<Animator>().SetTrigger("FadeOut");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            buttonOne.SetActive(true);
            buttonTwo.SetActive(true);
            buttonOne.GetComponent<Animator>().speed = 1;
            buttonTwo.GetComponent<Animator>().speed = 1;
            buttonOne.GetComponent<Animator>().SetTrigger("FadeIn");
            buttonTwo.GetComponent<Animator>().SetTrigger("FadeIn");

            mainOptionsCon = false;
        }
        else if (Input.anyKeyDown && pathOneSecondBitCon)
        {
            pathOneSecondBitCon = false;
            pathOneSecondBit.GetComponent<Animator>().SetTrigger("FadeIn");
            pathOneExit = true;
        }
        else if(Input.anyKeyDown && pathTwoSecondBitCon)
        {
            pathTwoSecondBitCon = false;
            pathTwoSecondBit.GetComponent<Animator>().SetTrigger("FadeIn");
            pathTwoExit = true;
        }
        
        else if(Input.anyKeyDown && pathOneExit)
        {
            StartCoroutine("pathOneExitNumerator");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

        }
        else if(Input.anyKeyDown && pathTwoExit)
        {
            StartCoroutine("pathTwoExitNumerator");
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }


        if (exteriorSourceBool)
        {
            exteriorSource.GetComponent<AudioSource>().volume = Mathf.MoveTowards(exteriorSource.GetComponent<AudioSource>().volume, 0.3f, 0.1f * Time.deltaTime);
        }
        else if (!exteriorSourceBool && exteriorSource.GetComponent<AudioSource>().volume > 0)
        {
            exteriorSource.GetComponent<AudioSource>().volume = Mathf.MoveTowards(exteriorSource.GetComponent<AudioSource>().volume, 0, 0.1f * Time.deltaTime);
        }
        else return;



    }

    

    IEnumerator OptionsPanelSetter()
    {
        
        yield return new WaitForSeconds(2);
        exteriorSourceBool = true;
        exteriorSource.GetComponent<AudioSource>().Play(0);
        yield return new WaitForSeconds(2);
        theEveningText.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(3f);
        theEveningText.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(3f);
        if (firstEvening) GetComponent<AudioSource>().PlayOneShot(doorShutClip);
        optionsFirstBit.GetComponent<Animator>().SetTrigger("FadeIn");
        mainPressAnyKeyText.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(1);
        mainSecondBitCon = true;
    }

    // evening one options

    public void eveningOneOptionOne()
    {
        optionOnePanel.SetActive(true);
        pathOneSecondBitCon = true;
        pathOneFirstBit.GetComponent<Animator>().SetTrigger("FadeIn");
        pathOnePressAnyKeyText.GetComponent<Animator>().SetTrigger("FadeIn");
        ValueManager.newBulletSize = ValueManager.newBulletSize - ValueManager.newBulletSize / 10;

    }

    public void eveningOneoptionTwo()
    {
        optionTwoPanel.SetActive(true);
        pathTwoSecondBitCon = true;
        pathTwoFirstBit.GetComponent<Animator>().SetTrigger("FadeIn");
        pathTwoPressAnyKeyText.GetComponent<Animator>().SetTrigger("FadeIn");
        ValueManager.newBulletSize = ValueManager.newBulletSize - ValueManager.newBulletSize / 10;
    }

    // evening two options

    public void eveningTwoOptionOne()
    {
        optionOnePanel.SetActive(true);
        pathOneSecondBitCon = true;
        pathOneFirstBit.GetComponent<Animator>().SetTrigger("FadeIn");
        pathOnePressAnyKeyText.GetComponent<Animator>().SetTrigger("FadeIn");
        ValueManager.newTimerValue = ValueManager.newTimerValue * 0.1f + ValueManager.newTimerValue;

    }

    public void eveningTwooptionTwo()
    {
        optionTwoPanel.SetActive(true);
        pathTwoSecondBitCon = true;
        pathTwoFirstBit.GetComponent<Animator>().SetTrigger("FadeIn");
        pathTwoPressAnyKeyText.GetComponent<Animator>().SetTrigger("FadeIn");
        
    }

    // evening three options

    public void eveningThreeOptionOne()
    {
        optionOnePanel.SetActive(true);
        pathOneSecondBitCon = true;
        pathOneFirstBit.GetComponent<Animator>().SetTrigger("FadeIn");
        pathOnePressAnyKeyText.GetComponent<Animator>().SetTrigger("FadeIn");
        

    }

    public void eveningThreeoptionTwo()
    {
        optionTwoPanel.SetActive(true);
        pathTwoSecondBitCon = true;
        pathTwoFirstBit.GetComponent<Animator>().SetTrigger("FadeIn");
        pathTwoPressAnyKeyText.GetComponent<Animator>().SetTrigger("FadeIn");

    }


    IEnumerator pathOneExitNumerator()
    {
        pathOneFirstBit.GetComponent<Animator>().SetTrigger("FadeOut");
        pathOneSecondBit.GetComponent<Animator>().SetTrigger("FadeOut");
        pathOnePressAnyKeyText.GetComponent<Animator>().SetTrigger("FadeOut");
        exteriorSourceBool = false;
        yield return new WaitForSeconds(3);
        Destroy(clockTower);
        tournamentManager.GetComponent<TournamentManager>().nextScene();
    }

    IEnumerator pathTwoExitNumerator()
    {
        pathTwoFirstBit.GetComponent<Animator>().SetTrigger("FadeOut");
        pathTwoSecondBit.GetComponent<Animator>().SetTrigger("FadeOut");
        pathTwoPressAnyKeyText.GetComponent<Animator>().SetTrigger("FadeOut");
        exteriorSourceBool = false;
        yield return new WaitForSeconds(3);
        Destroy(clockTower);
        tournamentManager.GetComponent<TournamentManager>().nextScene();
    }

}
