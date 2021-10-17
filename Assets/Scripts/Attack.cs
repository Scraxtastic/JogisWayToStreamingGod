using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthSystem))]
public class Attack : MonoBehaviour
{
    public static float attackDamage = 1;
    HealthSystem healthSystem;
    // Start is called before the first frame update
    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        if (healthSystem.Attack(attackDamage) <= 0)
        {
            DataStorage.jogicoins += healthSystem.initialHealth;
            Destroy(gameObject);
        }
    }
}
