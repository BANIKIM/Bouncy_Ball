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
        //현재 마우스가 UI 캔버스 오브젝트 위에 있으면 true
        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        UpdateCamera();
        RaycastHit hit;


        if (Input.GetMouseButton(0))
        {
            // RayCast 어떠한 기준의 광선을 쏴서, 광선을 맞는 오브젝트의 정보를 불러온다.


            //ScreenPointToRay 카메라로 부터 화면의 마우스 포지션 위치를 관통하는 광선을 생성
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
        //키보드 입력으로 카메라 이동
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        cameraControll.setPosition(x, y);

        //마우스 휠 버튼을 이용하여 카메라 이동
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

        //줌인 줌 아웃 Mouse ScrollWheel
        float distance = Input.GetAxisRaw("Mouse ScrollWheel");
        cameraControll.setOrthographicSize(-distance);

    }
}
