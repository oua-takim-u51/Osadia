using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ArcadiumVal : MonoBehaviour
{
    TMP_Text _text;
    int count = 0;
    void Awake()
    {
        
        _text = GetComponent<TMP_Text>();
    }

    void Start()
    {
        updateArcadiumVal(0);
    }

    public void updateArcadiumVal(int count)
    {
        this.count = count;
        _text.text = count.ToString();
    }
    
}

