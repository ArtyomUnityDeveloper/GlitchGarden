using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if (otherObject.GetComponent<Gravestone>())
        {
            GetComponent<Animator>().SetTrigger("jumpTrigger");
        }

        else if (otherObject.GetComponent<Defender>()) // если у другого объекта есть компонента Defender - в скобках выведет TRUE 
        {
            GetComponent<Attacker>().Attack(otherObject); // можно без gameObject. ибо компонент Attacker итак принадлежит объекту вызывающему скрипт
        }
    }

}
