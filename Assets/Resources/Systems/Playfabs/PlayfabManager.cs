using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class PlayfabManager : MonoBehaviour
{
    [SerializeField] private Text coin_Text;
    private void Awake()
    {
        coin_Text.text = "Coin: " + "  ";
    }
    public void _Get_Coin(int coin)
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "Coin", coin.ToString() }
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnCoinSaved, OnError);
    }
    private void OnCoinSaved(UpdateUserDataResult result)
    {
        Debug.Log("Coin saved successfully.");
    }

    private void OnError(PlayFabError error)
    {
        Debug.LogError("PlayFab Error: " + error.GenerateErrorReport());
    }
}
