using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Bezier))]
[RequireComponent(typeof(AudioSource))]
public class JumpPanel : MonoBehaviour
{
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private Transform _point3;
    [SerializeField] private Transform _point4;
    [SerializeField] private Bezier _bezier;
    [SerializeField] private float _jumpSpeed = 0.01f;

    private float _time;
    private AudioSource _audioSource;

    private void Start()
    {
        _bezier = GetComponent<Bezier>();
        _audioSource = GetComponent<AudioSource>();
    }

    private IEnumerator JumpCoroutine(Transform player)
    {
        while (_time < 1)
        {
            _time = Mathf.MoveTowards(_time, 1, _jumpSpeed);
            player.position = _bezier.GetPoint(_point1.position, _point2.position, _point3.position, _point4.position, _time);

            yield return new WaitForFixedUpdate();
        }
    }

    public void Jump(Transform player)
    {
        _audioSource.Play();
        StartCoroutine(JumpCoroutine(player));
    }

    private void OnDrawGizmos()
    {
        int sigmentNumber = 20;
        Vector3 preveousePoint = _point1.position;

        for (int i = 0; i < sigmentNumber + 1; i++)
        {
            float parametr = (float)i / sigmentNumber;
            Vector3 point = _bezier.GetPoint(_point1.position, _point2.position, _point3.position, _point4.position, parametr);
            Gizmos.DrawLine(preveousePoint, point);
            preveousePoint = point;
        }
    }
}