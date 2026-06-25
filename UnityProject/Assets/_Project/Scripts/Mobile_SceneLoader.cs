using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mobile_SceneLoader : MonoBehaviour
{
    [SerializeField] private Image fadePanel;
    private float fadeDuration = 1.0f;

    public void GameStart()
    {
        StartCoroutine(CallScene("mobile_main"));
    }

    public void GameStartinTitle()
    {
        Debug.Log(GameSettings.setting_tutorial);
        if (GameSettings.setting_tutorial)
        {
            StartCoroutine(CallScene("mobile_tutorial"));
        }
        else
        {
            StartCoroutine(CallScene("mobile_main"));
        }
    }

    public void GameEnd()
    {
        StartCoroutine(CallScene("mobile_title"));
    }

    public void ProgramEnd()
    {
        Application.Quit();
    }

    private IEnumerator CallScene(string SceneName)
    {
        fadePanel.enabled = true;
        float _timeCount = 0.0f;
        Color _startColor = fadePanel.color;
        Color _endColor = new Color(_startColor.r, _startColor.g, _startColor.b, 1.0f);

        while (_timeCount < fadeDuration)
        {
            _timeCount += Time.deltaTime;
            float t = Mathf.Clamp01(_timeCount / fadeDuration);
            fadePanel.color = Color.Lerp(_startColor, _endColor, t);
            yield return null;
        }

        fadePanel.color = _endColor;
        SceneManager.LoadScene(SceneName);
    }
}
