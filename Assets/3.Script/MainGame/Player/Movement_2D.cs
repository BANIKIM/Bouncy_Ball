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


    // RayCast count�� ���� ������ ����
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
    private void Update() //���� üũ
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


    //����
    public void JumpTo() // üũ
    {
        /*if(JumpForce != 0) ���Ŀ� ���� ������ ���ؼ� �� ����
        {
            velocity.y = JumpForce;
            return;
        }*/
        if(colliderChecker.Down)
        {
            velocity.y = this.JumpForce;
            
        }    
    }
    //�� �극��ũ
    public void moveto(float x)
    {
        //���� ������ �̵������� �� �¿� ����Ű�� �����ٸ�?
        if(x != 0 && movetype != MoveType.Updown)
        {
            movetype = MoveType.Updown;
        }
        velocity.x = x * Movespeed;
    }
    //String ������
    public void SetupStraightMove(MoveType type, Vector3 position)
    {
        movetype = type;
        transform.position = position;
        velocity.y = 0;
    }

    //spacing ���
    private void CalculateRayCastSpacing() //üũ
    {
        Bounds bounds = collider2D.bounds;
        bounds.Expand(SkinWidth * -2);

        Horizontal_Spaning = bounds.size.y / (Horizontal_count - 1);
        Vertical_Spaning = bounds.size.x / (Vertical_count - 1);

    }

    //collider corner ��ġ ���� 
    private void Update_colliderCorner() // üũ
    {
        Bounds bounds = collider2D.bounds;
        bounds.Expand(SkinWidth * -2);

        colliderCornor.Topleft = new Vector2(bounds.min.x, bounds.max.y);
        colliderCornor.Bottomleft = new Vector2(bounds.min.x, bounds.min.y);
        colliderCornor.Bottomright = new Vector2(bounds.max.x, bounds.min.y);


    }

    private void UpdateMovement() //üũ
    {
        if (movetype.Equals(MoveType.Updown))
        {
            //y������ �����Դϴ�.
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.x = (int)movetype * Movespeed;
        }

        Vector3 currentVelocity = velocity * Time.deltaTime;
        //�¿�� �����϶� 
        if (currentVelocity.x != 0)
        {
            RayCastHorizontal(ref currentVelocity);
            //Raycast ��� �� ����� �ּ���

        }
        if (currentVelocity.y != 0)
        {
            //Raycast ��� �� ����� �ּ���
            RayCastVertical(ref currentVelocity);
        }
        transform.position += currentVelocity;
    }

    private void RayCastHorizontal(ref Vector3 velocity) //üũ
    {
        //ref�� 
        //���� �޼ҵ忡�� ����� ���� ����
        //Mathf.Sign �������� ������� ��ȣ�� Ȯ���ϴ� �޼ҵ�
        float direction = Mathf.Sign(velocity.x);///�̵����� �� :1 | �� : -1
        float distance = Mathf.Abs(velocity.x) + SkinWidth; //��������
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

            if(hit)//hit Null�� �ƴϳ�?
            {
                //x�� �ӷ��� ������ ������Ʈ ������ �Ÿ��� ����(�Ÿ��� 0�̸� �ӷµ� 0)
                velocity.x = (hit.distance * SkinWidth) * direction;
                //������ �߻�Ǵ� ������ �Ÿ�����
                distance = hit.distance;
                //���� �������, �΋H�� ���� ������ true ����
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
