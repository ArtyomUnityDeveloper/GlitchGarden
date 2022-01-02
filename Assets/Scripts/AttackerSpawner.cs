using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] float firstWaveDelay = 45.0f;
    [SerializeField] float minSpawnDelay = 1.0f;
    [SerializeField] float maxSpawnDelay = 5.0f;
    [SerializeField] Attacker[] attackerPrefabArray; 

    bool spawn = true;


    IEnumerator Start()
    {
        yield return new WaitForSeconds(firstWaveDelay);
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        int attackerIndex = Random.Range(0, attackerPrefabArray.Length);
        Spawn(attackerPrefabArray[attackerIndex]);
    }

    private void Spawn(Attacker myAttacker)
    {
        Attacker newAttacker = Instantiate
            (myAttacker, transform.position, transform.rotation)
            as Attacker;
        newAttacker.transform.parent = transform; // объект атакер (ящерица) размещаем в сис-ме координат родительского объекта
                                                  // т.о. в иерархии объектов каждый Ящер (атакер) имеет кординаты отн-но Род.Объекта
                                                  // и в иерархии объектов также явл-ся Доч. объектом
    }
}
