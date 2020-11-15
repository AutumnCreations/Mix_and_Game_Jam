using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpdateBaseStats : MonoBehaviour
{

    [SerializeField] Base playerBase;
    [SerializeField] TextMeshProUGUI goldText;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] Image damageBlur;
    [SerializeField] float damagedDuration = 1.5f;

    float fadeTime = 0;
    public bool gameOver = false;

    Color blurNormal = new Color(0, 0, 0, 0);
    Color blurDamaged = new Color(0, 0, 0, .5f);
    Color blurGameOver = new Color(0, 0, 0, 1);

    Color healthNormal = Color.white;
    Color healthDamaged = new Color(1, 0, 0);

    private void Start()
    {
        fadeTime = damagedDuration;
    }

    public void TakeDamage()
    {
        if (!gameOver)
        {
            damageBlur.color = blurDamaged;
            healthText.color = healthDamaged;
            fadeTime = 0;
        }
    }

    void Update()
    {
        if (!gameOver && fadeTime < damagedDuration)
        {
            fadeTime += Time.deltaTime / damagedDuration;
            damageBlur.color = Color.Lerp(blurDamaged, blurNormal, fadeTime);
            healthText.color = Color.Lerp(healthDamaged, healthNormal, fadeTime);
        }
        else if (gameOver && fadeTime < damagedDuration)
        {
            fadeTime += Time.deltaTime / damagedDuration;
            damageBlur.color = Color.Lerp(blurDamaged, blurGameOver, fadeTime);
        }

        goldText.text = playerBase.gold.ToString();
        healthText.text = playerBase.health.ToString();
    }
}
