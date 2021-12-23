using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DuelManager : MonoBehaviour
{
    [Header("Round Outcome Variables")]
    public float clickedBulletCount = 5;
    private bool bulletCountCondition = false;

    [Header("UI Variables")]
    [SerializeField] TextMeshProUGUI yourScoreText;
    private int yourScoreIndex = 0;
    [SerializeField] TextMeshProUGUI opponentsScoreText;
    private int opponentsScoreIndex = 0;

    [Header("First Bullet Variables")]
    [SerializeField] GameObject normalBullet;
    private int placeIndex = -1;
    private bool mainSpawnCondition = true;
    
    [Header("Timer Variables")]
    [SerializeField] Slider timerSlider;
    [SerializeField] float timerValue;
    private bool timerCondition = false;


    private void Awake()
    {

        // UI text variables

        yourScoreText.text = yourScoreIndex.ToString();
        opponentsScoreText.text = opponentsScoreIndex.ToString();

        StartCoroutine("StartCountdown");

        // timer values are set
        
        timerSlider.maxValue = timerValue;
        timerSlider.value = timerValue;

    }

    private void Update()
    {

        if (mainSpawnCondition) 
        {
            
            SpawnFirstBullet(); 
        }

        if (timerCondition)
        {
            
            Timer();

        }

        if(bulletCountCondition)
        {
            CountBulletsForVictory();
        }
        

    }

    private void CountBulletsForVictory()
    {
        if (clickedBulletCount == 0)
        {
            yourScoreIndex++;
            yourScoreText.text = yourScoreIndex.ToString();
            bulletCountCondition = !bulletCountCondition;
        }
    }

    private void Timer()
    {
        timerSlider.value -= 1.0f * Time.deltaTime;

        if (timerSlider.value == 0)
        {
            opponentsScoreIndex++;
            opponentsScoreText.text = opponentsScoreIndex.ToString();
            timerCondition = !timerCondition;
        }
    }

    private void SpawnFirstBullet()
    {
        if (placeIndex == 0)
        {
            float xTransform = Random.Range(-6.5f, -1.5f);
            float yTransform = Random.Range(2.5f, 4.5f);

            Vector2 bulletSpawnLoc = new Vector2(xTransform, yTransform);

            Instantiate(normalBullet, bulletSpawnLoc, Quaternion.identity);
            
            mainSpawnCondition = !mainSpawnCondition;

        }

        else if (placeIndex == 1)
        {
            float xTransform = Random.Range(1.5f, 6.5f);
            float yTransform = Random.Range(2.5f, 4.5f);

            Vector2 bulletSpawnLoc = new Vector2(xTransform, yTransform);

            Instantiate(normalBullet, bulletSpawnLoc, Quaternion.identity);
            
            mainSpawnCondition = !mainSpawnCondition;
        }

        else if (placeIndex == 2)
        {

            float xTransform = Random.Range(-6.5f, -1.5f);
            float yTransform = Random.Range(-2.5f, -0.5f);

            Vector2 bulletSpawnLoc = new Vector2(xTransform, yTransform);

            Instantiate(normalBullet, bulletSpawnLoc, Quaternion.identity);
            
            mainSpawnCondition = !mainSpawnCondition;
        }

        else if (placeIndex == 3)
        {

            float xTransform = Random.Range(1.5f, 6.5f);
            float yTransform = Random.Range(-2.5f, 0.5f);

            Vector2 bulletSpawnLoc = new Vector2(xTransform, yTransform);

            Instantiate(normalBullet, bulletSpawnLoc, Quaternion.identity);
            
            mainSpawnCondition = !mainSpawnCondition;
        }
        else return;

    }

    IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("3");
        yield return new WaitForSeconds(1);
        Debug.Log("2");
        yield return new WaitForSeconds(1);
        Debug.Log("1");
        yield return new WaitForSeconds(1);
        Debug.Log("Start!");

        // spawn area index
        placeIndex = Random.Range(0, 3);
        // enables instantiating context
        mainSpawnCondition = true;
        // enables timer context
        timerCondition = true;
        // enables clickedBulletCount context
        bulletCountCondition = true;


    }

}
