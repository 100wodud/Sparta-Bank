using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    public List<User> AllUser = new List<User>();
    public User user;
    public int userId;

    public string scene = "";

    void Awake()
    {
        if (I != null) //�̹� �����ϸ�
        {
            Destroy(gameObject); //�ΰ� �̻��̴� ����
            return;
        }
        I = this; //�ڽ��� �ν��Ͻ���
        DontDestroyOnLoad(gameObject); //�� �̵��ص� ��������ʰ�
    }

    public void UserSignout()
    {
        AllUser[userId] = user;
        user = null;
        SceneRouter.I.GotoLogin();
    }

    public void sceneNameChange(string sceneName)
    {
        scene = sceneName;
    }
}
