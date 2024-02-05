using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{

    public InputField Password;
    public InputField Id;
    public Text Error;
    public GameObject Signup;


    public void GotoSignUp()
    {
        Signup.SetActive(true);
    }

    public void UserSignin()
    {
        string id = Id.text;
        string password = Password.text;
        bool res = true;
        int i = 0;
        foreach (var user in GameManager.I.AllUser)
        {
            if(user.Id == id)
            {
                res = false;
                if (user.Password == password)
                {
                    GameManager.I.user = user;
                    GameManager.I.userId = i;
                    SceneRouter.I.GotoATMMain();
                } else
                {
                    Error.text = "* 비밀번호를 확인하세요";
                }

            }
            if(!res) break;
            i++;
        }
        if(res)
        {
            Error.text = "* 아이디를 확인하세요";
        }
    }
}
