using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarAndFeatherManager : MonoBehaviour
{
    
    [SerializeField] Texture2D tarredAndFeatherdCursor;
    [SerializeField] Texture2D normalCursor;

    
    
    private RaycastHit2D tarAndFeatherHit;
    private Vector2 mousePos;
    private Vector2 cursorHotspot;




    




    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var offset = new Vector2(0.1f, 0.1f);
        transform.position = mousePos;
        //var boardHit = Physics2D.Raycast(mousePos + offset, Vector2.zero);

        //if (boardHit.collider == null)
        //{
        //    cursorHotspot = new Vector2(normalCursor.width / 2, normalCursor.height / 2);
        //    Cursor.SetCursor(normalCursor, cursorHotspot, CursorMode.ForceSoftware);

        //}
        //else if(boardHit.collider.CompareTag("taf"))
        //{
        //    cursorHotspot = new Vector2(tarredAndFeatherdCursor.width / 2, tarredAndFeatherdCursor.height / 2);
        //    Cursor.SetCursor(tarredAndFeatherdCursor, cursorHotspot, CursorMode.ForceSoftware);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("taf"))
        {
            cursorHotspot = new Vector2(tarredAndFeatherdCursor.width / 2, tarredAndFeatherdCursor.height / 2);
            Cursor.SetCursor(tarredAndFeatherdCursor, cursorHotspot, CursorMode.ForceSoftware);
            Debug.Log("we in");
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("taf"))
        {
            cursorHotspot = new Vector2(normalCursor.width / 2, normalCursor.height / 2);
            Cursor.SetCursor(normalCursor, cursorHotspot, CursorMode.ForceSoftware);
        }
        
    }

}
