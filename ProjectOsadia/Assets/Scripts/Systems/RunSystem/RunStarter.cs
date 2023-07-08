using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunStarter : MonoBehaviour
{
    [SerializeField] Transform startPoint;
    [SerializeField] Transform playerTransform;
    private Vector3 startPosition;
    private void Awake()
    {
        RunManager.OnRunStart += StartRun;
    }

    private void Start()
    {
       //startPosition = startPoint.position;
    }

    public void StartRun(object sender, EventArgs e)
    {
        Debug.Log(playerTransform);
        Debug.Log(startPoint);
        Debug.Log(playerTransform.position);
        Debug.Log(startPoint.position);
        if (!RunManager.isOnRun)
            RunManager.isOnRun = true;

        if (playerTransform != null && startPoint != null)
        {
            playerTransform.position = startPoint.position;
            Debug.Log("Run Baþladý" + RunManager.isOnRun);
            Debug.Log("2 "+playerTransform.position);
            Debug.Log("2 "+startPoint.position);
        }
        RunManager.OnRunStart -= StartRun;
    }
}
