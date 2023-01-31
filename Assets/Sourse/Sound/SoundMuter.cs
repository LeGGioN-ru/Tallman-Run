using UnityEngine;

public class SoundMuter : MonoBehaviour
{
    private bool _isSoundMuted = false;

    public bool IsSoundMuted => _isSoundMuted;

    public static SoundMuter Instance;

    private void Start()
    {
        Instance = this;
    }

    public void OnMuteButton()
    {
        if(_isSoundMuted == false)
        {
            AudioListener.volume = 0;
            _isSoundMuted = true;
        }
        else
        {
            AudioListener.volume = 1;
            _isSoundMuted = false;
        }
    }
}