using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunStartColl : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FpsGuy")
        {
            RunManager.current.RunStart();
            Debug.Log("Run Baþladý");
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name =="FpsGuy")
        {
            Debug.Log("disabled " + this);
            Destroy(gameObject);
        }
    }
}
