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

    [Header("UI Variables")]
    [SerializeField] TextMeshProUGUI yourScoreText;
    private int yourScoreIndex = 0;
    [SerializeField] TextMeshProUGUI opponentsScoreText;
    private int opponentsScoreIndex = 0;
    [SerializeField] TextMeshProUGUI countdownText;
    private bool timerFiller = false;
    RaycastHit2D boardHit;
    [SerializeField] GameObject timerPenaltyText;
    
    //UI Animation
    [SerializeField] GameObject scorePanel;
    private Animator scoreAnimator;


    private void Awake()
    {
        tournamentManager = tournamentManagerObject.GetComponent<TournamentManager>();

        // UI text variables

        scoreAnimator = scorePanel.GetComponent<Animator>();

        StartCoroutine("StartCountdown");

        // timer values are set
        timerValue = ValueManager.newTimerValue;
        timerSlider.maxValue = timerValue;
        timerSlider.value = timerValue;

    }

    private void Update()
    {

        if (mainSpawnCondition) 
        {
            if(MastermindSpawnCondition)
            {
                float xTransform = Random.Range(-6f, -6f);
                float yTransform = Random.Range(-2, 0f);

                Vector2 bulletSpawnLoc = new Vector2(xTransform, yTransform);

                Instantiate(bulletPrefab, bulletSpawnLoc, Quaternion.identity);

                mainSpawnCondition = !mainSpawnCondition;
            }
            else
            {
                SpawnFirstBullet();
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

    IEnumerator StartCountdown()
    {
        clickedBulletCount = 5;

        timerFiller = false;
        
        yield return new WaitForSeconds(1);
        countdownText.enabled = true;
        countdownText.text = 3.ToString();
        yield return new WaitForSeconds(1);
        countdownText.text = 2.ToString();
        yield return new WaitForSeconds(1);
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
        yield return new WaitForSeconds(1.8f);
        yourScoreText.text = yourScoreIndex.ToString();
        yield return new WaitForSeconds(2.4f);
        scoreAnimator.SetBool("UIScoresAnim", false);
        yield return new WaitForSeconds(1);
        if (yourScoreIndex != 3)
        {
            timerFiller = true;
            yield return new WaitForSeconds(1.5f);
        }
        if ( yourScoreIndex != 3)
        {
            StartCoroutine("StartCountdown");
        }
        else
        {
            tournamentManager.nextScene();
        }



    }

    IEnumerator OpponentWinOutput()
    {
        bulletCountCondition = false;
        yield return new WaitForSeconds(0.5f);
        scoreAnimator.SetBool("UIScoresAnim", true);
        yield return new WaitForSeconds(1.8f);
        opponentsScoreText.text = opponentsScoreIndex.ToString();
        yield return new WaitForSeconds(2.4f);
        scoreAnimator.SetBool("UIScoresAnim", false);
        yield return new WaitForSeconds(1);
        if (opponentsScoreIndex != 3)
        {
            timerFiller = true;
            yield return new WaitForSeconds(1.5f);    
        }
        
        if (opponentsScoreIndex != 3)
        {
            StartCoroutine("StartCountdown");
        }
        else
        {
            tournamentManager.youareDeadScene();
        }
        

    }

}
