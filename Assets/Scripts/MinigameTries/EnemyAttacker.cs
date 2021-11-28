using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacker : MonoBehaviour
{
    public float AttackDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag.ToLower() == "enemy")
        {
            collision.transform.GetComponent<HealthSystem>().Attack(AttackDamage);
        }
    }
}
