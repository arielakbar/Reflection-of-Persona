using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    void FixedUpdate()
    {
        transform.position = target.position + offset;
    }
}
