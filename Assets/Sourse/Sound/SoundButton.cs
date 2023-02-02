using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SoundButton : MonoBehaviour
{
    [SerializeField] private Sprite _volumeOn;
    [SerializeField] private Sprite _volumeOff;

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public void OnSoundButton()
    {
        SoundMuter.Instance.OnMuteButton();

        if (AudioListener.volume == 0)
            _image.sprite = _volumeOff;
       else
            _image.sprite = _volumeOn;

    }
}