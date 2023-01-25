using UnityEngine;

public class Bezier : MonoBehaviour
{
    public Vector3 GetPoint(Vector3 point0, Vector3 point1, Vector3 point2, Vector3 point3, float time)
    {
        time = Mathf.Clamp01(time);
        float oneMinusT = 1f - time;

        return oneMinusT * oneMinusT * oneMinusT * point0 +
            3f * oneMinusT * oneMinusT * time * point1 +
            3f * oneMinusT * time * time * point2 +
            time * time * time * point3;
    }
}
