using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBlink : Tile_G
{
    private List<TileBlink> blinks;
    public void SetupBlinkTile(List<TileBlink> blinks)
    {
        this.blinks = new List<TileBlink>();
        for (int i = 0; i < blinks.Count; i++)
        {
            if(this.blinks[i]!=this)
            {
                this.blinks.Add(blinks[i]);
            }
        }
    }
    public override void collsition(collisionDirction direction)
    {
        if(direction == collisionDirction.down)
        {
            int index = Random.Range(0, blinks.Count);
            movement.transform.position = blinks[index].transform.position + Vector3.up;
            movement.JumpTo();
        }
    }
}
