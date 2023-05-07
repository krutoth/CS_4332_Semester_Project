using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{
    //canvas txt
    public Text healthPanel;

    // health
    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        //start health, set 0
        ApplyDamage(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ApplyDamage(int damage)
    {
        // if health panel attached & output health > 0
        if (healthPanel != null && health > 0)
        {
            //Store current health; sub dmg val
            health = health - damage;

            //Set panel txt
            healthPanel.text = health.ToString();
        }
    }
}
