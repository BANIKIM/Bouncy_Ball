using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBoom : Tile_G
{
    public override void collsition(collisionDirction direction)
    {
        SceneLoader.LoadScene();
    }
}
