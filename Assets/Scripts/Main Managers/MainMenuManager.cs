using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [Header("Main Menu Variables")]
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject mainMenuImage;
    [SerializeField] GameObject mainMenuTitle;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject exitButton;

    [SerializeField] GameObject startFadeInPanel;
    
    [SerializeField] GameObject pressAnyKey;
    [SerializeField] GameObject firstBitText;
    [SerializeField] GameObject secondBitText;
    [SerializeField] GameObject thirdBitText;

    [SerializeField] GameObject streetSoundSource;
    private bool streetSoundSourceBool;

    [SerializeField] GameObject officeSoundSource;
    private bool officeSoundSourceBool;


    [SerializeField] GameObject exitFadeInPanel;


    [Header("The Story Bit Variables")]
    private bool storyBitStarter = false;
    private bool firstBitBool = false;
    private bool secondBitBool = false;
    private bool thirdBitBool = false;

    [SerializeField] TMP_InputField yourName;
    [SerializeField] GameObject yourNameHere;
    
    //transition
    [SerializeField] GameObject tournamentManager;
    
    [SerializeField] GameObject fadeOutPanel;

    [SerializeField] AudioClip signingSFX;

    private void Start()
    {
        mainMenuTitle.GetComponent<Animator>().SetTrigger("FadeIn");
        playButton.GetComponent<Animator>().SetTrigger("FadeIn");
        exitButton.GetComponent<Animator>().SetTrigger("FadeIn");
    }

    private void Update()
    {
       if(streetSoundSourceBool)
        {
            streetSoundSource.GetComponent<AudioSource>().volume = Mathf.MoveTowards(streetSoundSource.GetComponent<AudioSource>().volume, 0.3f, 0.05f * Time.deltaTime);
        }
       else if(!streetSoundSourceBool && streetSoundSource.GetComponent<AudioSource>().volume != 0)
        {
            streetSoundSource.GetComponent<AudioSource>().volume = Mathf.MoveTowards(streetSoundSource.GetComponent<AudioSource>().volume, 0.3f, 0.05f * Time.deltaTime);
        }

       if(officeSoundSourceBool)
        {
            officeSoundSource.GetComponent<AudioSource>().volume = Mathf.MoveTowards(officeSoundSource.GetComponent<AudioSource>().volume, 0.3f, 0.05f * Time.deltaTime);
        }
       else if(!officeSoundSourceBool && officeSoundSource.GetComponent<AudioSource>().volume != 0)
        {
            officeSoundSource.GetComponent<AudioSource>().volume = Mathf.MoveTowards(officeSoundSource.GetComponent<AudioSource>().volume, 0.3f, 0.05f * Time.deltaTime);
        }

        
        if (storyBitStarter)
        {
            if (firstBitBool && Input.anyKeyDown)
            {
                firstBitBool = false;
                StartCoroutine("firstStoryBitFunc");
                
                
            }
            else if (secondBitBool && Input.anyKeyDown)
            {
                //secondBit IENumerator
                secondBitBool = false;
                thirdBitBool = true;
            }
            else if (thirdBitBool && Input.anyKeyDown)
            {
                //thirdBit IENumerator
                thirdBitBool = false;
                StartCoroutine("setTheContractUp");

            }
        }
        else return;

    }

    public void playButtonFunc()
    {
        StartCoroutine("mainMenuBitsAndSound");
        
    }

    public void exitButtonFunc()
    {
        Application.Quit();
    }

    public void signButton()
    {
        if (yourName.text.Length < 1)
        {
            StartCoroutine("yourNameHereSir");
        }

        else
        {
            StartCoroutine("weGoIn");
        }
    }

    //main menu to story bit 

    IEnumerator mainMenuBitsAndSound()
    {
        startFadeInPanel.SetActive(true);
        startFadeInPanel.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(3f);
        mainMenuImage.SetActive(false);
        mainMenu.SetActive(false);
        firstBitText.SetActive(true);
        pressAnyKey.SetActive(true);
        // street sounds goes in and the texts
        streetSoundSourceBool = true;
        firstBitText.GetComponent<Animator>().SetTrigger("FadeIn");
        pressAnyKey.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(1);
        storyBitStarter = true;
        firstBitBool = true;
    }

    IEnumerator firstStoryBitFunc()
    {
        firstBitText.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(2f);
        firstBitText.SetActive(false);
        secondBitText.SetActive(true);
        secondBitText.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(1);
        secondBitBool = true;

    }

    IEnumerator secondStoryBitFunc()
    {
        secondBitText.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        thirdBitText.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(1);
        secondBitBool = true;

    }

    IEnumerator thirdStoryBitFunc()
    {
        
        thirdBitText.GetComponent<Animator>().SetTrigger("FadeOut");
        storyBitStarter = false;
        yield return new WaitForSeconds(1);
        startFadeInPanel.GetComponent<Animator>().SetTrigger("Fadeout");


    }

    //the contract part
    IEnumerator setTheContractUp()
    {
        yield return new WaitForSeconds(1.5f);
        startFadeInPanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(1.5f);
        startFadeInPanel.SetActive(false);
    }

    IEnumerator yourNameHereSir()
    {
        yourNameHere.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        yourNameHere.SetActive(false);
    }
    
    IEnumerator weGoIn()
    {
        GetComponent<AudioSource>().PlayOneShot(signingSFX);
        yield return new WaitForSeconds(2);
        exitFadeInPanel.SetActive(true);
        ValueManager.playerName = yourName.text.ToString();
        exitFadeInPanel.GetComponent<Animator>().SetTrigger("FadeIn");
        yield return new WaitForSeconds(2);
        yield return new WaitForSeconds(2);
        tournamentManager.GetComponent<TournamentManager>().nextScene();
    }

    
    

}
