using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculator : MonoBehaviour
{
    public static Calculator I;
    public string str = "";
    public Text Total;

    void Awake()
    {
        I = this;
    }

    public void InputNumber(string number)
    {
        if (number == "reset")
        {
            str = "";
        }
        else if (number == "del")
        {
            if (str.Length >= 1)
            {
                str = str.Substring(0, str.Length - 1);
            }
        }
        else if (number == "0")
        {
            if (str.Length > 0)
            {
                str += number;
            }
        }
        else
        {
            str += number;
        }


        if (str.Length == 0)
        {
            Total.text = "0";
        }
        else if (str.Length > 6)
        {
            str = str.Substring(0, str.Length - 1);
            Total.text = str + "000";
        }
        else if (str.Length >= 1)
        {
            Total.text = str + "000";
        }
    }
}
