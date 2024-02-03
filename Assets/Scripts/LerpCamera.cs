using DG.Tweening;
using UnityEngine;

public class LerpCamera : Singleton<LerpCamera>
{
    public SmoothCameraRotationAroundPoint smoothCameraRotationAroundPoint;
    public FreeFlyCamera flyCamera;

    public void LerpTo(Transform target, float duration)
    {
        flyCamera.Active = false;
        smoothCameraRotationAroundPoint.Active = false;

        transform.DOMove(target.position, duration);
        Vector3 newAnchor = GetIntersectionPoint(target.position, target.forward);
        transform.DORotate(target.rotation.eulerAngles, duration).OnComplete(() =>
        {
            smoothCameraRotationAroundPoint.targetPoint = newAnchor;
            flyCamera.Active = true;
            smoothCameraRotationAroundPoint.Active = true;
            transform.LookAt(smoothCameraRotationAroundPoint.targetPoint);
        });
        
    }

    Vector3 GetIntersectionPoint(Vector3 origin, Vector3 direction)
    {
        // Tìm t thỏa mãn phương trình của đường thẳng: origin + t * direction
        // Trong trường hợp mặt phẳng XZ, y = 0
        float t = -origin.y / direction.y;

        // Tính toán điểm cắt
        Vector3 intersectionPoint = origin + t * direction;

        return intersectionPoint;
    }
}
