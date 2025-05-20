using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Toolbar : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private RectTransform tool_1, tool_2, tool_3;
    private int toolNum = 0;

    public Transform activate_tool_1, activate_tool_2, activate_tool_3;
    private void Awake()
    {
        _Awake_Activate();
    }
    private void Update()
    {
        _input();
    }
    private void _Awake_Activate()
    {
        if (activate_tool_1 == null) tool_1.gameObject.SetActive(false);
        if (activate_tool_2 == null) tool_2.gameObject.SetActive(false);
        if (activate_tool_3 == null) tool_3.gameObject.SetActive(false);
    }
    private void _input()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) _Tool_1();
        if (Input.GetKeyDown(KeyCode.Alpha2)) _Tool_2();
        if (Input.GetKeyDown(KeyCode.Alpha3)) _Tool_3();
    }
    private void _Tool_Change(bool returnTool)
    {
        tool_1.sizeDelta = new Vector2(100, 100);
        tool_2.sizeDelta = new Vector2(100, 100);
        tool_3.sizeDelta = new Vector2(100, 100);
        if (returnTool) toolNum = 0;
    }
    private void _Tool_1()
    {
        if (activate_tool_1 == null) return;
        _Tool_Change(false);
        tool_1.sizeDelta = new Vector2(110, 110);
        if (toolNum == 1)
        {
            _Tool_Change(true);
            activate_tool_1.gameObject.SetActive(false);
        }
        else
        {
            toolNum = 1;
            activate_tool_1.gameObject.SetActive(true);
        }
    }
    private void _Tool_2()
    {
        if (activate_tool_2 == null) return;
        _Tool_Change(false);
        tool_2.sizeDelta = new Vector2(110, 110);
        if (toolNum == 2)
        {
            _Tool_Change(true);
            activate_tool_2.gameObject.SetActive(false);
        }
        else
        {
            toolNum = 2;
            activate_tool_2.gameObject.SetActive(true);
        }
    }
    private void _Tool_3()
    {
        if (activate_tool_3 == null) return;
        _Tool_Change(false);
        tool_3.sizeDelta = new Vector2(110, 110);
        if (toolNum == 3)
        {
            _Tool_Change(true);
            activate_tool_3.gameObject.SetActive(false);
        }
        else
        {
            toolNum = 3;
            activate_tool_3.gameObject.SetActive(true);
        }
    }
    public void _Set_Sword(Transform sword)
    {
        if (activate_tool_1 != null) Destroy(activate_tool_1.gameObject);
        if (sword != null)
        {
            Transform swordIns = Instantiate(sword);
            swordIns.SetParent(player.rightHand);
            swordIns.localPosition = new Vector3(0, 0, 0);
            swordIns.localRotation = Quaternion.identity;
            activate_tool_1 = swordIns;
            swordIns.gameObject.SetActive(false);
            tool_1.gameObject.SetActive(true);
        }
        else
        {
            tool_1.gameObject.SetActive(false);
            activate_tool_1 = null;
        }
    }
}
