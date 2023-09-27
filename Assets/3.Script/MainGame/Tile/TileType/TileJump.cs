using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileJump : Tile_G
{
    [SerializeField] private float Jumpforce;
    public override void collsition(collisionDirction direction)
    {
       if(direction == collisionDirction.down)
        {
            movement.JumpTo(Jumpforce);
        }
    }
}
