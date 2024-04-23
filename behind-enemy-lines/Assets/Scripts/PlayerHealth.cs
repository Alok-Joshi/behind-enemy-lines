using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private float health;
    
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
    public TMP_Text HealthText;

 

    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
             SceneManager.LoadSceneAsync(3);

        }
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();
        
    }
    public void UpdateHealthUI()
    {

        //Debug.Log(health);
        HealthText.text = "Health: " + health;
        

    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        

    }
    public void RestoreHealth(float healAmount)
    {
        health += healAmount;
        

    }
}
