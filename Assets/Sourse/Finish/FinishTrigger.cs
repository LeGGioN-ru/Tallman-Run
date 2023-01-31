using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    [SerializeField] private ADShower _ad;
    [SerializeField] private GameObject _videoButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerBehaviour playerBehaviour))
        {
            playerBehaviour.StartFinish();

            _videoButton.SetActive(true);
            _ad.ShowAD();
        }
    }
}