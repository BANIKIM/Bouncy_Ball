using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TileType_G
{
    Empty = 0,
    Base,
    Borke,
    Boom,
    Jump,
    StraightLeft,
    StraightRight,
    Blink,
    LastIndex
}

public enum collisionDirction {up=0,down}




/*
public class Tile_G : MonoBehaviour
{
    [SerializeField] private Sprite[] Image;
    private SpriteRenderer renderer;
    private TileType_G tiletype;

    public TileType_G Tiletype
    {
        get => tiletype;
        set
        {
            tiletype = value;
            renderer.sprite = Image[(int)tiletype - 1];
        }
    }

    public void Setup(TileType_G tile)
    {
        renderer = GetComponent<SpriteRenderer>();
        tiletype = tile;
    }

}
*/

public abstract class Tile_G:MonoBehaviour
{
    protected Movement_2D movement;
    public virtual void Setup(Movement_2D movement_2D)//구현선택
    {
        movement = movement_2D;
    }
    public abstract void collsition(collisionDirction direction); // 무조건 구현

}