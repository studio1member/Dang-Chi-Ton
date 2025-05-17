using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;
using PlayFab;
using UnityEngine.SceneManagement;

public class PlayfabLoginManager : MonoBehaviour
{
    private GameObject login_Panel;
    private InputField email_Input, password_Input;
    private Button login_Button, register_Button, resetPasswork_Button;
    private Text message_Text;
    private void Awake()
    {
        login_Panel = GameObject.Find("Login Panel");
        email_Input = GameObject.Find("Email InputField").GetComponent<InputField>();
        password_Input = GameObject.Find("Password InputField").GetComponent<InputField>();
        login_Button = GameObject.Find("Login Button").GetComponent<Button>();
        register_Button = GameObject.Find("Register Button").GetComponent<Button>();
        resetPasswork_Button = GameObject.Find("Reset Password Button").GetComponent<Button>();
        message_Text = GameObject.Find("Message Text").GetComponent<Text>();
        message_Text.text = "";

        email_Input.text = "thecong3939@gmail.com";
        password_Input.text = "anhemminh11";
    }
    public void _Play_Button()
    {
        SceneManager.LoadScene(1);
    }
    public void _Login_Button()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = email_Input.text,
            Password = password_Input.text,
        };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnError);
    }
    void OnLoginSuccess (LoginResult result)
    {
        login_Panel.SetActive(false);
    }
    public void _Register_Button()
    {
        if (password_Input.text.Length < 6)
        {
            message_Text.text = "Mật khẩu quá ngắn phải trên 6 ký tự !";
            return;
        }
        var request = new RegisterPlayFabUserRequest
        {
            Email = email_Input.text,
            Password = password_Input.text,
            RequireBothUsernameAndEmail = false
        };
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }
    void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        login_Panel.SetActive(false);
    }
    public void _ResetPassword_Button()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = email_Input.text,
            TitleId = "157331"
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, OnError);
    }
    void OnPasswordReset (SendAccountRecoveryEmailResult result)
    {

    }
    private void OnError(PlayFabError error)
    {

    }
}
