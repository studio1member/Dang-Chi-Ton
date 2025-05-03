using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour
{
    public Player player;
    virtual public void Start()
    {
        player = Player.instance.GetComponent<Player>();
    }
    virtual public void Update()
    {
        if (Input.GetMouseButtonDown(0)) _Mouse_Left_Down();
        if (Input.GetMouseButtonDown(0)) _Mouse_Left();
        if (Input.GetMouseButtonDown(0)) _Mouse_Left_Up();

        if (Input.GetMouseButtonDown(1)) _Mouse_Right_Down();
        if (Input.GetMouseButtonDown(1)) _Mouse_Right();
        if (Input.GetMouseButtonDown(1)) _Mouse_Right_Up();
    }
    virtual public void _Mouse_Left_Down() { _Look(); }
    virtual public void _Mouse_Left() { _Look(); }
    virtual public void _Mouse_Left_Up() { _Look(); }

    virtual public void _Mouse_Right_Down() { _Look(); }
    virtual public void _Mouse_Right() { _Look(); }
    virtual public void _Mouse_Right_Up() { _Look(); }

    private void _Look() { player.transform.LookAt(player.look); }
}
