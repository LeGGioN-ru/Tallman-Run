using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private Transform _player;

    void LateUpdate()
    {
        transform.position = _player.position;
    }
}