using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item_Type
{
    coin =10,

}


public class Item : MonoBehaviour
{
    public void Exit()
    {
        //아이템을 먹었을 때 호출할 메소드
        Destroy(gameObject);
    }
}
