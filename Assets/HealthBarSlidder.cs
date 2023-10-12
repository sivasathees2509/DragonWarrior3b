using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HealthBarSlidder : MonoBehaviour
{
    public UnityEngine.UI.Slider healthSlider;
    public TMP_Text healthBarText;
    public GameObject failedPopUp;

    Damageable playerDamageable;

    private void Awake()
    {
        failedPopUp.gameObject.SetActive(false);
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.Log("No Player found in the scene. Make sure it has tag 'Player'");
        }
        playerDamageable = player.GetComponent<Damageable>();
    }
    void Start()
    {
        healthSlider.value = CalculateSliderPercentage(playerDamageable.Health, playerDamageable.MaxHealth);
        healthBarText.text = "HP " + playerDamageable.Health + " / " + playerDamageable.MaxHealth;
    }
    

    private void OnEnable()
    {
        playerDamageable.healthChanged.AddListener(OnPlayerHealthChanged);
    }

    private void OnDisable()
    {
        playerDamageable.healthChanged.RemoveListener(OnPlayerHealthChanged);
    }

    private float CalculateSliderPercentage(float currentHealth, float maxHealth)
    {
        return currentHealth / maxHealth;
    }

    private void OnPlayerHealthChanged(int newHealth, int maxHealth)
    {
        healthSlider.value = CalculateSliderPercentage(newHealth, maxHealth);
        healthBarText.text = "HP " + newHealth + " / " + maxHealth;
        if (newHealth <= 0)
        {
            failedPopUp.gameObject.SetActive(true);
            FindObjectOfType<StarHandlerPopFailed>().starsAchieved();
        }
    }
}
