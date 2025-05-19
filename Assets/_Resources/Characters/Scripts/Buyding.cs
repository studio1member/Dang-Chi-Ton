using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buyding : MonoBehaviour
{
    public GameObject item;
    [SerializeField] private Player player;
    public void _On_Buyding()
    {
        Button itemSell = Instantiate(Button);
    }
}
