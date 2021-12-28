using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueManager : MonoBehaviour
{
    [SerializeField] GameObject normalBulletPrefab;

    public static float bulletsize = 1;

    private void Start()
    {
        normalBulletPrefab.transform.localScale = new Vector2(bulletsize, bulletsize);
    }

}
