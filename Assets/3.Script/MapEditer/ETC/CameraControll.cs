using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    [SerializeField] private TileMap2D tilemap;
    private Camera main;

    //ī�޶� �̵��ӵ� 
    [SerializeField] private float Movespeed;
    //ī�޶� �ܼӵ�
    [SerializeField] private float Zoomspeed;
    //2D ���� ī�޶� �þ� �ּ�ũ��
    [SerializeField] private float MinViewsize=2;
    //2D ���� ī�޶� �þ� �ִ�ũ��
    [SerializeField] private float MaxViewsize;


    private float wDelta = 0.4f;
    private float hDelta = 0.6f;

    private void Awake()
    {
        main = GetComponent<Camera>();//ĳ��
    }
    public void SetupCamera()// ī�޶� �ʱ� ����
    {
        //�� ũ�� ����
        int width = tilemap.width;
        int hieght = tilemap.height;

        //ī�޶� �þ� ����
        float size = (width > hieght) ? width * wDelta : hieght*hDelta;
        main.orthographicSize = size;//ī�޶� ���� ������ ������ �� �ִ�

        if(hieght>width)
        {
            Vector3 position = new Vector3(0, 0.05f, -10f);// ī�޶� �� Ÿ���� ����
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
        if(size == 0)//����ó��
        {
            return;
        }

        main.orthographicSize += size * Zoomspeed * Time.deltaTime;

        main.orthographicSize = Mathf.Clamp(main.orthographicSize, MinViewsize, MaxViewsize);//Mathf.Clamp ������ ����� �ʰ� ���ִ� �޼���
    }

}
