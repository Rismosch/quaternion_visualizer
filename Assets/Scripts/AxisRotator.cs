using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisRotator : MonoBehaviour
{
    // Unity Members
    [SerializeField] private Transform m_Camera;

    [SerializeField] private Vector3 m_Right;
    
    // Unity Event Methods
    private void LateUpdate()
    {
        var cameraForward = m_Camera.rotation * Vector3.forward;

        var upward = Vector3.Cross(cameraForward, m_Right);
        var forward = Vector3.Cross(upward, m_Right);

        if (upward.sqrMagnitude > 1e-7 && forward.sqrMagnitude > 1e-7)
        {
            var rotation = Quaternion.LookRotation(forward, upward);
            this.transform.rotation = rotation;
        }
    }
}
