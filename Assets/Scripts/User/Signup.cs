using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Signup : MonoBehaviour
{
    public InputField Password;
    public InputField Id;
    public InputField Name;
    public InputField Cash;
    public Text Error;
    public GameObject Sign;

    // Start is called before the first frame update
    void Update()
    {
        Cash.characterLimit = 14;
        Cash.onValueChanged.AddListener((word) => Cash.text = Regex.Replace(word, @"[^0-9]", ""));
        Debug.Log(Cash.text);
    }
    public void UserSignup()
    {
        string id = Id.text;
        string password = Password.text;
        string name = Name.text;
        int cash = Convert.ToInt32(Cash.text);
        bool res = true;
        if(id.Length == 0 || password.Length == 0 || name.Length == 0 || cash <= 0)
        {
            res = false;
            Error.text = "* 모든 칸을 채워주세요";
        } else { 
            foreach (var user in GameManager.I.AllUser)
            {
                if(id.Length >= 4)
                {
                    if (user.Id == id)
                    {
                        res = false;
                        Error.text = "* 존재하는 아이디 입니다";
                        break;
                    }
                } else
                {
                    res = false;
                    Error.text = "* 아이디는 4글자 이상입니다";
                }
            }
        }

        if (res)
        {
            User newUser = new User(id, password, name, 0, cash);
            GameManager.I.AllUser.Add(newUser);
            Sign.SetActive(false);
        }
    }

    public void ReturnLogin()
    {
        Sign.SetActive(false);
    }
}
