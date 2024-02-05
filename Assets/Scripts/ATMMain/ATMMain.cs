using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ATMMain : MonoBehaviour
{
    // Start is called before the first frame update
    public Text UserId;
    public Text Balance;
    public Text Cash;

    void Start()
    {
        if (GameManager.I.user != null)
        {
            UserId.text = GameManager.I.user.Id;
            Balance.text =GameManager.I.user.Balance.ToString("C");
            Cash.text = GameManager.I.user.Cash.ToString("C");
        }
        else
        {
            UserId.text = "NONE";
            Balance.text = "£Ü0";
            Cash.text = "£Ü0";
        }
    }

    public void Signout()
    {
        GameManager.I.UserSignout();
    }
}
