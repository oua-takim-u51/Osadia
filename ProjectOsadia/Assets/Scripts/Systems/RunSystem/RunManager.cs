using System;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    //Run manager deðiþkenleri
    public static RunManager current;
    public static bool isOnRun;
    public static event EventHandler OnRunStart;
    public static event EventHandler OnRunEnd;
    //

    //Run için diðer deðiþkenler
    private HealthSystem healthSystem;

    [SerializeField]private GameObject player;
    

    private void Awake()
    {
        current=this;
    }
    /*Run'da neler oluyor?
     * Oyuncunun verdiði kararlara sistem karþýlýk veriyor. (ör: abusu adam kýzýyor)
     * Oyuncun yaptýðý þeyler kaydediliyor: geçirilen vakit,kill, ateþ, harcama, can toplama, en çok hasar alýnan düþman, puan vs.
     * Oyuncunun hamlelerine göre düþmanlar spawnlanýyor!!
     * Oyunun durumuna göre run baþlýyor ve bitiyor. Bitiþ için 3 durum: Oyuncu ölmesi, Son boss'un ölmesi, Tekneyle kaçýþ...
     * Oyuncunun ölmesi durumunda konumunu baþlangýca geri taþýyor.
     * Gameanalytics ile etkileþime geçebilir.
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

    }


        
}
