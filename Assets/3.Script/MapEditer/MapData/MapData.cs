using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * 객채 직렬화
 * 직렬화란? 객체의 상태를 메모리나 영구 저장 장치에 저장가능한 0,1로 순서를 바꾸는 것
 * 직렬화가 없으면?
 * 기본 데이터형식(int,flaot,...)만 파일 입출력 가능.
 * 클래스 구조체같은 데이터 컨테이너방식, 복합데이터 등 형식의
 * 파일 입출력을 위해서 모든 변수를 저장하는 방법으로 정의하여야 한다.
 */



[System.Serializable]//객체 직렬화


public class MapData 
{
    public Vector2Int Mapsize;
    public int[] Mapdata;
    public Vector2Int PlayerPosition;


}
