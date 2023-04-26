using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseAttacks : MonoBehaviour
{
    public float fireDelta = 2f;
    private float nextFire = 2f;
    private float myTime = 0.0F;
    public int ammoAmount = 10;
    public float meleeRepeatDelay = 0.25f;
    public GameObject projectile;
    public GameObject punchMesh;
    public Text ammoPanel;
    private bool punchActive;

    // Start is called before the first frame update
    void Start()
    {
        //Update text to display the player ammo.
        UpdateText();
        //Hide the hand when we start the game and have ammo.
        punchMesh.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        myTime = myTime + Time.deltaTime;

        if (Input.GetButton("Fire1") && myTime > nextFire) 
        {
            nextFire = myTime + fireDelta;

            if (ammoAmount > 0)
            {
                ammoAmount--;
                UpdateText();
                var clone = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
                //Destroy after 2 seconds to stop clutter.
                Destroy(clone, 5.0f);
            }
            else
            {
                if (!punchActive)
                {
                    punchActive = true;
                    StartCoroutine(MeleeAttack());
                }
            }

            nextFire = nextFire - myTime;
            myTime = 0.0F;
        }
    }

    void ApplyAmmo(int ammo)
    {
        ammoAmount += ammo;
        UpdateText();
    }

    void UpdateText()
    {
        //Check the ammo panel exists.
        if (ammoPanel != null)
        {
            //Sets the text on our panel.
            ammoPanel.text = ammoAmount.ToString();
        }
    }

    IEnumerator MeleeAttack()
    {
        punchMesh.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        punchMesh.SetActive(false);
        yield return new WaitForSeconds(meleeRepeatDelay);
        punchActive = false;
        yield return null;
    }
}
