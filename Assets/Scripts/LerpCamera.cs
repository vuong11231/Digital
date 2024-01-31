using DG.Tweening;
using UnityEngine;

public class LerpCamera : Singleton<LerpCamera>
{
    [SerializeField] private Transform cameraTr;

    Vector3 initCamearPos;

    private void Start()
    {
        initCamearPos = cameraTr.localPosition;
    }

    public void LerpTo(Vector3 newPos, float duration)
    {
        transform.DOMove(newPos, duration);
        cameraTr.DOLocalMove(initCamearPos, duration);
    }
}
