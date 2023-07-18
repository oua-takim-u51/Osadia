using System;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    //Run manager de�i�kenleri
    public static RunManager current;
    public static bool isOnRun;
    public static event EventHandler OnRunStart;
    public static event EventHandler OnRunEnd;
    //

    //Run i�in di�er de�i�kenler
    private HealthSystem healthSystem;

    [SerializeField]private GameObject player;
    

    private void Awake()
    {
        current=this;
        Shootable.OnShootableDead += OnShootableEnemyDied;
        OnRunEnd += RunManager_OnRunEnd;
    }

    

    /*Run'da neler oluyor?
* Oyuncunun verdi�i kararlara sistem kar��l�k veriyor. (�r: abusu adam k�z�yor)
* Oyuncun yapt��� �eyler kaydediliyor: ge�irilen vakit,kill, ate�, harcama, can toplama, en �ok hasar al�nan d��man, puan vs.
* Oyuncunun hamlelerine g�re d��manlar spawnlan�yor!!
* Oyunun durumuna g�re run ba�l�yor ve bitiyor. Biti� i�in 3 durum: Oyuncu �lmesi, Son boss'un �lmesi, Tekneyle ka���...
* Oyuncunun �lmesi durumunda konumunu ba�lang�ca geri ta��yor.
* Gameanalytics ile etkile�ime ge�ebilir.
* vs.
*/

    public void RunStart()
    {
        if (OnRunStart != null)
        {
            OnRunStart(this, EventArgs.Empty);
        }
    }
    public void RunEnd()
    {
        if(OnRunEnd != null)
        {
            OnRunEnd(this, EventArgs.Empty);
        }
    }

    public void HandleRun()
    {
        
    }

    void LogRun()
    {
        int score = Points.GetPoints();
    }
    private void RunManager_OnRunEnd(object sender, EventArgs e)
    {
        LogRun();
    }

    private void OnShootableEnemyDied(object sender, EventArgs e)
    {
        Debug.Log(sender);
        Points.enemiesKilled++;
    }
}
