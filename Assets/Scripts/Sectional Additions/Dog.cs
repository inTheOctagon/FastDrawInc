using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    [SerializeField] float dogSpeed = 3;
    Vector2 targetPos;
    Vector3 startPos;
    float startLocalScaleX;

    [SerializeField] GameObject duelManager;

    
    [SerializeField] AudioClip grawlingDog;

    


    private void Start()
    {

        startPos = transform.position;
        startLocalScaleX = transform.localScale.x;

    }

    private void Update()
    {
        DogMovement();
        DogReaching();
        DogFlipper();

    }

    private void DogFlipper()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.x > transform.position.x)
        {
            transform.localScale = new Vector3(-startLocalScaleX, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(startLocalScaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    private void DogMovement()
    {
        if (duelManager.GetComponent<DuelManager>().timerCondition)
        {
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, dogSpeed * Time.deltaTime);
            this.gameObject.GetComponent<Animator>().SetBool("DogAnimationCondition", true);


        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, startPos, dogSpeed * Time.deltaTime);
            if(transform.position == startPos) this.gameObject.GetComponent<Animator>().SetBool("DogAnimationCondition", false);
        }
    }

    private void DogReaching()
    {
        if(duelManager.GetComponent<DuelManager>().timerCondition && Vector2.Distance(transform.position, targetPos) < 0.3f)
        {
            duelManager.GetComponent<DuelManager>().OpponentWinOutputFunction();
            GetComponent<AudioSource>().PlayOneShot(grawlingDog,0.5f);
        }
    }
}
