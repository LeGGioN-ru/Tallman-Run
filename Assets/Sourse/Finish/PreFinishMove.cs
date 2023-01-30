using UnityEngine;

public class PreFinishMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _rotationSpeed = 100f;

    void Update()
    {
        float x = Mathf.MoveTowards(transform.position.x, 0f, Time.deltaTime * _speed);
        float z = transform.position.z + _speed * Time.deltaTime;
        transform.position = new Vector3(x, 0, z);

        if(transform.eulerAngles.y < 180)
        {
            float rotation = Mathf.MoveTowards(transform.eulerAngles.y, 0, Time.deltaTime * _rotationSpeed);
            transform.eulerAngles = new Vector3(0, rotation, 0);
        }
        else
        {
            float rotation = Mathf.MoveTowards(transform.eulerAngles.y, 360, Time.deltaTime * _rotationSpeed);
            transform.eulerAngles = new Vector3(0, rotation, 0);
        }
    }
}