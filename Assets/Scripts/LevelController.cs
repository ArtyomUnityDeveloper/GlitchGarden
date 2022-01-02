using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel; // тут подключаем Canvas с надписью Level Complete который
    [SerializeField] AudioClip winSFX; // подрубай звук победы

    [SerializeField] GameObject looseLabel; // similarly
    [SerializeField] AudioClip looseSFX; 

    [SerializeField] [Range(0, 1)] float winSFXvolume = 0.7f;
    [SerializeField] [Range(0, 1)] float looseSFXvolume = 0.7f;
    [SerializeField] float winDelayInSeconds = 2.5f; // задержка экрана победы
    int numberOfAttackers = 0; // сколько врагов храним тут
    bool levelTimerFinished = false; // таймер на нуле или нет
    

    private void Start()
    {
        winLabel.SetActive(false);
        looseLabel.SetActive(false);
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++; // +1 num
    }

    public void AttackerKilled()
    {
        numberOfAttackers--; // -1 num

        if ((numberOfAttackers <= 0) && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] spawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnerArray)
        {
            spawner.StopSpawning();
        }
    }

    private IEnumerator HandleWinCondition()
    {
        AudioSource.PlayClipAtPoint(winSFX, Camera.main.transform.position, winSFXvolume);
        //Debug.Log("WinSFX played!!!!");
        winLabel.SetActive(true);
        yield return new WaitForSeconds(winDelayInSeconds);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLooseCondition()
    {
        AudioSource.PlayClipAtPoint(looseSFX, Camera.main.transform.position, looseSFXvolume);
        looseLabel.SetActive(true);
        Time.timeScale = 0;
    }

    /* Метод HandleLooseCondition() делает вот что:
     * 1. Включает звуковой трэк прикрепленный в переменную looseSFX точь в точь там, где расположена Camera
     * (да, камера как в кино, то куда она смотрит - туда может смотреть игрок)
     * с громкостью указанной в переменной looseSFXvolume
     * 2. Делает активным баннер "Ты проебал братан!" (на баннере также есть кнопки "заново" и "в гл. меню")
     * 3. Ставит игру на паузу! Да, если поставить значение временной шкалы равное нулю - тогда игра замрёт
     * Аналогично можно поставить 0.5 - игра будет в два раза медленнее, такие дела
     */ 

    /* The HandleLooseCondition() method does this:
     * 1. Includes the audio track attached to the looseSFX variable exactly where the Camera is located
     * (yes, the camera is like in a movie, then where it looks - the player can look there)
     * with the volume specified in the looseSFXvolume variable
     * 2. Makes the banner "You fucked up bro!" (the banner also has buttons "again" and "in the main menu")
     * 3. Pauses the game! Yes, if you set the timeline value to zero, then the game will freeze
     * Similarly, you can set 0.5 - the game will be twice as slow, such things
     */

}
