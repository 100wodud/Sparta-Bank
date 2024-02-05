using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public Text Time;
    public Text Date;
    public Text UserName;
    public Text Position;

    // Start is called before the first frame update
    void Start()
    {
        Time.text = "12:00:00";
        Date.text = "1993-02-18";
        if (GameManager.I.user != null)
        {
            UserName.text = $"{GameManager.I.user.Name}님";
        } else
        {
            UserName.text = $"로그인이 필요합니다";
        }
        if(GameManager.I.scene != null || GameManager.I.scene != "")
        {
            Position.text = $"{GameManager.I.scene}";
        } else
        {
            Position.text = "";
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        string time = GetCurrentTime();
        string date = GetCurrentDate();
        if (time != null || date !=null)
        {
            Time.text = time;
            Date.text = date;
        }
        else
        {
            Time.text = "00:00:00";
            Date.text = "0000-00-00";
        }

    }

    // 시간 표현방식 변경
    public static string GetCurrentTime()
    {
        return DateTime.Now.ToString(("HH:mm:ss"));
    }

    // 날짜 표현방식 변경
    public static string GetCurrentDate()
    {
        return DateTime.Now.ToString(("yyyy-MM-dd"));
    }
}
