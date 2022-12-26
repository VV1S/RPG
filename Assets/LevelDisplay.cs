using System;
using System.Collections;
using System.Collections.Generic;
using RPG.Stats;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    private BaseStats stats;
    void Awake()
    {
        stats = GameObject.FindWithTag("Player").GetComponent<BaseStats>();
    }

    void Update()
    {
        GetComponent<Text>().text = String.Format("{0:0}", stats.GetLevel());
    }
}
