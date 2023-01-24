using System.Collections;
using UnityEngine;

public class DeformationPickupMover : MonoBehaviour
{
    [SerializeField] private Transform[] _movePoints;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector3 _rotation;

    private int _currentMovePoint;
    private WaitForEndOfFrame _delay;

    private void Start()
    {
        _delay = new WaitForEndOfFrame();
    }

    private void Update()
    {
        Move();
        transform.Rotate(_rotation * Time.deltaTime);
    }

    private void Move()
    {
        if (transform.position == _movePoints[_currentMovePoint].position)
        {
            if (_currentMovePoint + 1 >= _movePoints.Length)
                _currentMovePoint = 0;
            else
                _currentMovePoint++;
        }

        transform.position = Vector3.MoveTowards(transform.position, _movePoints[_currentMovePoint].position, _moveSpeed * Time.deltaTime);
    }
}
