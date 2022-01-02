using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastermindBullet : MonoBehaviour
{
    [SerializeField] GameObject mastermindBulletPrefab;

    

    private bool spawnCondition;

    Vector2 bulletSpawnLoc;

    DuelManager duelManagerScript;

    //target pos
    Vector2 targetPos;
    

    [SerializeField] float moveSpeed;




    private void Awake()
    {
        //bullet size

        this.gameObject.transform.localScale = new Vector2(ValueManager.newBulletSize, ValueManager.newBulletSize);

        //clicked bullet count context
        duelManagerScript = GameObject.Find("Duel Manager").GetComponent<DuelManager>();

        //Spawn context
        spawnCondition = true;
        float currentTransformX = transform.position.x;
        float currentTransformY = transform.position.y;

        if ((-6.5f <= currentTransformX && currentTransformX <= -1.5f) && (2.5f <= currentTransformY && currentTransformY <= 4.5f))
        {

            //targetPos.x = Random.Range(-6, 6);
            //targetPos.y = Random.Range(-2, 4);

            int spawnIndex = Random.Range(1, 3);
            if (spawnIndex == 1 && spawnCondition)
            {
                float xTransform = Random.Range(6f, 1.5f);
                float yTransform = Random.Range(2.5f, 4f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);


                spawnCondition = !spawnCondition;
            }
            else if (spawnIndex == 2 && spawnCondition)
            {
                float xTransform = Random.Range(-6f, -1.5f);
                float yTransform = Random.Range(-2f, -0.5f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);


                spawnCondition = !spawnCondition;
            }


            else if (spawnIndex == 3 && spawnCondition)
            {
                float xTransform = Random.Range(1.5f, 6f);
                float yTransform = Random.Range(-2f, -0.5f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);



                spawnCondition = !spawnCondition;
            }

            

            else return;


        }

        else if ((1.5f <= currentTransformX && currentTransformX <= 6.5f) && (2.5f <= currentTransformY && currentTransformY <= 4.5f))
        {

            int spawnIndex = Random.Range(1, 3);
            if (spawnIndex == 1 && spawnCondition)
            {
                float xTransform = Random.Range(-6f, -1.5f);
                float yTransform = Random.Range(2.5f, 4f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);


                spawnCondition = !spawnCondition;
            }
            else if (spawnIndex == 2 && spawnCondition)
            {
                float xTransform = Random.Range(-6f, -1.5f);
                float yTransform = Random.Range(-2f, -0.5f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);


                spawnCondition = !spawnCondition;
            }


            else if (spawnIndex == 3 && spawnCondition)
            {
                float xTransform = Random.Range(1.5f, 6);
                float yTransform = Random.Range(-2f, -0.5f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);



                spawnCondition = !spawnCondition;
            }


            //spawn arealarn aralklar: 
            //area0: x: -7 to -1, y: 5 to 2
            //area1: x: 7 to 1, y: 5 to 2
            //area2: x: -7 to -1, y: 0 to -3
            //area3: x: 7 to 1, y: 0 to -3


        }

        else if ((-6.5f <= currentTransformX && currentTransformX <= -1.5f) && (-2.5f <= currentTransformY && currentTransformY <= -0.5f))
        {

            int spawnIndex = Random.Range(1, 3);
            if (spawnIndex == 1 && spawnCondition)
            {
                float xTransform = Random.Range(-6f, -1.5f);
                float yTransform = Random.Range(2.5f, 4f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);


                spawnCondition = !spawnCondition;
            }
            else if (spawnIndex == 2 && spawnCondition)
            {
                float xTransform = Random.Range(1.5f, 6f);
                float yTransform = Random.Range(2.5f, 4f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);


                spawnCondition = !spawnCondition;
            }


            else if (spawnIndex == 3 && spawnCondition)
            {
                float xTransform = Random.Range(1.5f, 6f);
                float yTransform = Random.Range(-2f, -0.5f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);



                spawnCondition = !spawnCondition;
            }


            //spawn arealarn aralklar: 
            //area0: x: -7 to -1, y: 5 to 2
            //area1: x: 7 to 1, y: 5 to 2
            //area2: x: -7 to -1, y: 0 to -3
            //area3: x: 7 to 1, y: 0 to -3


        }

        else if ((1.5f <= currentTransformX && currentTransformX <= 6.5f) && (-2.5f <= currentTransformY && currentTransformY <= -0.5f))
        {

            int spawnIndex = Random.Range(1, 3);
            if (spawnIndex == 1 && spawnCondition)
            {
                float xTransform = Random.Range(-6f, -1.5f);
                float yTransform = Random.Range(2.5f, 4f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);


                spawnCondition = !spawnCondition;
            }
            else if (spawnIndex == 2 && spawnCondition)
            {
                float xTransform = Random.Range(1.5f, 6f);
                float yTransform = Random.Range(2.5f, 4f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);


                spawnCondition = !spawnCondition;
            }


            else if (spawnIndex == 3 && spawnCondition)
            {
                float xTransform = Random.Range(1.5f, 6f);
                float yTransform = Random.Range(-2, -0.5f);

                bulletSpawnLoc = new Vector2(xTransform, yTransform);



                spawnCondition = !spawnCondition;
            }


            //spawn arealarn aralklar: 
            //area0: x: -7 to -1, y: 5 to 2
            //area1: x: 7 to 1, y: 5 to 2
            //area2: x: -7 to -1, y: 0 to -3
            //area3: x: 7 to 1, y: 0 to -3


        }

        
        
        targetPos.x = Random.Range(-6, 6);
        targetPos.y = Random.Range(-2, 4);

    }


    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);



        if (Vector2.Distance(transform.position, targetPos) <= 0.1f)
        {
            targetPos.x = Random.Range(-6, 6);
            targetPos.y = Random.Range(-2, 4);
        }
        else return;

    }


    private void OnMouseUpAsButton()
    {
        if (duelManagerScript.clickedBulletCount != 1)
        {

            Instantiate(mastermindBulletPrefab, bulletSpawnLoc, Quaternion.identity);

        }
        duelManagerScript.clickedBulletCount = duelManagerScript.clickedBulletCount - 1;
        Destroy(this.gameObject);

    }
}
