using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * ��ä ����ȭ
 * ����ȭ��? ��ü�� ���¸� �޸𸮳� ���� ���� ��ġ�� ���尡���� 0,1�� ������ �ٲٴ� ��
 * ����ȭ�� ������?
 * �⺻ ����������(int,flaot,...)�� ���� ����� ����.
 * Ŭ���� ����ü���� ������ �����̳ʹ��, ���յ����� �� ������
 * ���� ������� ���ؼ� ��� ������ �����ϴ� ������� �����Ͽ��� �Ѵ�.
 */



[System.Serializable]//��ü ����ȭ


public class MapData 
{
    public Vector2Int Mapsize;
    public int[] Mapdata;
    public Vector2Int PlayerPosition;


}
