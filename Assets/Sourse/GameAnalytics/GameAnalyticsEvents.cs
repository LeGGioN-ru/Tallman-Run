using UnityEngine;
using UnityEngine.SceneManagement;
using GameAnalyticsSDK;

public class GameAnalyticsEvents : MonoBehaviour
{
    public static GameAnalyticsEvents Instace;

    private void Awake()
    {
        Instace = this;

        GameAnalytics.Initialize();

        DontDestroyOnLoad(this);
    }

    public void OnBuyedSkinGA(int coinsAmount, string item)
    {
        GameAnalytics.NewResourceEvent(GAResourceFlowType.Sink, "Coins", coinsAmount, item, "skin");
    }

    public void OnLevelStartGA()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, SceneManager.GetActiveScene().name);
    }

    public void OnLevelFinishGA()
    {
        GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, SceneManager.GetActiveScene().name);
    }
}