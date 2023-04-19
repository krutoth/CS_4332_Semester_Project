using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBarImage;
    public PlayerHealth playerHealth;
    public void UpdateHealthBar()
    {
        healthBarImage.fillAmount = Mathf.Clamp((float)playerHealth.health / (float)playerHealth.maxHealth, 0, 1f);
        Debug.Log((float)playerHealth.health / (float)playerHealth.maxHealth);
        
    }
}