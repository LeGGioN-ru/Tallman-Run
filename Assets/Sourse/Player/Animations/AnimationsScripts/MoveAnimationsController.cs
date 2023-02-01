using UnityEngine;

public class MoveAnimationsController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private bool isFinish = false;

    private void Update()
    {
        if(isFinish == false)
        {
            if(Input.GetMouseButtonDown(0))
                _animator.SetBool(PlayerAnimationsController.Params.Run, true);

            if(Input.GetMouseButtonUp(0))
                _animator.SetBool(PlayerAnimationsController.Params.Run, false);

            if(Input.GetKeyDown(KeyCode.W))
                _animator.SetBool(PlayerAnimationsController.Params.Run, true);

            if (Input.GetKeyUp(KeyCode.W))
                _animator.SetBool(PlayerAnimationsController.Params.Run, false);

        }
        else
        {
            _animator.SetBool(PlayerAnimationsController.Params.Run, true);
        }
    }
    
    public void StartFinish()
    {
        isFinish = true;
    }
}
