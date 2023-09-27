using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBroke : Tile_G
{
    [SerializeField] private GameObject TileBrokeEffect;
    public override void collsition(collisionDirction direction)
    {
        //Ÿ���� �μ����� ȿ�� ���
        Instantiate(TileBrokeEffect, transform.position, Quaternion.identity);
        if(direction==collisionDirction.down)
        {
            movement.JumpTo();
        }
        Destroy(gameObject);
    }
}
