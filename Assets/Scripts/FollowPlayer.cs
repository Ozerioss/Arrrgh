using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    Vector3 offset;
    public Transform playerToFollow;
    public float smoothing = 5;

    // Use this for initialization
    void Start()
    {
        offset = transform.position - playerToFollow.position;
    }

    // Waits for physics to be called before updating the frame
    void FixedUpdate()
    {
        Vector3 targetCamPos = playerToFollow.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
