using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;

public class PlayFabManager : MonoBehaviour
{

    [SerializeField] private GameObject nameUI;
    [SerializeField] private GameObject rowPrefab;
    [SerializeField] private Transform rowsParent;
    [SerializeField] private TextMeshProUGUI nameInput;
    [SerializeField] private GameObject scoreboardUI;
    [SerializeField] private GameObject victoryMenuUI;
    [SerializeField] private GameObject pauseMenuUI;
    private bool isVictory;
    private string loggInPlayFabID;

    // Start is called before the first frame update
    void Start()
    {
        Login();
    }

    void Login() 
    {
        var request = new LoginWithCustomIDRequest 
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams 
            {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnError);
    }

    void OnLoginSuccess(LoginResult result) 
    {
        Debug.Log("Successfull login/account create!");
        loggInPlayFabID = result.PlayFabId;
        string name = null;

        if(result.InfoResultPayload.PlayerProfile != null)
            name = result.InfoResultPayload.PlayerProfile.DisplayName;

        if(name == null) 
        {
            nameUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void OnError(PlayFabError error)
    {
        // Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderboard(int score) 
    {
        var request = new UpdatePlayerStatisticsRequest 
        {
            Statistics = new List<StatisticUpdate> 
            {
                new StatisticUpdate
                {
                    StatisticName = "Scoreboard",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Successfull leaderboard sent");
    }

    public void GetLeaderboard(bool isVictory) 
    {
        this.isVictory = isVictory;
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Scoreboard",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        scoreboardUI.SetActive(true);
        victoryMenuUI.SetActive(false);

        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {
            GameObject row = Instantiate(rowPrefab, rowsParent);
            TextMeshProUGUI[] texts = row.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();

            if (item.PlayFabId == loggInPlayFabID)
            {
                texts[0].color = Color.cyan;
                texts[1].color = Color.cyan;
                texts[2].color = Color.cyan;
            }

            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }

    public void GetLeaderboardAroundPlayer() 
    {
        var request = new GetLeaderboardAroundPlayerRequest
        {
            StatisticName = "Scoreboard",
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboardAroundPlayer(request, OnLeaderboardAroundPlayerGet, OnError);
    }

    void OnLeaderboardAroundPlayerGet(GetLeaderboardAroundPlayerResult result)
    {
        scoreboardUI.SetActive(true);
        victoryMenuUI.SetActive(false);

        foreach (Transform item in rowsParent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {
            GameObject row = Instantiate(rowPrefab, rowsParent);
            TextMeshProUGUI[] texts = row.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();

            if (item.PlayFabId == loggInPlayFabID)
            {
                texts[0].color = Color.cyan;
                texts[1].color = Color.cyan;
                texts[2].color = Color.cyan;
            }

            Debug.Log(item.Position + " " + item.PlayFabId + " " + item.StatValue);
        }
    }

    public void SubmitName()
    {
        var request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = nameInput.text
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameUpdate, OnError);
    }

    void OnDisplayNameUpdate(UpdateUserTitleDisplayNameResult result)
    {
        Debug.Log("Updated display name!");
        nameUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoBack() 
    {
        scoreboardUI.SetActive(false);

        if(isVictory)
            victoryMenuUI.SetActive(true);
        else
            pauseMenuUI.SetActive(true);
    }
}
