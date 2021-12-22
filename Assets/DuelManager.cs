using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelManager : MonoBehaviour
{
    [SerializeField] GameObject normalBullet;

    private int placeIndex = -1;
    
    private bool spawnCondition;

    private void Awake()
    {
        spawnCondition = true;
        StartCoroutine("StartCountdown");
    }

    private void Update()
    {
        if (placeIndex == 0 && spawnCondition == true)
        {
            float xTransform = Random.Range(-7.0f, -1.0f);
            float yTransform = Random.Range(2.0f, 5.0f);

            Vector2 bulletSpawnLoc = new Vector2(xTransform, yTransform);

            Instantiate(normalBullet, bulletSpawnLoc, Quaternion.identity);
            spawnCondition = false;

        }

        else if (placeIndex == 1 && spawnCondition == true)
        {
            float xTransform = Random.Range(1f, 7f);
            float yTransform = Random.Range(2f, 5f);

            Vector2 bulletSpawnLoc = new Vector2(xTransform, yTransform);

            Instantiate(normalBullet, bulletSpawnLoc, Quaternion.identity);
            spawnCondition = false;
        }

        else if (placeIndex == 2 && spawnCondition == true)
        {

            float xTransform = Random.Range(-7f, -1f);
            float yTransform = Random.Range(-3f, 0f);

            Vector2 bulletSpawnLoc = new Vector2(xTransform, yTransform);

            Instantiate(normalBullet, bulletSpawnLoc, Quaternion.identity);
            spawnCondition = false;
        }

        else if (placeIndex == 3 && spawnCondition == true)
        {

            float xTransform = Random.Range(1f, 7f);
            float yTransform = Random.Range(-3f, 0f);

            Vector2 bulletSpawnLoc = new Vector2(xTransform, yTransform);

            Instantiate(normalBullet, bulletSpawnLoc, Quaternion.identity);
            spawnCondition = false;
        }
        else return;

        

        //spawn arealarn aralklar: 
        //area0: x: -7 to -1, y: 5 to 2
        //area1: x: 7 to 1, y: 5 to 2
        //area2: x: -7 to -1, y: 0 to -3
        //area3: x: 7 to 1, y: 0 to -3





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

    }

}
