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
        //�������� �Ծ��� �� ȣ���� �޼ҵ�
        Destroy(gameObject);
    }
}
