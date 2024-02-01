using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLerp : MonoBehaviour
{
    [SerializeField] Transform targetPosition;
    [SerializeField] float duration;

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.LogError("Button component not found on the GameObject.");
        }
    }

    private void OnButtonClick()
    {
        LerpCamera.instance.LerpTo(targetPosition, duration);
    }
}
