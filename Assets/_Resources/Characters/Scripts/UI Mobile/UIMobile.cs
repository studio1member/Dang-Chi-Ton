using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMobile : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
       this.player = GetComponentInParent<Player>();
        if (this.player != null) Debug.Log("UI Mobile Get Script");
    }



    private void _Check_Device()
    {
        RuntimePlatform platform = Application.platform;

        switch (platform)
        {
            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer:
                Debug.Log("Thiết bị là điện thoại (Android hoặc iOS)");
                _Mobile();
                break;

            case RuntimePlatform.WindowsPlayer:
            case RuntimePlatform.OSXPlayer:
            case RuntimePlatform.LinuxPlayer:
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.OSXEditor:
                Debug.Log("Thiết bị là máy tính (PC/Mac)");
                _PC();
                break;

            default:
                Debug.Log("Nền tảng khác: " + platform);
                _Mobile();
                break;
        }
    }
    private void _Mobile()
    {
        gameObject.SetActive(true);
    }
    private void _PC()
    {
        gameObject.SetActive(false);
    }
}
