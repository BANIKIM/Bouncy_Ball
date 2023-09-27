using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestorybyTime : MonoBehaviour
{
    [SerializeField] private float destroyTime;

    private void Awake()
    {
        //destroyTime 시간 뒤에 삭제됨.
        Destroy(gameObject,destroyTime);
    }
}
