using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestorybyTime : MonoBehaviour
{
    [SerializeField] private float destroyTime;

    private void Awake()
    {
        //destroyTime �ð� �ڿ� ������.
        Destroy(gameObject,destroyTime);
    }
}
