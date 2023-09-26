using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;//�߰�
using System.IO;//�ʿ�

/*
 * json
 * 1. String ���� �о�� ������ Ű�� ���� - DataBase ���� IP, ��й�ȣ
 * 2. �ܺ� DLL�� ����Ͽ��� Ŭ���� �����̰ų� ������ �����̳� ������ �����͸� ����ȭ - ������ȭ�� ����
 *    �����͸� ���� ������ �´�.
 */


public class MapData_Load : MonoBehaviour
{
    public MapData Load(string filename)
    {
        if (!filename.Contains(".json"))
        {
            filename += ".json";
        }
        filename = Path.Combine(Application.streamingAssetsPath, filename);
        string ReadData = File.ReadAllText(filename);// ������ ��Ʈ������ �о� ����
        MapData mapData = new MapData();
        //������ȭ

        mapData = JsonConvert.DeserializeObject<MapData>(ReadData); // ������ȭ��� �Ѵ�..
        return mapData;


    }
}
