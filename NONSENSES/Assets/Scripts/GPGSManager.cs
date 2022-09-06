using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;

public class GPGSManager : MonoBehaviour
{

    public Text debugInfo;

    // Start is called before the first frame update
    private void Start()
    {
        InitializePlayGamesLogin();
        LoginGooglePlayGames();
    }
    void InitializePlayGamesLogin()
    {
        PlayGamesPlatform.Activate();
    }

    void LoginGooglePlayGames()
    {
        Social.localUser.Authenticate(OnGooglePlayGamesLogin);
    }

    void OnGooglePlayGamesLogin(bool success, string authCode)
    {
        if (success)
        {
            //Call Unity Authentication SDK to sign in or link with Google Play Games
            debugInfo.text = ("Login with Google Play games successful. Authorization code: " + authCode);
        }
        else
        {
            debugInfo.text = ("Login Unsuccessful");
        }
    }
}

