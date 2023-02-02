using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private ADShower _ad;
    [SerializeField] private GameObject _videoButton;
    [SerializeField] private ParticleSystem _confetti;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerBehaviour playerBehaviour))
        {
            GameAnalyticsEvents.Instace.OnLevelFinishGA();
            playerBehaviour.StartFinish();

            _confetti.Play();
            _videoButton.SetActive(true);
            _ad.ShowAD();
        }
    }
}