using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    [Range(1,10)] public float smoothFactor;

    private void FixedUpdate()
    {
        Follow();
    }

    void Follow() //La camara sigue el player con un SmoothOffset para no marearse y que sea mas agradable a la vista
    {
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothPosition =Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
