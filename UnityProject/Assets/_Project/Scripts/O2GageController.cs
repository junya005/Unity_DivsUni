using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class O2GageController : MonoBehaviour
{
    public Image foregroundImage;  // ゲージの前景Image
    public float maxValue;  // ゲージの最大値
    private float currentValue;    // ゲージの現在値
    public GameManager gameManager;

    void Start()
    {
        maxValue = gameManager.sansoJougen;
        UpdateGauge();
    }

    void Update()
    {
        currentValue = gameManager.sanso;
        currentValue = Mathf.Clamp(currentValue, 0, maxValue);
        UpdateGauge();
    }

    // ゲージを回復させるメソッド
    public void IncreaseGauge(float amount)
    {
        currentValue += amount;
        currentValue = Mathf.Clamp(currentValue, 0, maxValue);
        UpdateGauge();
    }

    // ゲージの表示を更新するメソッド
    private void UpdateGauge()
    {
        if (foregroundImage != null)
        {
            float fillAmount = currentValue / maxValue;
            foregroundImage.fillAmount = fillAmount;
        }
    }
}
