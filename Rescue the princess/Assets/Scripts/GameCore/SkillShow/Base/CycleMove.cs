using UnityEngine;
using System.Collections;

public class CycleMove : MonoBehaviour
{
    public float speed;

    public float radius;
    public Vector3 direction;

    public bool bClockwise = true;

    public Vector3 center;
    void Start()
    {
        center = transform.localPosition + direction.normalized * radius;
    }

    void LateUpdate()
    {
        direction = transform.localPosition - center;
        Vector3 v = new Vector3(1, -direction.x / direction.y);
        if (direction.y > -float.Epsilon)
        {
            v = -v;
        }
        v = v.normalized * speed;
        Vector3 pos = transform.localPosition + v * Time.deltaTime;

        transform.localPosition = (pos - center).normalized * radius + center;
    }
}
