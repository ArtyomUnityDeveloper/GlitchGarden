using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 4f; // задержка в секундах (тип данных - float - с плавающей точкой)
    [SerializeField] float delayGameOver = 4f; // float - floating point data type
    int currentSceneIndex; // просто переменная для хранения индекса текущей сцены - storage variable

    private void Start() // всё что внутри метода Start выполняется при первом срабатывании объекта к которому приклеен скрипт
    { // everything inside the Start method is executed when the object is first triggered to which the script is attached
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // заполняем переменную currentSceneIndex при помощи метода "ДайАктивнуюСцену" и следующего метода "Дай БилдИндекс"
        // fill in the currentSceneIndex variable using the "GetActiveScene()" method and the following "buildIndex" method
        if (currentSceneIndex == 0) 
        {
            StartCoroutine(WaitAndLoad()); 
        }
    }


    private IEnumerator WaitAndLoad() 
    {
        yield return new WaitForSeconds(delayInSeconds);
        LoadNextScene();
    }

    /* IEnumerator WaitAndLoad() это корутина (сопрограмма). Она как метод, но не совсем
     * Методы выполняются последовательно друг за другом, а сопрограммы могут работать парралельно друг другу
     * Зачем тут корутина? Она позволяет вызвать задержку, в данном случае это задержка
     * между заставкой игры и главным меню
    */

    /* IEnumerator WaitAndLoad() is a coroutine(coroutine). It's like a method, but not quite
      * Methods are executed sequentially one after another, and coroutines can work in parallel to each other
      * Why is the coroutine here? It allows you to cause a delay, in this case it is a delay
      * between the game splash screen and the main menu
     */


    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    /* Методы RestartScene() и LoadMainMenu() прописаны только для привязки к кнопкам
     * Time.timeScale = 1 возвращает течение времени игры к стандартному состоянию
     * SceneManager.LoadScene(currentSceneIndex) - просто загружает ту сцену на которой мы сейчас
     * индекс текущей сцены задан выше в метод Start()
     * SceneManager.LoadScene("Start Screen") использует строковую ссылку - не самое "красивое" решение,
     * но работает: загружает следующую сцену по её названию. 
     * 
     * В языке C# точка используется точно также, как знак слэш в указании веб адресов, такие дела
     * То есть, SceneManager ТОЧКА LoadScene это обращение методу LoadScene который
     * находится в классе LoadScene
     */

    /* The RestartScene() and LoadMainMenu() methods are written only for binding to buttons
     *Time.timeScale = 1 returns the course of the game time to the standard state
     *SceneManager.LoadScene (currentSceneIndex) - just loads the scene we are currently on
     *the index of the current scene is specified above in the Start () method
     *SceneManager.LoadScene ("Start Screen") uses a string reference - not the most "pretty" solution,
     *but it works: loads the next scene by its name.
     *
     *In the C # language, the period is used in the same way as the slash sign in specifying web addresses, such things
     *That is, the SceneManager POINT LoadScene is a call to the LoadScene method that
     *is in the LoadScene class
     */


    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndGameOver());
    }

    private IEnumerator WaitAndGameOver()
    {
        yield return new WaitForSeconds(delayGameOver);
        SceneManager.LoadScene("GameOver");
    }

    public void LoadOptionsScreen()
    { 
        SceneManager.LoadScene("Options Screen");
    }

    // How to Play Screen

    public void LoadHowToPlayScreen()
    {
        SceneManager.LoadScene("How to Play Screen");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
