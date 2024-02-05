using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCash : MonoBehaviour
{
    public static GetCash I;
    void Awake()
    {
        I = this;
    }

    public GameObject Popup2;
    public Text Balance;
    public Text Warning;
    public Text Money;

    public int cashs;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.I.user != null)
        {
            Balance.text = GameManager.I.user.Balance.ToString("C");
        }
        else
        {
            Balance.text = "￦0";
        }
    }

    public void ChangeMyCash(int num)
    {
        if (CheckmyBalance(num))
        {
            cashs = num;
            ShowupCashPopup(cashs);
        }
        else
        {
            Warning.text = "* 계좌의 금액이 부족합니다";
        }
    }
    bool CheckmyBalance(int num)
    {
        if (GameManager.I.user.Balance - num >= 0) return true;
        else return false;
    }

    void ShowupCashPopup(int num)
    {
        cashs = num;
        Money.text = $"{cashs.ToString("C")}원을";
        Popup2.SetActive(true);
    }

    public void CashPopupCancel()
    {
        Popup2.SetActive(false);
    }

    public void CashPopupCheck()
    {
        GameManager.I.user.Balance += cashs;
        GameManager.I.user.Cash -= cashs;
        GameManager.I.AllUser[GameManager.I.userId] = GameManager.I.user;
        SceneRouter.I.GotoATMMain();
    }
    public void InputCalNumber()
    {
        string str = GetComponent<Calculator>().str;
        if (str.Length >= 1)
        {
            int num = Convert.ToInt32(str + "000");
            ChangeMyCash(num);
        }
        else
        {
            Warning.text = "* 금액을 입력해 주세요";
        }
    }
}
