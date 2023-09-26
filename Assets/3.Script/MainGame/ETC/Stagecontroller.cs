using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stagecontroller : MonoBehaviour
{
    // Tilemap 2D ������Ʈ�� �����Ͽ��� ���� ���������� ����� ��
    [SerializeField] TileMap2D tilemap2d;
    [SerializeField] Player_Controll playerControll;
    [SerializeField] Cameracontroll_G cameracontroll_G;


    private void Awake()
    {
        MapData_Load load = new MapData_Load();

        MapData map = load.Load("Stage01");
        tilemap2d.Generate_Tilemap(map);

        playerControll.Setup(map.PlayerPosition);
        cameracontroll_G.Setup(map.Mapsize.x, map.Mapsize.y);
    }


}
