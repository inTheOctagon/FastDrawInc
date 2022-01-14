using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DuelManager : MonoBehaviour
{
    [Header("Round Outcome Variables")]
    public float clickedBulletCount = 5;
    private bool bulletCountCondition = false;
    [SerializeField] GameObject tournamentManagerObject;
    private TournamentManager tournamentManager;
    [SerializeField] GameObject panelFadeIn;

    [Header("Character Variables")]
    [SerializeField] GameObject you;
    [SerializeField] GameObject him;

    [Header("Bullet Variables")]
    [SerializeField] GameObject bulletPrefab;
    private int placeIndex = -1;
    private bool mainSpawnCondition = false;
    //Mastermind Spawn Area Setter
    public bool MastermindSpawnCondition = false;
    
    [Header("Timer Variables")]
    [SerializeField] Slider timerSlider;
    public float timerValue;
    public bool timerCondition = false;
    RaycastHit2D boardHit;

    [Header("UI Variables")]
    [SerializeField] GameObject tipPanel;
    private bool startTipCon = false;
    [SerializeField] GameObject yourNameText;
    [SerializeField] GameObject opponentsNameText;
    private bool tipCon = false;
    [SerializeField] TextMeshProUGUI yourScoreText;
    private int yourScoreIndex = 0;
    [SerializeField] TextMeshProUGUI opponentsScoreText;
    private int opponentsScoreIndex = 0;
    [SerializeField] TextMeshProUGUI countdownText;
    private bool timerFiller = false;
    [SerializeField] GameObject scorePanel;
    private Animator scoreAnimator;
    [SerializeField] GameObject timerPenaltyText;
    //your name
    [SerializeField] TextMeshProUGUI playerNameText;

    [Header("SFX")]
    [SerializeField] AudioClip gunshotClip;
    [SerializeField] AudioClip graveClip;
    [SerializeField] AudioClip scoreUpClip;

    [Header("Sectional Additions")]

    [SerializeField] GameObject theStrongOneText;

    [SerializeField] GameObject howDidHeDoThat;
    private bool theMastermind = false;

    public bool duel4Con = false;
    public bool duel5Con = false;
    public bool theStrongMan = false;
    public bool theMastermindStart = false;

    [SerializeField] GameObject mastermindPanel;
    

    private void Start()
    {
        
        tournamentManager = tournamentManagerObject.GetComponent<TournamentManager>();

        // UI text variables

        playerNameText.text = ValueManager.playerName; 

        scoreAnimator = scorePanel.GetComponent<Animator>();

        if(!theMastermindStart) StartCoroutine("StartWithTheSetupAndTips");

        // timer values are set
        timerValue = ValueManager.newTimerValue;
        if(duel4Con) timerValue = ValueManager.newTimerValue + 0.9f;
        timerSlider.maxValue = timerValue;
        timerSlider.value = timerValue;

        //the mastermind start UI transition

        if (theMastermindStart) StartCoroutine("theMastermindSetup");

    }

    private void Update()
    {
        
        

        if (mainSpawnCondition) 
        {
            if(MastermindSpawnCondition)
            {
                float xTransform = Random.Range(-6f, 6f);
                float yTransform = Random.Range(-1, 0f);

                Vector2 bulletSpawnLoc = new Vector2(xTransform, yTransform);

                Instantiate(bulletPrefab, bulletSpawnLoc, Quaternion.identity);

                mainSpawnCondition = !mainSpawnCondition;
            }
            else
            {
                SpawnFirstBullet();
                mainSpawnCondition = false;
            }
            
        }

        if (timerCondition)
        {
            
            Timer();

        }

        if (timerFiller)
        {
            timerSlider.value += 3.5f * Time.deltaTime;
            
        }

        if (bulletCountCondition)
        {
            CountBulletsForVictory();
        }

        // timer penalty for when player clicks outside of a bullet
        if(Input.GetKeyDown(KeyCode.Mouse0) && timerCondition)
        {
            Vector2 boardRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            boardHit = Physics2D.Raycast(boardRay, Vector2.zero);

            if (boardHit.collider.CompareTag("Board"))
            {
                timerSlider.value = timerSlider.value - 0.25f;
                StartCoroutine("TimerPenaltyText");
                
            }
        }


        if (tipCon)
        {
            if (Input.anyKeyDown)
            {
                tipPanel.GetComponent<Animator>().SetTrigger("FadeOut");
                opponentsNameText.GetComponent<Animator>().SetTrigger("FadeOut");
                yourNameText.GetComponent<Animator>().SetTrigger("FadeOut");
                StartCoroutine("StartCountdown");
                startTipCon = false;
                tipCon = false;
            }


        }
        else if (theStrongMan)
        {
            if (Input.anyKeyDown)
            {
                theStrongOneText.GetComponent<Animator>().SetTrigger("FadeOut");
                StartCoroutine("StartCountdown");
                theStrongMan = false;
            }

        }
        else if(theMastermind)
        {
            if(Input.anyKeyDown)
            {
                howDidHeDoThat.GetComponent<Animator>().SetTrigger("FadeOut");
                StartCoroutine("theMastermindTipPanel");
                theMastermind = false;
            }
            
        }
        else return;


    }

    private void CountBulletsForVictory()
    {
        if (clickedBulletCount == 0)
        {
            yourScoreIndex++;
            StartCoroutine("PlayerWinOutput");
            bulletCountCondition = !bulletCountCondition;
        }
    }

    private void Timer()
    {
        timerSlider.value -= 1.0f * Time.deltaTime;
        Debug.Log(timerSlider.value);
        
        if (timerSlider.value == 0)
        {
            OpponentWinOutputFunction();
        }
        
    }

    public void OpponentWinOutputFunction()
    {
        opponentsScoreIndex++;
        //opponentsScoreText.text = opponentsScoreIndex.ToString();
        timerCondition = !timerCondition;
        StartCoroutine("OpponentWinOutput");
        var bullet = GameObject.FindGameObjectWithTag("Bullet");
        Destroy(bullet);
    }

    private void SpawnFirstBullet()
    {
        if (placeIndex == 0)
        {
            float xTransform = Random.Range(-6.5f, -1.5f);
            float yTransform = Random.Range(2.5f, 4.5f);

            Vector2 bulletSpawnLoc = new Vector2(xTransform, yTransform);

            Instantiate(bulletPrefab, bulletSpawnLoc, Quaternion.identity);
            
            mainSpawnCondition = !mainSpawnCondition;

        }

        else if (placeIndex == 1)
        {
            float xTransform = Random.Range(1.5f, 6.5f);
            float yTransform = Random.Range(2.5f, 4.5f);

            Vector2 bulletSpawnLoc = new Vector2(xTransform, yTransform);

            Instantiate(bulletPrefab, bulletSpawnLoc, Quaternion.identity);
            
            mainSpawnCondition = !mainSpawnCondition;
        }

        else if (placeIndex == 2)
        {

            float xTransform = Random.Range(-6.5f, -1.5f);
            float yTransform = Random.Range(-2.5f, -0.5f);

            Vector2 bulletSpawnLoc = new Vector2(xTransform, yTransform);

            Instantiate(bulletPrefab, bulletSpawnLoc, Quaternion.identity);
            
            mainSpawnCondition = !mainSpawnCondition;
        }

        else if (placeIndex == 3)
        {

            float xTransform = Random.Range(1.5f, 6.5f);
            float yTransform = Random.Range(-2.5f, 0.5f);

            Vector2 bulletSpawnLoc = new Vector2(xTransform, yTransform);

            Instantiate(bulletPrefab, bulletSpawnLoc, Quaternion.identity);
            
            mainSpawnCondition = !mainSpawnCondition;
        }
        else return;

    }

    IEnumerator TimerPenaltyText()
    {
        timerPenaltyText.transform.position = Input.mousePosition; 
        timerPenaltyText.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        timerPenaltyText.SetActive(false);
    }

    IEnumerator StartWithTheSetupAndTips()
    {
        scoreAnimator.SetTrigger("FadeIn");
        opponentsNameText.GetComponent<Animator>().SetTrigger("FadeIn");
        yourNameText.GetComponent<Animator>().SetTrigger("FadeIn");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        // names here fade in 
        yield return new WaitForSeconds(2);
        tipCon = true;
        tipPanel.GetComponent<Animator>().SetTrigger("FadeIn");

    }

    IEnumerator StartCountdown()
    {
        

    
        clickedBulletCount = 5;

        timerFiller = false;
        
        yield return new WaitForSeconds(2);
        countdownText.enabled = true;
        GetComponent<AudioSource>().Play(0);
        countdownText.text = 3.ToString();
        yield return new WaitForSeconds(1);
        GetComponent<AudioSource>().Play(0);
        countdownText.text = 2.ToString();
        yield return new WaitForSeconds(1);
        GetComponent<AudioSource>().Play(0);
        countdownText.text = 1.ToString();
        yield return new WaitForSeconds(1);
        
        countdownText.enabled = false;

        // spawn area index
        placeIndex = Random.Range(0, 3);
        // enables instantiating context
        mainSpawnCondition = true;
        // enables timer context
        timerCondition = true;
        // enables clickedBulletCount context
        bulletCountCondition = true;


    }

    IEnumerator PlayerWinOutput()
    {
        timerCondition = false;
        yield return new WaitForSeconds(0.5f);
        scoreAnimator.SetBool("UIScoresAnim", true);
        GetComponent<AudioSource>().PlayOneShot(scoreUpClip,0.5f);
        yield return new WaitForSeconds(1.8f);
        yourScoreText.text = yourScoreIndex.ToString();
        yield return new WaitForSeconds(2.4f);
        scoreAnimator.SetBool("UIScoresAnim", false);
        yield return new WaitForSeconds(1);
        
        if(duel5Con && yourScoreIndex == 2 && (opponentsScoreIndex == 0 || opponentsScoreIndex == 1))
        {
            timerCondition = false;
            yield return new WaitForSeconds(0.5f);
            scoreAnimator.SetBool("UIScoresAnim", true);
            yield return new WaitForSeconds(1.8f);
            yourScoreText.text = opponentsScoreIndex.ToString();
            opponentsScoreText.text = yourScoreIndex.ToString();
            yield return new WaitForSeconds(2.4f);
            scoreAnimator.SetBool("UIScoresAnim", false);
            howDidHeDoThat.GetComponent<Animator>().SetTrigger("FadeIn");
            yield return new WaitForSeconds(1);
            timerFiller = true;
            yield return new WaitForSeconds(1.5f);
            theMastermind = true;
            duel5Con = false;
            var tempOppIndex = opponentsScoreIndex;
            var tempYourIndex = yourScoreIndex;
            yourScoreIndex = tempOppIndex;
            opponentsScoreIndex = tempYourIndex;
        }

        else if(duel4Con && yourScoreIndex == 3)
        {
            you.GetComponent<Animator>().SetTrigger("Shoot");
            GetComponent<AudioSource>().PlayOneShot(gunshotClip, 0.7f);
            yield return new WaitForSeconds(1f);
            him.GetComponent<Animator>().SetTrigger("Die1");
            yield return new WaitForSeconds(2.5f);
            yield return new WaitForSeconds(1.5f);
            theStrongOneText.GetComponent<Animator>().SetTrigger("FadeIn");
            timerFiller = true;
            yield return new WaitForSeconds(1.5f);
            theStrongMan = true;
            

        }

        else if (duel4Con && yourScoreIndex == 6)
        {
            you.GetComponent<Animator>().SetTrigger("Shoot2");
            GetComponent<AudioSource>().PlayOneShot(gunshotClip,0.7f);
            yield return new WaitForSeconds(1f);
            him.GetComponent<Animator>().SetTrigger("Die2");
            yield return new WaitForSeconds(2.9f);
            GetComponent<AudioSource>().PlayOneShot(graveClip,0.5f);
            yield return new WaitForSeconds(4f);
            panelFadeIn.GetComponent<Animator>().SetTrigger("FadeIn");
            yield return new WaitForSeconds(1f);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            yield return new WaitForSeconds(3f);
            
            tournamentManager.nextScene();



        }
        else if ( yourScoreIndex != 3)
        {
            timerFiller = true;
            yield return new WaitForSeconds(1.5f);
            StartCoroutine("StartCountdown");
        }
        else if(!duel4Con)
        {
            you.GetComponent<Animator>().SetTrigger("Shoot");
            GetComponent<AudioSource>().PlayOneShot(gunshotClip,0.7f);
            yield return new WaitForSeconds(1f);
            him.GetComponent<Animator>().SetTrigger("Die");
            yield return new WaitForSeconds(2.9f);
            GetComponent<AudioSource>().PlayOneShot(graveClip,0.5f);
            yield return new WaitForSeconds(4f);

            panelFadeIn.GetComponent<Animator>().SetTrigger("FadeIn");
            yield return new WaitForSeconds(1f);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            yield return new WaitForSeconds(3f);
            Destroy((GameObject.FindGameObjectWithTag("Clock Tower")));
            tournamentManager.nextScene();
        }
        



    }

    IEnumerator OpponentWinOutput()
    {
        bulletCountCondition = false;
        yield return new WaitForSeconds(0.5f);
        scoreAnimator.SetBool("UIScoresAnim", true);
        GetComponent<AudioSource>().PlayOneShot(scoreUpClip, 0.5f);
        yield return new WaitForSeconds(1.8f);
        opponentsScoreText.text = opponentsScoreIndex.ToString();
        yield return new WaitForSeconds(2.4f);
        scoreAnimator.SetBool("UIScoresAnim", false);
        yield return new WaitForSeconds(1);
        
        if (opponentsScoreIndex != 3)
        {
            timerFiller = true;
            yield return new WaitForSeconds(1.5f);
            StartCoroutine("StartCountdown");
        }
        else
        {
            him.GetComponent<Animator>().SetTrigger("Shoot");
            GetComponent<AudioSource>().PlayOneShot(gunshotClip,0.7f);
            yield return new WaitForSeconds(1f);
            you.GetComponent<Animator>().SetTrigger("Die");
            yield return new WaitForSeconds(2.9f);
            GetComponent<AudioSource>().PlayOneShot(graveClip,0.5f);
            yield return new WaitForSeconds(4f);
            panelFadeIn.GetComponent<Animator>().SetTrigger("FadeIn");
            yield return new WaitForSeconds(1f);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            yield return new WaitForSeconds(3f);
            Destroy((GameObject.FindGameObjectWithTag("Clock Tower")));
            tournamentManager.youareDeadScene();
            
        }
        

    }

    IEnumerator theMastermindSetup()
    {
        yield return new WaitForSeconds(0.5f);
        mastermindPanel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(1f);
        StartCoroutine("StartWithTheSetupAndTips");

    }
    
    IEnumerator theMastermindTipPanel()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine("StartCountdown");
    }
}
