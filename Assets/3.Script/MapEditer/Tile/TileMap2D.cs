using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TileMap2D : MonoBehaviour
{
    [Header("TilePrefabs")]
    [SerializeField] private GameObject TilePrefabs;

    [Header("InputField")]
    [SerializeField] private InputField input_Width;
    [SerializeField] private InputField input_Height;


    public int width { get; private set; } = 10;
    public int height { get; private set; } = 10;

    public List<Tile> tileList { get; private set; }

    private void Awake()
    {
        input_Width.text = width.ToString();
        input_Height.text = height.ToString();
        tileList = new List<Tile>();

    }
    //��ư �̺�Ʈ�� ���� �����̶� �ۺ����� ����
    public void Generate_Tilemap()
    {
        if(int.TryParse(input_Width.text,out int _width) && int.TryParse(input_Height.text, out int _height))
        {
            width = _width;
            height = _height;
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector3 position = new Vector3((-width*0.5f+0.5f)+x,(height*0.5f - 0.5f)-y,0);

                SpawnTile(Tile_Type.Empty, position);

            }
        }

    }

    private void SpawnTile(Tile_Type type, Vector3 position)
    {
        GameObject clone = Instantiate(TilePrefabs, position, Quaternion.identity);//Instantiate ������Ʈ ���� / Quaternion.identity ȸ���� ���� �ʴ´�.
        clone.name = "Tile";
        clone.transform.SetParent(transform);// TileMap ������Ʈ ���
        Tile tile = clone.GetComponent<Tile>();
        tile.Setup(type);

        tileList.Add(tile);
    }
}
