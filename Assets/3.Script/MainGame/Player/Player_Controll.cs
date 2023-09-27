using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controll : MonoBehaviour
{
    private Movement_2D movement;
    [SerializeField] private TileMap2D tileMap2D;

    private float deathLimitY;

    public void Setup(Vector2Int position, int mapsizey)
    {
        movement = GetComponent<Movement_2D>();
        transform.position = new Vector3(position.x, position.y,0);

        deathLimitY = -mapsizey / 2;

    }


    private void Update()
    {
        if(transform.position.y <= deathLimitY)
        {
            // �ŷε带 ����� �ּ��� ��𼭵� �� �� �ְ� todo
            SceneLoader.LoadScene();
        }

        UpdateMove();
        UpdateCollition(); //����

    }

    private void UpdateCollition()
    {
        if(movement.iscollisionChecker.Up)
        {
            CollitionToTile(collisionDirction.up);
        }
        else if(movement.iscollisionChecker.Down)
            {
            CollitionToTile(collisionDirction.down); //����

        }
    }
    private void CollitionToTile(collisionDirction direction)
    {
        Tile_G tile = movement.Hittransfrom.GetComponent<Tile_G>();
        if(tile!= null)
        {
            tile.collsition(direction); //����
        }
    }

    private void UpdateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        movement.moveto(x);
    }


    private void OnTriggerEnter2D(Collider2D collsition)
    {
        if(collsition.CompareTag("Item"))
        {
            tileMap2D.Getcoin(collsition.gameObject);
         //   Destroy(collsition.gameObject); // ���� ���� ������Ʈ�� �ı�
        }
    }

}
