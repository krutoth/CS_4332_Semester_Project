using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]

public class PlayerHealth : MonoBehaviour
{
    // canvas txt
    public Text healthText;
    public Image damageFX;
    // default health
    public int health = 100;
    // max health
    public int maxHealth = 100;
    // max alpha
    private float maxAlpha = 0.7f;
    // is active
    private bool isActive;
    // health bar
    public HealthBar healthBar;
    // audio clip
    public AudioClip audioClip;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ApplyDamage(int damage)
    {
        health = health - damage;
        UpdateText();
        healthBar.UpdateHealthBar();
        if (!isActive && damageFX != null)
            StartCoroutine(SetEffect());
    }

    public void ApplyHeal(int heal)
    {
        // store current health - damage val
        health = health + heal;
        UpdateText();
        healthBar.UpdateHealthBar();
    }

    void UpdateText()
    {
        // 0 < health  < 100
        health = Mathf.Clamp(health, 0, 100);

        // if health panel exists
        if (healthText != null)
        {
            // set txt
            healthText.text = health.ToString();
        }
    }

    private IEnumerator SetEffect()
    {
        isActive = true;

        // panel alpha
        float alpha = damageFX.color.a;

        // panel color
        Color color = damageFX.color;

        // panel color alpha
        damageFX.color = new Color(color.r, color.g, color.b, maxAlpha);

        if (audioSource != null && audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }

        yield return new WaitForSeconds(0.2f);

        // transparent alpha
        damageFX.color = new Color(color.r, color.g, color.b, 0);

        // non-constant flash
        yield return new WaitForSeconds(0.4f);

        //for next run
        isActive = false;

        //Exit.
        yield return null;
    }
}
