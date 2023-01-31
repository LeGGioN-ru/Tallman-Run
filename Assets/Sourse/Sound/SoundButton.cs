using UnityEngine;

public class SoundButton : MonoBehaviour
{
    public void OnSoundButton()
    {
        SoundMuter.Instance.OnMuteButton();
    }
}