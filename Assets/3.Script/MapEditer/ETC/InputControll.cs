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
        //키보드 입력으로 카메라 이동
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        cameraControll.setPosition(x, y);
        
        //마우스 휠 버튼을 이용하여 카메라 이동
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

        //줌인 줌 아웃 Mouse ScrollWheel
        float distance = Input.GetAxisRaw("Mouse ScrollWheel");
        cameraControll.setOrthographicSize(-distance);

    }
}
