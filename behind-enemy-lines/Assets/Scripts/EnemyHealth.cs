using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private float health;
    
    public float maxHealth = 100f;
    public float chipSpeed = 2f;
   

 

    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
        health = Mathf.Clamp(health, 0, maxHealth);
        if(health == 0)
        {
            Destroy(gameObject);
        }
        
    }
   
    public void TakeDamage(float damage)
    {
        health -= damage;
        

    }
    
}
