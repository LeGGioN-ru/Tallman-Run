using UnityEngine;

public class DanceAnimationPlayer : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _animator.SetBool(PlayerAnimationsController.Params.Dance, true);
    }
}