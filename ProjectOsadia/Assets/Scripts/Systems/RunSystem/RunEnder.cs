using System;
using UnityEngine;
public class RunEnder : MonoBehaviour
{
    public static bool isDead;
    [SerializeField]private GameObject player;
    public Vector3 deathPos;
    [SerializeField]HealthSystem playerHealthSystem;
    
    private void Start()
    {
        playerHealthSystem = player.GetComponent<HealthSystemComponent>().GetHealthSystem(); 
        playerHealthSystem.OnDead += Death;
    }

    private void Death(object sender, EventArgs e)
    {
        RunManager.current.RunEnd();
        isDead = true;
        RunManager.isOnRun = false;
        
        player.GetComponent<PlayerControllerFPS>().enabled = false; //ragdoll ekleyebiliriz aslýnda

        //log
        Debug.Log("Öldük " + isDead);
        Debug.Log("Run Bitti " + RunManager.isOnRun);
        //log

        deathPos = player.transform.position;
        playerHealthSystem.OnDead -= Death;
    }
}
