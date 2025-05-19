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
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, error => OnError(error, "login"));
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
        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, error => OnError(error, "register"));
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
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnPasswordReset, error => OnError(error, "reset"));
    }
    void OnPasswordReset (SendAccountRecoveryEmailResult result)
    {
        message_Text.text = "Đã gửi thông báo quên mật khẩu đến Email của bạn, vui lòng kiểm tra !";
    }
    private void OnError(PlayFabError error, string context)
    {
        switch (context)
        {
            case "register":
                message_Text.text = "Gmail này đã được sử dụng: " + error.ErrorMessage;
                break;
            case "login":
                message_Text.text = "Sai mật khẩu hoặc tài khoản: " + error.ErrorMessage;
                break;
            case "reset":
                message_Text.text = "Không tìm thấy tài khoản đã đăng kí bằng Gmail này: " + error.ErrorMessage;
                break;
            default:
                message_Text.text = "Lỗi không xác định: " + error.ErrorMessage;
                break;
        }
    }
}
