using DG.Tweening;
using UnityEngine;

public class LerpCamera : Singleton<LerpCamera>
{
    public void LerpTo(Transform target, float duration)
    {
        transform.DOMove(target.position, duration);
        transform.DOLookAt(target.forward, duration);
    }
}
