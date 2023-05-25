using UnityEngine;
using UnityEngine.XR;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public XRNode inputSource = XRNode.LeftHand; // Источник ввода для открытия меню паузы

    private bool isPaused = false;

    private void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    private void Update()
    {
        // Проверяем ввод с контроллера VR для открытия/закрытия меню паузы
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        if (device.TryGetFeatureValue(CommonUsages.menuButton, out bool menuButtonValue) && menuButtonValue)
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}