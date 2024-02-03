using UnityEngine;
using UnityEngine.SceneManagement;

// Enum để xác định loại panel
public enum E_PanelTypeTest
{
    WATCH,
    AI,
    CLOCK,
}

public class SwitchPanel1 : MonoBehaviour
{
    public CanvasGroup managerPanel;
    public CanvasGroup AIpanel;
    public CanvasGroup Clock_Cr;

    public Animator transitionAnimator; // Animator cho hiệu ứng chuyển cảnh

    void Start()
    {
        // Đảm bảo rằng các CanvasGroup đã được gán trong Inspector
        if (managerPanel == null || AIpanel == null)
        {
            Debug.LogError("CanvasGroups not assigned!");
        }
    }

    public void SwitchPanel(E_PanelType panelType)
    {
        // Ẩn tất cả các panel trước khi mở panel mới
        HideAllPanels();

        // Mở panel tương ứng
        switch (panelType)
        {
            case E_PanelType.WATCH:
                managerPanel.alpha = 1f; // Hiện panel
                managerPanel.blocksRaycasts = true; // Cho phép tương tác
                managerPanel.interactable = true;
                break;

            case E_PanelType.AI:
                AIpanel.alpha = 1f; // Hiện panel
                AIpanel.blocksRaycasts = true; // Cho phép tương tác
                AIpanel.interactable = true;
                break;
            case E_PanelType.CLOCK:
                AIpanel.alpha = 1f; // Hiện panel
                AIpanel.blocksRaycasts = true; // Cho phép tương tác
                AIpanel.interactable = true;
                break;
        }

        // Chạy animation chuyển cảnh
        transitionAnimator.SetTrigger("StartTransition");
    }

    // Ẩn tất cả các panel
    private void HideAllPanels()
    {
        managerPanel.alpha = 0f; // Ẩn panel
        managerPanel.blocksRaycasts = false; // Không cho phép tương tác
        managerPanel.interactable = false;

        AIpanel.alpha = 0f; // Ẩn panel
        AIpanel.blocksRaycasts = false; // Không cho phép tương tác
        AIpanel.interactable = false;

       
    }

    // Phương thức này được kết nối với sự kiện hoàn thành animation chuyển cảnh
    public void OnTransitionComplete()
    {
        // Tùy thuộc vào yêu cầu của bạn, bạn có thể thực hiện load cảnh mới ở đây
        // SceneManager.LoadScene("TênCảnhMới");
    }
}
