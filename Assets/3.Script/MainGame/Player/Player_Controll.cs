using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controll : MonoBehaviour
{
    private Movement_2D movement;

    public void Setup(Vector2Int position)
    {
        movement = GetComponent<Movement_2D>();
        transform.position = new Vector3(position.x, position.y,0);

    }


    private void Update()
    {
        UpdateMove();
    }


    private void UpdateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        movement.moveto(x);
    }

}
