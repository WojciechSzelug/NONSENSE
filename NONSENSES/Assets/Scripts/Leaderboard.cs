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
                    //co siê dzieje jeœli sukces
                }
                else
                {
                    //
                }

            });
    }
    public void DoLeadreboardPull()
    {
        Social.LoadScores(GPGSIds.leaderboard_highest_leaderboard,
            scores =>
            {
                if (scores.Length > 0)
                {
                    //scores.
                    string myScores = "Leaderboard:\n";
                    foreach (IScore score in scores)
                        myScores += "\t" + score.userID + " " + score.formattedValue + " " + score.date + "\n";
                    Debug.Log(myScores);
                }
                else
                {
                    Debug.Log("No scores loaded");
                }

            });
    }

}
