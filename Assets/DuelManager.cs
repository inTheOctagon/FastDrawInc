using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelManager : MonoBehaviour
{
    [SerializeField] GameObject normalBullet;

    private int placeIndex = -1;
    
    private bool mainSpawnCondition = true;

    private void Awake()
    {
        
        StartCoroutine("StartCountdown");
    }

    private void Update()
    {
        if (mainSpawnCondition) SpawnFirstBullet();

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

        placeIndex = Random.Range(0, 3);
        mainSpawnCondition = true;

    }

}
