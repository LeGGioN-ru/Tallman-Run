using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agava.YandexGames;

public class ADShower : MonoBehaviour
{
    public event Action _onVideoOpened;
    public event Action _onRewardedCallback;

    private void OnEnable()
    {
        _onVideoOpened += () =>
        {
            ChangeSoundVolume(0);
        };

        _onRewardedCallback += () =>
        {
            ChangeSoundVolume(1);
        };
    }

    private void OnDisable()
    {
        _onVideoOpened -= () =>
        {
            ChangeSoundVolume(0);
        };

        _onRewardedCallback -= () =>
        {
            ChangeSoundVolume(1);
        };
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();
    }

    public void ChangeSoundVolume(int value)
    {
        if(SoundMuter.Instance.IsSoundMuted == false)
            AudioListener.volume = value;

        Time.timeScale = value;
    }

    public void ShowRewardedAD()
    {
        VideoAd.Show(_onVideoOpened, _onRewardedCallback);
    }

    public void ShowAD()
    {
        InterstitialAd.Show();
    }
}