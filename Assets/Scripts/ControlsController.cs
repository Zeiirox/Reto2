using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsController : MonoBehaviour
{

    private bool isActive = false;
    
    public void CloseAndOpenPanels(GameObject panel)
    {
        isActive = !panel.activeSelf;
        panel.SetActive(isActive);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
