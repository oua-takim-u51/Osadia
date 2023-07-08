using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    //basit collect mantýðý
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject);
        if (other != null && other.GetComponent<Collider>().CompareTag("Arcadium"))
        {
            FindObjectOfType<SkillManager>().GetSkillBase().AddSkillPoint(1);
            Debug.Log(FindObjectOfType<SkillManager>().GetSkillBase().GetSkillPoints());
            Destroy(other.gameObject);
        }
    }
}
