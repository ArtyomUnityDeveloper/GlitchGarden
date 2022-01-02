using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;
    Text starText;



    void Start()
    {
        starText = GetComponent<Text>(); // когда скрипт на самом игр. объекте - не надо делать Find - можно просто GetComponent
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public bool HaveEnoughStars(int amount)
    {
        return stars >= amount; // возвр именно результ выражения в булевом типе данных
    }


    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    public void SpendStars(int amount)
    {
        if (stars >= amount)
        { 
        stars -= amount;
        UpdateDisplay();
        }
    }
}
