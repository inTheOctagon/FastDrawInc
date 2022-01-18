using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastermindBullet : MonoBehaviour
{
    [SerializeField] GameObject mastermindBulletPrefab;

    Vector2 bulletSpawnLoc;

    DuelManager duelManagerScript;

    [SerializeField] AudioClip clickingClip;

    //target pos
    Vector2 targetPos;
    

    [SerializeField] float moveSpeed;




    private void Awake()
    {
        //bullet size
        this.gameObject.transform.localScale = new Vector2(ValueManager.newBulletSize, ValueManager.newBulletSize);

        //clicked bullet count context
        duelManagerScript = GameObject.Find("Duel Manager").GetComponent<DuelManager>();

        bulletSpawnLoc.x = Random.Range(-6, 6);
        bulletSpawnLoc.y = Random.Range(-1, 0);

        targetPos = new Vector2(0, 4.5f);

    }


    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);



        if (Vector2.Distance(transform.position, targetPos) <= 0.1f)
        {
            if(duelManagerScript.timerCondition)
            {
                duelManagerScript.OpponentWinOutputFunction();
            }
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
        GetComponent<AudioSource>().PlayOneShot(clickingClip, 0.4f);
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        moveSpeed = 0;
        StartCoroutine("destroyaWithTimer");
    }
    IEnumerator destroyaWithTimer()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);

    }
}
