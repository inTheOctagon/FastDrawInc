using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        Destroy(this.gameObject);
    }
}
