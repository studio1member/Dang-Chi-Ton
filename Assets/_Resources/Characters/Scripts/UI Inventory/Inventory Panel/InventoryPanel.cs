using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    private Transform Inventory;
    private void Start()
    {
        if (this.Inventory == null) foreach (Transform t in transform) { this.Inventory = t; break; }
    }

}
