using UnityEngine;

// index = 0 mean open manager panel
// index = 1 mean open ai module panel

public enum E_PanelType
{
    WATCH,
    AI,
    CLOCK,
}
public class PanelSwitcher : MonoBehaviour
{
    public Animator openPanle;
    public Animator closePanel;

    public void SwitchPanel(E_PanelType TypePanel)
    {

        switch (TypePanel)
        {
            case E_PanelType.WATCH:
                openPanle.SetTrigger("open");
                closePanel.SetTrigger("close");
                break;
            case E_PanelType.AI:
                openPanle.SetTrigger("open");
                closePanel.SetTrigger("close");
                break;
        }
    }
}
