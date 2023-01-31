using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _leftGroundBorder;
    [SerializeField] private float _rightGroundBorder;
    [SerializeField] private float _eulerYMin;
    [SerializeField] private float _eulerYMax;

    private float _oldMousePositionX;
    private float _eulerY;
   
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            _oldMousePositionX = Input.mousePosition.x;

        if(Input.GetMouseButton(0))
        {
            Move();
            Rotate();
        }
    }

    private void Move()
    {
        Vector3 newPosition = transform.position + transform.forward * Time.deltaTime * _speed;
        newPosition.x = Mathf.Clamp(newPosition.x, _leftGroundBorder, _rightGroundBorder);
        transform.position = newPosition;
    }

    private void Rotate()
    {
        float deltaX = Input.mousePosition.x - _oldMousePositionX;
        _oldMousePositionX = Input.mousePosition.x;

        _eulerY += deltaX * _rotationSpeed;
        _eulerY = Mathf.Clamp(_eulerY, _eulerYMin, _eulerYMax);
        transform.eulerAngles = new Vector3(0, _eulerY, 0);
    }

    public void IncreaseMoveSpeed(float value)
    {
        _speed += value;
    }
}