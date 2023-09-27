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
            // 신로드를 만들어 주세요 어디서든 쓸 수 있게 todo
            SceneLoader.LoadScene();
        }

        UpdateMove();
        UpdateCollition(); //여기

    }

    private void UpdateCollition()
    {
        if(movement.iscollisionChecker.Up)
        {
            CollitionToTile(collisionDirction.up);
        }
        else if(movement.iscollisionChecker.Down)
            {
            CollitionToTile(collisionDirction.down); //여기

        }
    }
    private void CollitionToTile(collisionDirction direction)
    {
        Tile_G tile = movement.Hittransfrom.GetComponent<Tile_G>();
        if(tile!= null)
        {
            tile.collsition(direction); //여기
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
         //   Destroy(collsition.gameObject); // 닿인 게임 오브젝트를 파괴
        }
    }

}
