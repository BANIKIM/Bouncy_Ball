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
