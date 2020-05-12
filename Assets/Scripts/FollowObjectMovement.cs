using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectMovement : MonoBehaviour
{
    public Transform TargetTransform;

    private float xOffset;
    private float yOffset;
    private float zOffset;
    // Start is called before the first frame update
    void Start()
    {
        xOffset = transform.position.x - TargetTransform.position.x;
        yOffset = transform.position.y - TargetTransform.position.y;
        zOffset = transform.position.z - TargetTransform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(
            TargetTransform.position.x + xOffset,
            TargetTransform.position.y + yOffset,
            TargetTransform.position.z + zOffset);
        
    }
}
