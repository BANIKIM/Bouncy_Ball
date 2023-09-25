using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    [SerializeField] private TileMap2D tilemap;
    private Camera main;

    //카메라 이동속도 
    [SerializeField] private float Movespeed;
    //카메라 줌속도
    [SerializeField] private float Zoomspeed;
    //2D 한정 카메라 시야 최소크기
    [SerializeField] private float MinViewsize=2;
    //2D 한정 카메라 시야 최대크기
    [SerializeField] private float MaxViewsize;


    private float wDelta = 0.4f;
    private float hDelta = 0.6f;

    private void Awake()
    {
        main = GetComponent<Camera>();//캐싱
    }
    public void SetupCamera()// 카메라 초기 설정
    {
        //맵 크기 정보
        int width = tilemap.width;
        int hieght = tilemap.height;

        //카메라 시야 설정
        float size = (width > hieght) ? width * wDelta : hieght*hDelta;
        main.orthographicSize = size;//카메라 보는 범위를 설정할 수 있다

        if(hieght>width)
        {
            Vector3 position = new Vector3(0, 0.05f, -10f);// 카메라 한 타일의 단위
            position.y *= hieght;
            transform.position = position;
        }
        MaxViewsize = main.orthographicSize;
    }


    public void setPosition(float x, float y)
    {
        transform.position += new Vector3(x, y, 0) * Movespeed * Time.deltaTime;
    }

    public void setOrthographicSize(float size)
    {
        if(size == 0)//예외처리
        {
            return;
        }

        main.orthographicSize += size * Zoomspeed * Time.deltaTime;

        main.orthographicSize = Mathf.Clamp(main.orthographicSize, MinViewsize, MaxViewsize);//Mathf.Clamp 범위를 벗어나지 않게 해주는 메서드
    }

}
