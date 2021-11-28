using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class HealthSystem : MonoBehaviour
{
    public float initialHealth = 1;

    public float health { get; set; }

    private HealthSystem healthSystem;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        health = initialHealth;

        healthSystem = GetComponent<HealthSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        float percentageHealth = healthSystem.health / healthSystem.initialHealth;
        spriteRenderer.color = new Color(1 - percentageHealth, percentageHealth, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float Attack(float attackDamage)
    {
        float percentageHealth = healthSystem.health / healthSystem.initialHealth;
        spriteRenderer.color = new Color(1 - percentageHealth, percentageHealth, 0);

        health -= attackDamage;
        return health;
    }
}
