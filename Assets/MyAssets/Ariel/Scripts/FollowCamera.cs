using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool enable;

    void FixedUpdate()
    {
        if (enable)
        {
            transform.position = target.position + offset;
        }
    }
}
