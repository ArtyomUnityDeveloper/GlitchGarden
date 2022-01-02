using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;


    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0) // обратился к myLineSpawner, перевёл "фокус" на имеющие ТрансформКомпоненту объекты
        { // и с помощью childCount посчитал их количество, сравнил с нулём - вернул соотв-й результат из указанных ниже
            return false;
        }
        else
        {
            return true;
        }
    }

    private void SetLaneSpawner() // метод "Установи зн-е перем. myLaneSpawner 
    { // массив типа AttackerSpawner заполняется всеми имеющимися в проекте объектами типа AttackerSpawner
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>(); 
        foreach (AttackerSpawner spawner in spawners) // прописали прямо в foreach перем. spawner (это единица массива spawners)
        { // для каждого spawner в spawners делай
            bool isCloseEnough =                        // созд. перем "достаточно ли близко"
                Mathf.Abs(spawner.transform.position.y - transform.position.y)  // разность координат спавнера из массива и стрелка на котором 
                <= Mathf.Epsilon;   // висит скрипт должна быть меньше или равна минимальному числу отличному от нуля (Эпсилону)
            if (isCloseEnough)  // если перем. "достаточно ли близко" равна TRUE, то забей в переменную myLaneSpawner данный конкретный
            {   // spawner из массива. Важно отметить: данный код увязывает в единое целое точки появления врагов и оборонительные
                myLaneSpawner = spawner; // постройки игрока так, чтобы в дальнейшем при помощи метода IsAttackerInLane() проверять
            } // наличие дочерних объектов для каждого конкретного myLaneSpawner'a и принимать решение об атаке появившихся на линии врагов
        }
    }


    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, gun.transform.rotation);
    }

}
