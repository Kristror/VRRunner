using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Combat : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float cooldown = 1f;

    float cooldownTimer;

    public UnityEvent onAttack;

    void Update()
    {
        if (cooldownTimer > 0)
            cooldownTimer -= Time.deltaTime;
    }

    public void Attack(Health health)
    {
        if(cooldownTimer <= 0)
        {
            onAttack.Invoke();
            health.TakeDamage(damage);
            cooldownTimer = cooldown;
        }
    }
}
