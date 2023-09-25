using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputControll : MonoBehaviour
{
    [SerializeField] private Camera main;
    [SerializeField] private CameraControll cameraControll;


    private Vector2 previousMousePostion;
    private Vector2 CurrentMousePostion;

    private Tile_Type current_Tpye = Tile_Type.Empty;

    private Tile PlayerTile;


    private void Update()
    {
        //���� ���콺�� UI ĵ���� ������Ʈ ���� ������ true
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        UpdateCamera();
        RaycastHit hit;


        if (Input.GetMouseButton(0))
        {
            // RayCast ��� ������ ������ ����, ������ �´� ������Ʈ�� ������ �ҷ��´�.


            //ScreenPointToRay ī�޶�� ���� ȭ���� ���콺 ������ ��ġ�� �����ϴ� ������ ����
            Ray ray = main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                Tile tile = hit.transform.GetComponent<Tile>();
                if (tile != null)
                {
                    if (current_Tpye.Equals(Tile_Type.Player))
                    {
                        if (PlayerTile != null)
                        {
                            PlayerTile.Tiletype = Tile_Type.Empty;
                        }
                        PlayerTile = tile;
                    }

                    tile.Tiletype = current_Tpye;
                }
            }
        }
    }

    public void SetTileType(int tiletype)
    {
        current_Tpye = (Tile_Type)tiletype;
    }
    public void UpdateCamera()
    {
        //Ű���� �Է����� ī�޶� �̵�
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        cameraControll.setPosition(x, y);

        //���콺 �� ��ư�� �̿��Ͽ� ī�޶� �̵�
        if (Input.GetMouseButtonDown(2))
        {
            CurrentMousePostion = previousMousePostion = Input.mousePosition;
        }
        else if (Input.GetMouseButton(2))
        {
            CurrentMousePostion = Input.mousePosition;
            if (previousMousePostion != CurrentMousePostion)
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
