using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    
    public Texture2D cursorTexture;
    private Vector2 cursorHotspot;

    private void Start()
    {
        cursorHotspot = new Vector2(cursorTexture.width / 4, cursorTexture.height / 4);
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.ForceSoftware);
    }

    
}
