using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DuelManager : MonoBehaviour
{
    [Header("Round Outcome Variables")]
    public float clickedBulletCount = 5;
    private bool bulletCountCondition = false;

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
            
            StartTimer();

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
            Debug.Log("Victory");
            bulletCountCondition = !bulletCountCondition;
        }
    }

    private void StartTimer()
    {
        timerSlider.value -= 1.0f * Time.deltaTime;

        if (timerSlider.value == 0)
        {
            Debug.Log("you lost");
            timerCondition = !timerCondition;
        }
    }

    private void SpawnFirstBullet()
    {
        if (placeIndex == 0)
        {
            float xTransform = Random.Range(-7.0f, -1.0f);
            float yTransform = Random.Range(2.0f, 5.0f);

            Vector2 bulletSpawnLoc = new Vector2(xTransform, yTransform);

            Instantiate(normalBullet, bulletSpawnLoc, Quaternion.identity);
            
            mainSpawnCondition = !mainSpawnCondition;

        }

        else if (placeIndex == 1)
        {
            float xTransform = Random.Range(1f, 7f);
            float yTransform = Random.Range(2f, 5f);

            Vector2 bulletSpawnLoc = new Vector2(xTransform, yTransform);

            Instantiate(normalBullet, bulletSpawnLoc, Quaternion.identity);
            
            mainSpawnCondition = !mainSpawnCondition;
        }

        else if (placeIndex == 2)
        {

            float xTransform = Random.Range(-7f, -1f);
            float yTransform = Random.Range(-3f, 0f);

            Vector2 bulletSpawnLoc = new Vector2(xTransform, yTransform);

            Instantiate(normalBullet, bulletSpawnLoc, Quaternion.identity);
            
            mainSpawnCondition = !mainSpawnCondition;
        }

        else if (placeIndex == 3)
        {

            float xTransform = Random.Range(1f, 7f);
            float yTransform = Random.Range(-3f, 0f);

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
