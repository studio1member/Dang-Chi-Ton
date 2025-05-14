using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public Player player;
    public Transform sword;
    public void _Get_Sword()
    {
        player.toolbar._Set_Tool_1(sword);
    }
}
