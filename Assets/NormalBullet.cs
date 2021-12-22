using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    private bool spawnCondition;
    private void Awake()
    {
        float xTransform = transform.position.x;
        float yTransform = transform.position.y;
        if ((-7 <= xTransform && xTransform <= -1) && (2 <= yTransform && yTransform <= 5))
        {

            int spawnIndex = Random.Range(1, 3);
            if (spawnIndex == 1 && spawnCondition)
            {
                //do shit
            }
            if (spawnIndex == 1 && spawnCondition)
            {
                //do shit

            }


            if (spawnIndex == 1 && spawnCondition)
            {
                //do shit


            }

            if (spawnIndex == 1 && spawnCondition)
            {
                //do shit

            }

        }

        //spawn arealarn aralklar: 
        //area0: x: -7 to -1, y: 5 to 2
        //area1: x: 7 to 1, y: 5 to 2
        //area2: x: -7 to -1, y: 0 to -3
        //area3: x: 7 to 1, y: 0 to -3

        
    }
    private void OnMouseUpAsButton()
    {
        Destroy(this.gameObject);
    }

}
