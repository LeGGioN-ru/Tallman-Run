using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private ADShower _ad;
    [SerializeField] private GameObject _videoButton;
    [SerializeField] private ParticleSystem _confetti;
    [SerializeField] private Button _continueButton;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerBehaviour playerBehaviour))
        {
            playerBehaviour.StartFinish();

            WinGame();
        }
    }

    public void WinGameWithoutBonus()
    {
        GameAnalyticsEvents.Instace.OnLevelFinishGA();

        _continueButton.gameObject.SetActive(true);
    }

    public void WinGame()
    {
        GameAnalyticsEvents.Instace.OnLevelFinishGA();

        _audioSource.Play();
        _confetti.Play();
        _continueButton.gameObject.SetActive(true);
        _videoButton.SetActive(true);
        _ad.ShowAD();
    }
}