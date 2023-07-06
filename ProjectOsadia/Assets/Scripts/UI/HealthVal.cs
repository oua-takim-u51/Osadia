using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HealthVal : MonoBehaviour
{
      private Slider _slider;
      
      
      void Awake()
      {
          _slider = GetComponentInParent<Slider>();
          
      }
  
      void Start()
      {
          _slider.value = 100; 
          UpdateHealthValue(_slider.value); 
      }
  
      void UpdateHealthValue(float health)
      {
          _slider.value = health; 
          
      }
      
}
