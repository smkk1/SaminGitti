using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField]private Transform objectoToFollow;
    [SerializeField]private float followSpeed = 10;
    [SerializeField]private float lookSpeed = 10;
    [SerializeField]
    private GameObject cameraOffset;


    private void LookAtTarget()
    {
        Vector3 lookDirection = objectoToFollow.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rot, lookSpeed * Time.deltaTime);
    }

    private void MoveToTarget()
    {
        Vector3 targetPos = objectoToFollow.position + objectoToFollow.forward * CameraOffset.cameraOffset.z + objectoToFollow.right * CameraOffset.cameraOffset.x + objectoToFollow.up * CameraOffset.cameraOffset.y;
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        LookAtTarget();
        MoveToTarget();
    }


    void Start()
    {
        cameraOffset = GameObject.Find("CameraOffset");
        Debug.Log(CameraOffset.cameraOffset.z);
    }

}
