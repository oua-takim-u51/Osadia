using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Skillere olan olaylarý yöneten class bu : 
public class SkillManager : MonoBehaviour
{
    public SkillBase Skills;
    [HideInInspector]public HealthSystemComponent hSysComponent;
    private HealthSystem healthSystem;

    //Skillere olan olaylarý yöneten class bu

    private void Awake()
    {
        Skills = new SkillBase();
        Skills.OnSkillUnlocked += PlayerSkills_OnSkillUnlocked;

    }
    private void Start()
    {
        hSysComponent = GetComponent<HealthSystemComponent>();
        healthSystem = hSysComponent.GetHealthSystem();
    }

    //burdaki logic skillere göre düzenlenebilir.
    public SkillBase GetSkillBase() => this.Skills;
    private void PlayerSkills_OnSkillUnlocked(object sender, SkillBase.OnSkillUnlockedEventArgs e)
    {
        switch (e.skillType)
        {
            case SkillBase.SkillType.Speed_1:
                SetMovementSpeed(65f);
                break;
            case SkillBase.SkillType.Speed_2:
                SetMovementSpeed(80f);
                break;
            case SkillBase.SkillType.HealthMax_1:
                SetHealthAmountMax(12);
                break;
            case SkillBase.SkillType.HealthMax_2:
                SetHealthAmountMax(15);
                break;
        }
    }

    private void SetHealthAmountMax(int healthAmount)
    {
        //Caný ayarla
        Debug.Log(healthSystem);
        Debug.Log(hSysComponent.GetHealthSystem());
        Debug.Log(healthAmount);
        healthSystem.SetHealthMax(healthSystem.GetHealthMax() + healthAmount,true);
        Debug.Log(healthSystem.GetHealthMax());
    }

    private void SetMovementSpeed(float movementSpeed)
    {
        PlayerControllerFPS fps = FindFirstObjectByType<PlayerControllerFPS>();
    }
}
