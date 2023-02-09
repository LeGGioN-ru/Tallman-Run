using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RunAnimationStarter : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Animator>().SetBool(PlayerAnimationsController.Params.Run, true);
    }
}
