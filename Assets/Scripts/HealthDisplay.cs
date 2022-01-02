using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Text healthText;
    Base baseScriptReference;


    // МЕТОД ОТНОСИТСЯ К ЗДОРОВЬЮ БАЗЫ! НЕ К ЗДОРОВЬЮ ПОСТРОЕК, и НЕ К ЗДОРОВЬЮ АТАКУЮЩИХ ЮНИТОВ!
    void Start()
    {
        healthText = GetComponent<Text>();
        baseScriptReference = FindObjectOfType<Base>();
    }


    void Update()
    {
        healthText.text = baseScriptReference.GetCurrentBaseHealth().ToString();
    }
}
