using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    BoxCollider boxCollider;
    Vector3 size;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        size = boxCollider.size;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(transform.position, size);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "FpsGuy")
             Debug.Log("Triggered!!");
    }
}