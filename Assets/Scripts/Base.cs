using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] float baseHealth = 10; // тут - сколько всего
    [SerializeField] int damagePerAttacker = 1;

    float lives; // типа текущие жизни базы сколько есть

    private void Start()
    {
        lives = baseHealth - PlayerPrefsController.GetDifficulty();
        Debug.Log("difficulty setting currently is " + PlayerPrefsController.GetDifficulty());
    }



    // private void OnTriggerEnter2D отнимает жизьку при сработке
    // добавим в аргумент метода переменную типа Collider2D
    // название переменой otherCollider
    // добавим строку Destroy(otherCollider.gameObject);
    // то есть: "разрушай игровой объект коллайдер которого
    // вызвал сработку тригера"
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        lives -= damagePerAttacker;
        if (lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLooseCondition();
        }

        Destroy(otherCollider.gameObject);
    }

    public float GetCurrentBaseHealth()
    {
        return lives;
    }

    public void SetBaseHealth(int health)
    {
        lives = health;
    }
}
