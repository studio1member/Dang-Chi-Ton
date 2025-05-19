using System.Collections;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

public class PlayfabManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Text coin_Text;
    [SerializeField] private int coin;
    private bool onSetCoin;
    private float timerSet;
    private void Awake()
    {
        _Get_Coin_Data();
        _Update_Coin();
    }
    public void _Add_Coin(int coin)
    {
        this.coin += coin;
        onSetCoin = true;
        timerSet = 5f;
        _Set_Coin();
    }
    private void Update()
    {
        _Set_Coin();
    }
    public void _Set_Coin()
    {
        if (timerSet > 0) timerSet -= Time.deltaTime;
        if (!onSetCoin || timerSet > 0f) return;
        _Save_Coin();
        onSetCoin = false;
    }
    public void _Save_Coin()
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                { "Coin", this.coin.ToString() }
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnCoinSaved, OnError);
        _Update_Coin();
    }
    public void _Get_Coin_Data()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
    }
    void OnDataRecieved (GetUserDataResult result)
    {
        if (result.Data != null && result.Data.ContainsKey("Coin"))
        {
            string coinValueStr = result.Data["Coin"].Value;
            int coinValue;
            if (int.TryParse(coinValueStr, out coinValue)) this.coin = coinValue;
        }
        else
        {
            _Save_Coin();
            _Update_Coin();
        }
    }
    public void _Update_Coin()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), _On_Update_Coin, OnError);
    }
    private void _On_Update_Coin(GetUserDataResult result)
    {
        if (result.Data.ContainsKey("Coin")) this.coin_Text.text = "Coin: " + result.Data["Coin"].Value + "   ";
    }
    private void OnApplicationQuit()
    {
        _Save_Coin();
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
