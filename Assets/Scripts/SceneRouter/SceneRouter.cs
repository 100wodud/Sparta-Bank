using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRouter : MonoBehaviour
{
    public static SceneRouter I;
    private void Awake()
    {
        I = this;
    }
    public void GotoATMMain()
    {
        GameManager.I.sceneNameChange("");
        SceneManager.LoadScene("BackgroundScene");
        SceneManager.LoadScene("ATMMainScene", LoadSceneMode.Additive);
    }
    public void GotoDeposit()
    {
        GameManager.I.sceneNameChange("Deposit");
        SceneManager.LoadScene("BackgroundScene");
        SceneManager.LoadScene("DepositScene", LoadSceneMode.Additive);
    }
    public void GotoGetCash()
    {
        GameManager.I.sceneNameChange("Get Cash");
        SceneManager.LoadScene("BackgroundScene");
        SceneManager.LoadScene("GetCashScene", LoadSceneMode.Additive);
    }
    public void GotoTreansfer()
    {
        GameManager.I.sceneNameChange("Transfer");
        SceneManager.LoadScene("BackgroundScene");
        SceneManager.LoadScene("TransferScene", LoadSceneMode.Additive);
    }

    public void GotoLogin()
    {
        GameManager.I.sceneNameChange("Sign In");
        SceneManager.LoadScene("BackgroundScene");
        SceneManager.LoadScene("LoginScene", LoadSceneMode.Additive);
    }
}
