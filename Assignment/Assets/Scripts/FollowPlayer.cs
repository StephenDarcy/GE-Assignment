using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public float speed = .125f;
    public Vector3 distanceFromPlayer;

    /// <summary>
    /// LateUpdate is called every frame, if the Behavior is enabled.
    /// It is called after all Update functions have been called.
    /// </summary>
    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + distanceFromPlayer;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        transform.position = smoothPosition;

        transform.LookAt(player);
    }

}
