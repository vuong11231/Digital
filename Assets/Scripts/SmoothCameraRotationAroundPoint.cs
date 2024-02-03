using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SmoothCameraRotationAroundPoint : MonoBehaviour
{
    public Vector3 targetPoint;
    public float rotationSpeed = 5f;
    public bool Active;

    void Update()
    {
        if (!Active)
            return;

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        reCalculatorAnchor();

        if (Input.GetMouseButton(0))
        {
            RotateCamera();
        }

        if (Input.GetMouseButton(1))
        {
            ChangeTargetPoint();
        }
    }

    void RotateCamera()
    {
        // Lấy giá trị di chuyển chuột theo trục X và Y
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Tính toán góc quay theo trục X và Y
        float rotationX = mouseY * rotationSpeed;
        float rotationY = mouseX * rotationSpeed;

        // Quay camera quanh điểm targetPoint
        transform.RotateAround(targetPoint, Vector3.up, rotationY);
        transform.RotateAround(targetPoint, transform.right, -rotationX);
    }

    void ChangeTargetPoint()
    {
        // Lấy giá trị di chuyển chuột theo trục X và Y
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Chuyển đổi giá trị di chuyển chuột sang hệ toạ độ local của camera
        Vector3 moveDirection = transform.TransformDirection(new Vector3(-mouseX, 0f, mouseY));

        // Thay đổi targetPoint dựa trên giá trị di chuyển chuột
        targetPoint += moveDirection * rotationSpeed * Time.deltaTime;

        // Cập nhật vị trí của camera
        transform.position += moveDirection * rotationSpeed * Time.deltaTime;
    }

    public void reCalculatorAnchor()
    {
        IntersectionPoint(transform.position, transform.forward);
    }

    void IntersectionPoint(Vector3 origin, Vector3 direction)
    {
        // Tìm t thỏa mãn phương trình của đường thẳng: origin + t * direction
        // Trong trường hợp mặt phẳng XZ, y = 0
        float t = -origin.y / direction.y;

        // Tính toán điểm cắt
        targetPoint = origin + t * direction;
    }

}
