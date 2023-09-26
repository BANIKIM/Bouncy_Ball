using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;//추가
using System.IO;//필요

/*
 * json
 * 1. String 으로 읽어온 데이터 키로 접근 - DataBase 접속 IP, 비밀번호
 * 2. 외부 DLL을 사용하여서 클래스 형식이거나 데이터 컨테이너 형식의 데이터를 직렬화 - 역직렬화를 통해
 *    데이터를 쉽게 가지고 온다.
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
        string ReadData = File.ReadAllText(filename);// 파일을 스트링으로 읽어 오기
        MapData mapData = new MapData();
        //역직렬화

        mapData = JsonConvert.DeserializeObject<MapData>(ReadData); // 역질렬화라고 한다..
        return mapData;


    }
}
