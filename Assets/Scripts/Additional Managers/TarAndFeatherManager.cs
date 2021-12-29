using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarAndFeatherManager : MonoBehaviour
{
    [SerializeField] GameObject cursorManager;
    [SerializeField] Texture2D tarredAndFeatherdCursor;
    [SerializeField] Texture2D normalCursor;
    private GameObject bullet;
    private RaycastHit2D tarAndFeatherHit;
    private Vector2 mousePos;
    private Vector2 cursorHotspot;

   


    private void Start()
    {
        cursorHotspot = new Vector2(normalCursor.width / 2, normalCursor.height / 2);
    }




    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tarAndFeatherHit = Physics2D.Raycast(mousePos, Vector2.zero);

        if (tarAndFeatherHit.collider.CompareTag("TarAndFeather"))
        {
            Cursor.SetCursor(tarredAndFeatherdCursor, cursorHotspot, CursorMode.ForceSoftware);
        }
        else return;
        

    }


    IEnumerator tarAndFeatherCursor()
    {
        Cursor.SetCursor(tarredAndFeatherdCursor, cursorHotspot, CursorMode.ForceSoftware);
        yield return new WaitForSeconds(1);
        Cursor.SetCursor(normalCursor, cursorHotspot, CursorMode.ForceSoftware);

    }
}
