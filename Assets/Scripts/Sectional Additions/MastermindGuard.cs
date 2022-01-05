using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MastermindGuard : MonoBehaviour
{
    Vector3 startPos;
    Vector3 targetPos;

    [SerializeField] float moveDistance;

    [SerializeField] bool UpDown;
    [SerializeField] bool DownUp;
    [SerializeField] bool RightLeft;
    [SerializeField] bool LeftRight;
    [SerializeField] float moveSpeed;

    [SerializeField] GameObject bustedText;

    float TimeInterval = 0;

    
    
    
    void Awake()
    {
        startPos = transform.position;
        targetPos = startPos + new Vector3(moveDistance, 0);

        //bullet size

        this.gameObject.transform.localScale = new Vector2(ValueManager.newBulletSize, ValueManager.newBulletSize);

        if (DownUp) targetPos = startPos + new Vector3(0, -moveDistance);
        else if (RightLeft) targetPos = startPos + new Vector3(moveDistance, 0);
        else if(LeftRight) targetPos = startPos + new Vector3(-moveDistance, 0);
        else if (UpDown) targetPos = startPos + new Vector3(0, +moveDistance);
    }
    

   
    void Update()
    {
        if(GameObject.Find("Duel Manager").GetComponent<DuelManager>().timerCondition)
        {
            TimeInterval += 0.3f * Time.deltaTime;
        }

        else if(GameObject.Find("Duel Manager").GetComponent<DuelManager>().timerCondition == false)
        {
            TimeInterval = 0;
        }

        if (GameObject.Find("Duel Manager").GetComponent<DuelManager>().timerCondition)
        {
            
            transform.position = Vector3.Lerp(startPos, targetPos, Mathf.PingPong(TimeInterval * moveSpeed, 1));
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, moveSpeed * Time.deltaTime);
            
        }



        //animation part
        if (GameObject.Find("Duel Manager").GetComponent<DuelManager>().timerCondition)
        {

            gameObject.GetComponent<Animator>().SetBool("Walk", true);


        }

        else if (transform.position == startPos /*GameObject.Find("Duel Manager").GetComponent<DuelManager>().timerCondition == false*/)
        {
            
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            
        }
        else return;

    }


    private void OnMouseOver()
    {
        if (GameObject.Find("Duel Manager").GetComponent<DuelManager>().timerCondition)
        {
            StartCoroutine("BustedText");
            GameObject.Find("Duel Manager").GetComponent<DuelManager>().OpponentWinOutputFunction();
        }
        else return;
    }

    IEnumerator BustedText()
    {
        bustedText.SetActive(true);
        bustedText.transform.position = Input.mousePosition;
        yield return new WaitForSeconds(1);
        bustedText.SetActive(false);
    }

}
