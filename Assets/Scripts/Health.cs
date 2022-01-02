using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 160f;
    [SerializeField] GameObject deathVFX;


    public void DealDamage(float damage) // снаряд ударяет что-то, вызываем метод DealDamage
    {                                    // из снаряда в метод DealDamage передаём урон
        health -= damage;                // вычитаем из health переданное снарядом зн-е урона

        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(deathVFXObject, 1f);
    }
}
