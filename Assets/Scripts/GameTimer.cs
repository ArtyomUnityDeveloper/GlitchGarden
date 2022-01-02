using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in seconds")]
    [SerializeField] float levelTime = 10f;
    bool triggeredLevelFinished = false;



    void Update()
    {
        if (triggeredLevelFinished) { return;  }  // эта строка остановит выполнение скрипта, нижеследующие строки не будут выполнены, если в IF будет TRUE
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime; // timeSinceLevelLoad время с загрузки уровня
        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);

        if(timerFinished)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
