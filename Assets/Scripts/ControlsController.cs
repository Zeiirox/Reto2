using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ControlsController : MonoBehaviour
{

    private bool panelIsActive = false;
    [SerializeField] private AudioSource backgoundSound;
    [SerializeField] private AudioSource forentSound;
    [SerializeField] private Slider volumeSlide = null;
    [SerializeField] private TextMeshProUGUI volumeLevel = null;
    [SerializeField] private GameObject configurationsPanel = null;

    private void Start()
    {
        LoadConfiguration();
    }

    public void VolumeLevel(float volume)
    {
        volumeLevel.text = (Mathf.Round(volume * 100f) / 100f).ToString();
        backgoundSound.volume = volume;
    }

    private void LoadConfiguration()
    {
        if (volumeSlide != null)
        {
            float volumeLevel = PlayerPrefs.GetFloat("Volume");
            volumeSlide.value = volumeLevel;
            this.volumeLevel.text = volumeLevel.ToString();
            backgoundSound.volume = volumeLevel;
        }
    }

    public void SaveConfiguration()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlide.value);
        configurationsPanel.SetActive(false);
        panelIsActive = !panelIsActive;
        backgoundSound.volume = volumeSlide.value;
    }

    public void CloseAndOpenPanels(GameObject panel)
    {
        panelIsActive = !panel.activeSelf;
        panel.SetActive(panelIsActive);
    }

    public void Pause(GameObject panel)
    {
        Time.timeScale = 0;
        panelIsActive = !panel.activeSelf;
        panel.SetActive(panelIsActive);
    }

    public void Continue(GameObject panel)
    {
        Time.timeScale = 1;
        panelIsActive = !panel.activeSelf;
        panel.SetActive(panelIsActive);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void SetMute(bool toogle)
    {
        backgoundSound.mute = toogle;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }




}
