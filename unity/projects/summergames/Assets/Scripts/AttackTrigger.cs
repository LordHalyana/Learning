using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour {

    public int baseDamage = 1;
    public int modifiedDamage = 0;

    private int totalDamage;

    private void Update()
    {
        totalDamage = baseDamage + modifiedDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger != true && collision.CompareTag("Enemy"))
        {
            collision.SendMessageUpwards("Damage", totalDamage);
        }
    }
}
