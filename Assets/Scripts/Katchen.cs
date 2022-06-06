using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class Katchen : MonoBehaviour{

    public VideoPlayer _videoPlayer;


    void Start()
    {
      
    
        _videoPlayer.Play();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("1st_scene");// сцена игры
        }
    }



    void OnEnable() //������� ����������� ���� ������� �� ������� ����� �����
    {
        _videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnDisable() //���������� ��� �������������� ������ ������
    {
        _videoPlayer.loopPointReached -= OnVideoEnd;
    }

    void OnVideoEnd(UnityEngine.Video.VideoPlayer causedVideoPlayer)
    {
        SceneManager.LoadScene("1st_scene");// сцена игры
    }


}
