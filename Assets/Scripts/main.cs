using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.I.sceneNameChange("Sign In");
        SceneManager.LoadScene("BackgroundScene");
        SceneManager.LoadScene("LoginScene", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
