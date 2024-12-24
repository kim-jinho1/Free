using System.Threading.Tasks;
using TMPro;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Button btnScoreSave;
    [SerializeField] private TMP_InputField inputScore;

    private const string leaderboardId = "The_TowerRanking"; //dashboard ID

    private async void Awake()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += () =>
        {
            string playerId = AuthenticationService.Instance.PlayerId;
            Debug.Log("player id : " + playerId);
        };
        await this.SignInAsync();

        this.btnScoreSave.onClick.AddListener(() =>
        {
            this.SaveScoreAsync(int.Parse(this.inputScore.text));
            Debug.Log("score saved");
        });
    }

    private async Task SignInAsync()
    {
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public async void SaveScoreAsync(int score)
    {
        var result = await LeaderboardsService.Instance.AddPlayerScoreAsync(leaderboardId, score);

        Debug.Log(result.Score);
    }
}