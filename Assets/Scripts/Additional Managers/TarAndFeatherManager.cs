using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarAndFeatherManager : MonoBehaviour
{
    [SerializeField] GameObject cursorManager;
    [SerializeField] Texture2D tarredAndFeatherdCursor;
    [SerializeField] Texture2D normalCursor;
    private RaycastHit2D tarAndFeatherHit;
    private Vector2 mousePos;
    
    


   


    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tarAndFeatherHit = Physics2D.Raycast(mousePos, Vector2.zero);
        
        if(tarAndFeatherHit.collider.CompareTag("TarAndFeather"))
        {
            StartCoroutine("tarAndFeatherCursor");
        }

    }


    IEnumerator tarAndFeatherCursor()
    {
        cursorManager.GetComponent<CursorManager>().cursorTexture = tarredAndFeatherdCursor;
        var bullet = GameObject.FindGameObjectWithTag("Bullet");
        bullet.GetComponent<CircleCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        bullet.GetComponent<CircleCollider2D>().enabled = true;
        cursorManager.GetComponent<CursorManager>().cursorTexture = normalCursor;

    }
}
