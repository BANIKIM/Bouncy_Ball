using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class IntroScene : MonoBehaviour
{
    private void Awake()
    {
        //현재 게임이 윈도우 포커스가 되지 않아도 게임이 실행될 수 있도록하는
        Application.runInBackground = true;

        //게임을 새로 시작하였을 때 stage의 index를 0으로 초기화
        PlayerPrefs.SetInt("StageIndex", 0);
        DirectoryInfo directory = new DirectoryInfo(Application.streamingAssetsPath);

        //전처리기 : 무언가 수행 하기 전에 먼저 실행한다.
#if UNITY_EDITOR_WIN
        Stagecontroller.MaxStageCount = directory.GetFiles().Length / 2;
#elif UNITY_STANDALONE_WIN
        Stagecontroller.MaxStageCount = directory.GetFiles().Length;
#endif
    }

    private void Update()
    {
        if(Input.anyKeyDown)
        {
            SceneLoader.LoadScene("MainGame");
        }
    }
}
