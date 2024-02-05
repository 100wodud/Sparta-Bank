using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deposit : MonoBehaviour
{
    public static Deposit I;
    void Awake()
    {
        I = this;
    }

    public GameObject Popup1;
    public Text Balance;
    public Text Warning;
    public Text Money;

    public int deposits;

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

    public void ChangeMyBalance(int num)
    {
        if (CheckmyCash(num))
        {
            deposits = num;
            ShowupDepositPopup(deposits);
        }
        else
        {
            Warning.text = "* 현금이 부족합니다";
        }
    }

    bool CheckmyCash(int num)
    {
        if (GameManager.I.user.Cash - num >= 0) return true;
        else return false;
    }

    void ShowupDepositPopup(int num)
    {
        deposits = num;
        Money.text = $"{deposits.ToString("C")}원을";
        Popup1.SetActive(true);
    }

    public void DepositPopupCancel()
    {
        Popup1.SetActive(false);
    }

    public void DepositPopupCheck()
    {
        GameManager.I.user.Balance += deposits;
        GameManager.I.user.Cash -= deposits;
        GameManager.I.AllUser[GameManager.I.userId] = GameManager.I.user;
        SceneRouter.I.GotoATMMain();
    }

    public void InputCalNumber()
    {
        string str = GetComponent<Calculator>().str;
        if (str.Length >= 1)
        {
            int num = Convert.ToInt32(str + "000");
            ChangeMyBalance(num);
        }
        else
        {
            Warning.text = "* 금액을 입력해 주세요";
        }
    }
}
