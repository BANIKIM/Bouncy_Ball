using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ColliderCornor
{
    public Vector2 Topleft;
    public Vector2 Bottomleft;
    public Vector2 Bottomright;

}

public struct ColliderChecker
{
    public bool Up;
    public bool Down;
    public bool Left;
    public bool Right;

    public void Reset()
    {
        Up = false;
        Down = false;
        Left = false;
        Right = false;
    }
}


public enum MoveType { Left = -1, Updown = 0, Right = 1 }

public class Movement_2D : MonoBehaviour
{
    [Header("Raycast Collision")]
    [SerializeField] private LayerMask CollisionLayer;

    [Header("Raycast Count")]
    [SerializeField] private int Horizontal_count = 4;
    [SerializeField] private int Vertical_count = 4;


    // RayCast count에 따른 일정한 간격
    private float Horizontal_Spaning;
    private float Vertical_Spaning;

    [Header("Movement")]
    [SerializeField] private float Movespeed;
    [SerializeField] private float JumpForce = 10;
    private float gravity = -20.0f;

    private Vector3 velocity;
    private readonly float SkinWidth = 0.015f;

    private Collider2D collider2D;
    private ColliderCornor colliderCornor;
    private ColliderChecker colliderChecker;

    public MoveType movetype { get; private set; }

    //-------------------------------------------------------
    private void Awake()
    {
        collider2D = GetComponent<Collider2D>();
        movetype = MoveType.Updown;
    }
    private void Update() //순서 체크
    {
        CalculateRayCastSpacing();
        Update_colliderCorner();
        colliderChecker.Reset();
        UpdateMovement();

        if(colliderChecker.Up || colliderChecker.Down)
        {
            velocity.y = 0;
        }
        JumpTo();
    }


    //점프
    public void JumpTo() // 체크
    {
        /*if(JumpForce != 0) 추후에 점프 발판을 위해서 쓸 예정
        {
            velocity.y = JumpForce;
            return;
        }*/
        if(colliderChecker.Down)
        {
            velocity.y = this.JumpForce;
            
        }    
    }
    //공 브레이크
    public void moveto(float x)
    {
        //왼쪽 오른쪽 이동상태일 때 좌우 방향키를 누른다면?
        if(x != 0 && movetype != MoveType.Updown)
        {
            movetype = MoveType.Updown;
        }
        velocity.x = x * Movespeed;
    }
    //String 공상태
    public void SetupStraightMove(MoveType type, Vector3 position)
    {
        movetype = type;
        transform.position = position;
        velocity.y = 0;
    }

    //spacing 계산
    private void CalculateRayCastSpacing() //체크
    {
        Bounds bounds = collider2D.bounds;
        bounds.Expand(SkinWidth * -2);

        Horizontal_Spaning = bounds.size.y / (Horizontal_count - 1);
        Vertical_Spaning = bounds.size.x / (Vertical_count - 1);

    }

    //collider corner 위치 갱신 
    private void Update_colliderCorner() // 체크
    {
        Bounds bounds = collider2D.bounds;
        bounds.Expand(SkinWidth * -2);

        colliderCornor.Topleft = new Vector2(bounds.min.x, bounds.max.y);
        colliderCornor.Bottomleft = new Vector2(bounds.min.x, bounds.min.y);
        colliderCornor.Bottomright = new Vector2(bounds.max.x, bounds.min.y);


    }

    private void UpdateMovement() //체크
    {
        if (movetype.Equals(MoveType.Updown))
        {
            //y축으로 움직입니다.
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.x = (int)movetype * Movespeed;
        }

        Vector3 currentVelocity = velocity * Time.deltaTime;
        //좌우로 움직일때 
        if (currentVelocity.x != 0)
        {
            RayCastHorizontal(ref currentVelocity);
            //Raycast 쏘는 거 만들어 주세요

        }
        if (currentVelocity.y != 0)
        {
            //Raycast 쏘는 거 만들어 주세요
            RayCastVertical(ref currentVelocity);
        }
        transform.position += currentVelocity;
    }

    private void RayCastHorizontal(ref Vector3 velocity) //체크
    {
        //ref란 
        //내부 메소드에서 적용된 값을 변경
        //Mathf.Sign 음수인지 양수인지 부호를 확인하는 메소드
        float direction = Mathf.Sign(velocity.x);///이동방향 오 :1 | 왼 : -1
        float distance = Mathf.Abs(velocity.x) + SkinWidth; //광선길이
        Vector2 rayPosition = Vector2.zero;
        RaycastHit2D hit;

        for (int i = 0; i < Horizontal_count; i++)
        {
            rayPosition = (direction == 1) ? colliderCornor.Bottomright : colliderCornor.Bottomleft;
            rayPosition += Vector2.up * (Horizontal_Spaning * i);

            hit = Physics2D.Raycast(
                rayPosition,
                Vector2.right * direction,
                distance,
                CollisionLayer);

            if(hit)//hit Null이 아니냐?
            {
                //x축 속력을 광선과 오브젝트 사이의 거리로 설정(거리가 0이면 속력도 0)
                velocity.x = (hit.distance * SkinWidth) * direction;
                //다음에 발사되는 광선의 거리설정
                distance = hit.distance;
                //현재 진행방향, 부딫힌 방향 정보를 true 변경
                colliderChecker.Left = (direction == -1);
                colliderChecker.Right = (direction == 1);

            }
            Debug.DrawRay(rayPosition, 
                rayPosition+Vector2.right*direction * distance,
                Color.blue);
        }
    }

    private void RayCastVertical(ref Vector3 velocity)
    {
        float direction = Mathf.Sign(velocity.y);
        float distance = Mathf.Abs(velocity.y) + SkinWidth;
        Vector2 rayposition = Vector2.zero;
        RaycastHit2D hit;


        for (int i = 0; i < Vertical_count; i++)
        {
            rayposition = (direction == 1) ? colliderCornor.Topleft : colliderCornor.Bottomleft;
            rayposition += Vector2.right * (Vertical_Spaning * i + velocity.x);

            hit = Physics2D.Raycast(rayposition, Vector2.up * direction, distance, CollisionLayer);
            if(hit)
            {
                velocity.y = (hit.distance - SkinWidth) * direction;
                distance = hit.distance;
                colliderChecker.Down = (direction == -1);
                colliderChecker.Up = (direction == 1);
            }
            Debug.DrawRay(rayposition,
               rayposition + Vector2.up * direction * distance,
               Color.yellow);
        }
    }



}
