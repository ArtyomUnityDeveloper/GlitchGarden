using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravestone : MonoBehaviour
{
    // пока нечто находится в коллайдере Надгробия - скрипт для него - делай то что в фигурных скобках
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        Attacker attacker = otherCollider.GetComponent<Attacker>();

        if(attacker)
        {
            // делай какую-то анимацию
        }

    }


}
