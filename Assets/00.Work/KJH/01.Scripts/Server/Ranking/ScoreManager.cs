using System.Threading.Tasks;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using Unity.Services.Leaderboards.Models;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Button _btnScoreSave;
    [SerializeField] private TMP_InputField _inputScore;
    [SerializeField] private Transform _content;

    private const string _leaderboardId = "The_TowerRanking"; //dashboard ID

    private async void Awake()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            string playerId = AuthenticationService.Instance.PlayerId;
            Debug.Log("player id : " + playerId);
        };
        await this.SignInAsync();

        this._btnScoreSave.onClick.AddListener(() =>
        {
            this.SaveScoreAsync(int.Parse(this._inputScore.text));
            Debug.Log("score saved");
        });
    }

    private async Task<LeaderboardScoresPage> FetchLeaderboardScores(string leaderboardId)
    {
        // Leaderboards에서 점수 가져오기
        return await LeaderboardsService.Instance.GetScoresAsync(leaderboardId);
    }
    private async Task SignInAsync()
    {
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public async void SaveScoreAsync(int score)
    {
        var result = await LeaderboardsService.Instance.AddPlayerScoreAsync(_leaderboardId, score);
        Debug.Log(result.Score);
    }
}