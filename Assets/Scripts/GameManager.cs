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
        if (I != null) //이미 존재하면
        {
            Destroy(gameObject); //두개 이상이니 삭제
            return;
        }
        I = this; //자신을 인스턴스로
        DontDestroyOnLoad(gameObject); //씬 이동해도 사라지지않게
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
