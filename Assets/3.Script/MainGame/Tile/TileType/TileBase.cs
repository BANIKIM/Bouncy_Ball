using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBase : Tile_G
{
    public override void collsition(collisionDirction direction)
    {
        if(direction == collisionDirction.down)
        {
            movement.JumpTo();
        }
    }
}
