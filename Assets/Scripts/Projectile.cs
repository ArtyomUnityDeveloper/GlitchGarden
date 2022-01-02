using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float speed = 0.3f;
    [SerializeField] float damage = 60f;

    GameObject projectileParent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    //[SerializeField] float zAngleRotation = 1f;

    private void Start()
    {
        CreateProjectileParent();
        gameObject.transform.parent = projectileParent.transform;
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);

        if(!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        //transform.Rotate(0, 0, zAngleRotation * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        var health = otherCollider.GetComponent<Health>();
        var attacker = otherCollider.GetComponent<Attacker>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }


}
//вращение через transform.Rotate не работает так, как ожидалось, потому что движение объекта 
//сделано через вектор привязанный к осям самого объекта, а не к прямому изменению 
// transform.position как в скролл шутере
