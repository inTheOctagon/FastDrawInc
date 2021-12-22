using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    [SerializeField] GameObject normalBulletPrefab;

    private bool spawnCondition;

    Vector2 bulletSpawnLoc;

    DuelManager duelManagerScript;
    
    private void Awake()
    {

        //clicked bullet count context
        duelManagerScript = GameObject.Find("Duel Manager").GetComponent<DuelManager>();

        //Spawn context
        spawnCondition = true;
        float currentTransformX = transform.position.x;
        float currentTransformY = transform.position.y;

        if ((-7 <= currentTransformX && currentTransformX <= -1) && (2 <= currentTransformY && currentTransformY <= 5))
        {

            int spawnIndex = Random.Range(1, 3);
            if (spawnIndex == 1 && spawnCondition)
            {
                float xTransform = Random.Range(7f, 1f);
                float yTransform = Random.Range(2f, 5f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);

                
                spawnCondition = !spawnCondition;
            }
            else if (spawnIndex == 2 && spawnCondition)
            {
                float xTransform = Random.Range(-7f, -1f);
                float yTransform = Random.Range(-3f, 0f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);

               
                spawnCondition = !spawnCondition;
            }


            else if (spawnIndex == 3 && spawnCondition)
            {
                float xTransform = Random.Range(1f, 7f);
                float yTransform = Random.Range(-3f, 0f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);

                

                spawnCondition = !spawnCondition;
            }
            else return;


        }

        else if ((1 <= currentTransformX && currentTransformX <= 7) && (2 <= currentTransformY && currentTransformY <= 5))
        {

            int spawnIndex = Random.Range(1, 3);
            if (spawnIndex == 1 && spawnCondition)
            {
                float xTransform = Random.Range(-7f, -1f);
                float yTransform = Random.Range(2f, 5f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);

                
                spawnCondition = !spawnCondition;
            }
            else if (spawnIndex == 2 && spawnCondition)
            {
                float xTransform = Random.Range(-7f, -1f);
                float yTransform = Random.Range(-3f, 0f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);

                
                spawnCondition = !spawnCondition;
            }


            else if (spawnIndex == 3 && spawnCondition)
            {
                float xTransform = Random.Range(1f, 7f);
                float yTransform = Random.Range(-3f, 0f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);

               

                spawnCondition = !spawnCondition;
            }
            

            //spawn arealarn aralklar: 
            //area0: x: -7 to -1, y: 5 to 2
            //area1: x: 7 to 1, y: 5 to 2
            //area2: x: -7 to -1, y: 0 to -3
            //area3: x: 7 to 1, y: 0 to -3


        }

        else if ((-7 <= currentTransformX && currentTransformX <= -1) && (-3 <= currentTransformY && currentTransformY <= 0))
        {

            int spawnIndex = Random.Range(1, 3);
            if (spawnIndex == 1 && spawnCondition)
            {
                float xTransform = Random.Range(-7f, -1f);
                float yTransform = Random.Range(2f, 5f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);

                
                spawnCondition = !spawnCondition;
            }
            else if (spawnIndex == 2 && spawnCondition)
            {
                float xTransform = Random.Range(1f, 7f);
                float yTransform = Random.Range(2f, 5f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);

                
                spawnCondition = !spawnCondition;
            }


            else if (spawnIndex == 3 && spawnCondition)
            {
                float xTransform = Random.Range(1f, 7f);
                float yTransform = Random.Range(-3f, 0f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);

               

                spawnCondition = !spawnCondition;
            }
            

            //spawn arealarn aralklar: 
            //area0: x: -7 to -1, y: 5 to 2
            //area1: x: 7 to 1, y: 5 to 2
            //area2: x: -7 to -1, y: 0 to -3
            //area3: x: 7 to 1, y: 0 to -3


        }

        else if ((1 <= currentTransformX && currentTransformX <= 7) && (-3 <= currentTransformY && currentTransformY <= 0))
        {

            int spawnIndex = Random.Range(1, 3);
            if (spawnIndex == 1 && spawnCondition)
            {
                float xTransform = Random.Range(-7f, -1f);
                float yTransform = Random.Range(2f, 5f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);

                
                spawnCondition = !spawnCondition;
            }
            else if (spawnIndex == 2 && spawnCondition)
            {
                float xTransform = Random.Range(1f, 7f);
                float yTransform = Random.Range(2f, 5f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);

                
                spawnCondition = !spawnCondition;
            }


            else if (spawnIndex == 3 && spawnCondition)
            {
                float xTransform = Random.Range(1f, 7f);
                float yTransform = Random.Range(-3f, 0f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);

                

                spawnCondition = !spawnCondition;
            }
            

            //spawn arealarn aralklar: 
            //area0: x: -7 to -1, y: 5 to 2
            //area1: x: 7 to 1, y: 5 to 2
            //area2: x: -7 to -1, y: 0 to -3
            //area3: x: 7 to 1, y: 0 to -3


        }

    }

    private void OnMouseUpAsButton()
    {

        Instantiate(normalBulletPrefab, bulletSpawnLoc, Quaternion.identity);
        duelManagerScript.clickedBulletCount = duelManagerScript.clickedBulletCount - 1;
        Destroy(this.gameObject);
        
    }
}
