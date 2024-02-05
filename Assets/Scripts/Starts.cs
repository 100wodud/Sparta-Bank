using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starts : MonoBehaviour
{
    private float fadeSpeed = 0.5f;
    public bool fadeInOnStart = true;

    private CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        if (fadeInOnStart)
        {
            canvasGroup.alpha = 0f;
            StartCoroutine(FadeIn());
            Invoke("GotoStart", 5f);
        }

    }

    // ���̵����� ������ startScene���� �̵�
    void GotoStart()
    {
        GameManager.I.sceneNameChange("Sign In");
        SceneManager.LoadScene("BackgroundScene");
        SceneManager.LoadScene("LoginScene", LoadSceneMode.Additive);
    }

    // ���̵� �� ���
    IEnumerator FadeIn()
    {
        while (canvasGroup.alpha < 1)
        {
            canvasGroup.alpha += Time.deltaTime * fadeSpeed;
            yield return null;
        }
    }
    // Start is called before the first frame update
}
