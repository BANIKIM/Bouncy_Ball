using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class IntroScene : MonoBehaviour
{
    private void Awake()
    {
        //���� ������ ������ ��Ŀ���� ���� �ʾƵ� ������ ����� �� �ֵ����ϴ�
        Application.runInBackground = true;

        //������ ���� �����Ͽ��� �� stage�� index�� 0���� �ʱ�ȭ
        PlayerPrefs.SetInt("StageIndex", 0);
        DirectoryInfo directory = new DirectoryInfo(Application.streamingAssetsPath);

        //��ó���� : ���� ���� �ϱ� ���� ���� �����Ѵ�.
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
