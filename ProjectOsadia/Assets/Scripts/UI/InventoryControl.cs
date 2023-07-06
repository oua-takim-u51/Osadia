using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    public GameObject Inventory;
    public bool InventoryClose;
    void Start()
    {
        InventoryClose = false;
    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryClose == true)
            {
                Inventory.SetActive(true);
                InventoryClose = false;
            }
            else
            {
                Inventory.SetActive(false);
                InventoryClose = true;
            }
        }
    }
}
