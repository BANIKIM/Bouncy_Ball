using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControll : MonoBehaviour
{
    [SerializeField] private Camera main;
    [SerializeField] private CameraControll cameraControll;


    private Vector2 previousMousePostion;
    private Vector2 CurrentMousePostion;

    private void Update()
    {
        UpdateCamera();
    }


    public void UpdateCamera()
    {
        //Ű���� �Է����� ī�޶� �̵�
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        cameraControll.setPosition(x, y);
        
        //���콺 �� ��ư�� �̿��Ͽ� ī�޶� �̵�
        if(Input.GetMouseButton(2))
        {
            CurrentMousePostion = previousMousePostion = Input.mousePosition;
        }
        else if (Input.GetMouseButton(2))
        {
            CurrentMousePostion = Input.mousePosition;
            if(previousMousePostion!=CurrentMousePostion)
            {
                Vector2 move = (previousMousePostion - CurrentMousePostion) * 0.5f;
                cameraControll.setPosition(move.x, move.y);
            }
        }
        previousMousePostion = CurrentMousePostion;

        //���� �� �ƿ� Mouse ScrollWheel
        float distance = Input.GetAxisRaw("Mouse ScrollWheel");
        cameraControll.setOrthographicSize(-distance);

    }
}
