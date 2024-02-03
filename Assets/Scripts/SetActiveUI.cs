using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject[] uiElements;

    void Start()
    {
        // Đảm bảo rằng các UI Elements đã được gán trong Inspector
        if (uiElements == null || uiElements.Length == 0)
        {
            Debug.LogError("UI Elements not assigned!");
        }
    }

    // Mở UI Element cụ thể
    public void OpenUIElement(int index)
    {
        if (index >= 0 && index < uiElements.Length)
        {
            uiElements[index].SetActive(true);
        }
        else
        {
            Debug.LogError("Invalid UI Element index: " + index);
        }
    }

    // Tắt UI Element cụ thể
    public void CloseUIElement(int index)
    {
        if (index >= 0 && index < uiElements.Length)
        {
            uiElements[index].SetActive(false);
        }
        else
        {
            Debug.LogError("Invalid UI Element index: " + index);
        }
    }
}
