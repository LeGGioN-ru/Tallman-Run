using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private ADShower _ad;
    [SerializeField] private GameObject _videoButton;
    [SerializeField] private ParticleSystem _confetti;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerBehaviour playerBehaviour))
        {
            GameAnalyticsEvents.Instace.OnLevelFinishGA();
            playerBehaviour.StartFinish();

            _audioSource.Play();
            _confetti.Play();
            _videoButton.SetActive(true);
            _ad.ShowAD();
        }
    }
}