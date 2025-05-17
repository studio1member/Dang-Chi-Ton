using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField] private PlayfabManager playfabManager;
    [SerializeField] int coin;
    public void _Add_Coin()
    {
        playfabManager._Get_Coin(coin);
    }
}
