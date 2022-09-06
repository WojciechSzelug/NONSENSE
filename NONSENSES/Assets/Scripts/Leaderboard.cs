using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;

public class Leaderboard : MonoBehaviour
{

    public void ShowLeaderboardUI()
    {
        Social.ShowLeaderboardUI();
    }

    public void DoLeadreboardPost(int _score)
    {
        Social.ReportScore(_score, GPGSIds.leaderboard_highest_leaderboard,
            (bool success) =>
            {
                if (success)
                {
                    //co si� dzieje je�li sukces
                }
                else
                {
                    //co si� dzieje je�li nie sukces
                }

            });
    }

}
