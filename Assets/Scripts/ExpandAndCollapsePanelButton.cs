using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpandAndCollapsePanelButton : MonoBehaviour
{
    public Animator animator; // Kéo và thả Animator vào trường này trong Inspector
    public string parameterName1 = "TriggerParameter1"; // Đặt tên của trigger parameter thứ nhất
    public string parameterName2 = "TriggerParameter2"; // Đặt tên của trigger parameter thứ hai
    private bool isToggleOn = false; // Biến boolean để theo dõi trạng thái toggle

    private void Start()
    {
        if (animator == null)
        {
            Debug.LogError("Animator is not assigned to the script. Please assign it in the Inspector.");
        }

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
        // Chuyển đổi giữa hai trigger parameters khi nút được nhấn
        isToggleOn = !isToggleOn;

        // Kích hoạt trigger parameter tương ứng
        if (isToggleOn)
        {
            animator.SetTrigger(parameterName1);
        }
        else
        {
            animator.SetTrigger(parameterName2);
        }
    }
}
