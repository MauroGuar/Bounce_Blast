using System;
using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject ballContainer;
    private BallMovement2 _ballMovementScript;

    private void Start()
    {
        _ballMovementScript = ballContainer.GetComponent<BallMovement2>();
    }

    public void PauseGame()
    {
        if (Time.timeScale > 0f)
        {
            Time.timeScale = 0f;
            // _ballMovementScript.AvoidMovement();
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
    }
}