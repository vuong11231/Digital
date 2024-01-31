/***************************************************************/
/********** Simple target orientation camera script. ***********/
/*** You can change parameters, such as rotation/zoom speed. ***/
/***************************************************************/

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class CameraTargetOrientationScript : MonoBehaviour
{
    [Header("Mouse input:", order = 0)]
    [Space(-10, order = 1)]
    [Header("- Hold and drag RMB to rotate", order = 2)]
    [Space(-10, order = 3)]
    [Header("- Use mouse wheel to zoom in/out", order = 4)]
    [Space(5, order = 5)]

    [Header("Touch input:", order = 6)]
    [Space(-10, order = 7)]
    [Header("- Swipe left/right to rotate", order = 8)]
    [Space(-10, order = 9)]
    [Header("- Use multitouch to zoom in/out", order = 10)]
    [Space(15, order = 11)]

    public bool enableRotation = true;

    [Header("Choose target")]
    public Transform target;

    //Camera fields
    private float _smoothness = 0.5f;
    private Vector3 _cameraOffset;

    //Mouse control fields
    [Space(2)]
    [Header("Mouse Controls")]
    public float rotationSpeedMouse = 5;
    public float zoomSpeedMouse = 10;

    private float _zoomAmountMouse = 0;
    private float _maxToClampMouse = 10;

    //Touch control fields
    [Space(2)]
    [Header("Touch Controls")]
    public float rotationSpeedTouch = 5;
    public float zoomSpeedTouch = 0.5f;
    public float panSpeed = 2.0f;

    public Vector3 targetRot;

    public LayerMask UILayer;

    void Start()
    {
        _cameraOffset = transform.position - target.position;
        transform.LookAt(target);
    }

    void LateUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("Over UI");
            return;
        }

        // Rotating camera with RMB dragging on PC.
        if (enableRotation && (Input.GetMouseButton(0)))
        {
            targetRot = target.eulerAngles;
            targetRot.y += Input.GetAxis("Mouse X") * rotationSpeedMouse;
            targetRot.x += -Input.GetAxis("Mouse Y") * rotationSpeedMouse;
        }
        else if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            Vector3 moveDir = transform.right * -mouseX;
            moveDir += transform.up * -mouseY;

            // Pan the target position
            target.position += moveDir * panSpeed * Time.deltaTime;
        }

        target.rotation = Quaternion.Lerp(target.rotation, Quaternion.Euler(targetRot), 5 * Time.deltaTime);

        _zoomAmountMouse += Input.GetAxis("Mouse ScrollWheel");
        _zoomAmountMouse = Mathf.Clamp(_zoomAmountMouse, -_maxToClampMouse, _maxToClampMouse);

        var translate = Mathf.Min(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")), _maxToClampMouse - Mathf.Abs(_zoomAmountMouse));
        transform.Translate(0, 0, translate * zoomSpeedMouse * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")));

        _cameraOffset = transform.position - target.position;
    }
}