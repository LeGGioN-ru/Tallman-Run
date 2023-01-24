using UnityEngine;

public class MoveAnimationsController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _animator.SetBool(PlayerAnimationsController.Params.Run, true);
        }

        if(Input.GetMouseButtonUp(0))
        {
            _animator.SetBool(PlayerAnimationsController.Params.Run, false);
        }
    }
}
