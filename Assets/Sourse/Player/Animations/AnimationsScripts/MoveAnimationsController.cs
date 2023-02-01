using UnityEngine;

public class MoveAnimationsController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private bool isFinish = false;

    private void Update()
    {
        if (isFinish == false)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.W))
            {
                _animator.SetBool(PlayerAnimationsController.Params.Run, true);
            }
            else
            {
                if (Input.GetMouseButtonUp(0) && Input.GetKey(KeyCode.W) == false)
                    _animator.SetBool(PlayerAnimationsController.Params.Run, false);

                if(Input.GetKeyUp(KeyCode.W) && Input.GetMouseButton(0) == false)
                    _animator.SetBool(PlayerAnimationsController.Params.Run, false);
            }
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
