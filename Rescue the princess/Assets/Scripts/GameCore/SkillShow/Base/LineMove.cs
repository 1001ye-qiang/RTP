using UnityEngine;
using System.Collections;




public class LineMove : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 acceleration;
    //public float gravity;
    public float distance;

    Vector3 src;

    void Start()
    {
        src = transform.localPosition;
    }

    void Update()
    {
        if ((transform.localPosition - src).magnitude < distance)
        {
            transform.localPosition += velocity * Time.deltaTime;
            velocity += acceleration * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
