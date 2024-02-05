using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transfer : MonoBehaviour
{

    public static Transfer I;
    void Awake()
    {
        I = this;
    }
    public InputField Id;
    public Text Error;

    public GameObject UserInfo;
    public Text TId;
    public Text TName;

    public GameObject Calculator;

    public GameObject Popup3;
    public Text Balance;
    public Text Warning;
    public Text Money;

    public User transferUser;
    public int transferuserID;

    public int transfers;

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

    public void FindUser()
    {

        string id = Id.text;
        bool res = true;
        int i = 0;
        foreach (var user in GameManager.I.AllUser)
        {
            if (user.Id == id)
            {
                transferUser = user;
                transferuserID = i;
                res = false;
            }
            if (!res) break;
            i++;
        }
        if (res)
        {
            Error.text = "* 아이디를 확인하세요";
        } else
        {
            TId.text = transferUser.Id;
            TName.text = transferUser.Name;
            UserInfo.SetActive(true);
            Calculator.SetActive(true);
        }
    }

    public void ChangeMyCash(int num)
    {
        if (CheckmyBalance(num))
        {
            transfers = num;
            ShowupTransferPopup(transfers);
        }
        else
        {
            Warning.text = "* 계좌의 금액이 부족합니다";
        }
    }
    void ShowupTransferPopup(int num)
    {
        transfers = num;
        Money.text = $"{transfers.ToString("C")}원을";
        Popup3.SetActive(true);
    }
    public void TransferPopupCancel()
    {
        Popup3.SetActive(false);
    }

    bool CheckmyBalance(int num)
    {
        if (GameManager.I.user.Balance - num >= 0) return true;
        else return false;
    }

    public void TransferPopupCheck()
    {
        GameManager.I.user.Balance -= transfers;
        transferUser.Balance += transfers;
        GameManager.I.AllUser[GameManager.I.userId] = GameManager.I.user;
        GameManager.I.AllUser[transferuserID] = transferUser;
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
