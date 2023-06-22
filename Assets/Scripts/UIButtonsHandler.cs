using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonsHandler : MonoBehaviour
{
    [SerializeField] GameObject[] EnableOnGameStart;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject StopMenu;
    [SerializeField] GameObject WinMenu;
    [SerializeField] GameObject FinishTheGameMenu;
    public Action OnStartButtonClickAction = () => { };
    private void Start()
    {
        GameManager.Instance.OnPlayerWinLevel.Add(() =>
        {
            WinMenu.SetActive(true);
        });

        GameManager.Instance.OnPlayerWinTheGame.Add(() =>
        {
            FinishTheGameMenu.SetActive(true);
        });
    }

    public void OnExitButtonClick()
    {
        Application.Quit();
    }
    public void OnStartButtonClick()
    {
        foreach (var obj in EnableOnGameStart)
            obj.SetActive(true);
        MainMenu.SetActive(false);
        Time.timeScale = 1;

        OnStartButtonClickAction();
    }
    public void OnMenuButtonClick()
    {
        foreach (var obj in EnableOnGameStart)
            obj.SetActive(false);
        StopMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnContinueButtonClick()
    {
        foreach (var obj in EnableOnGameStart)
            obj.SetActive(true);
        StopMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnRestartCheckPointButtonClick()
    {
        GameManager.Instance.Player.position = GameManager.Instance.PlayerStartPosition.position;
        foreach (var obj in EnableOnGameStart)
            obj.SetActive(true);
        StopMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnRestartLevelButtonClick()
    {
        Time.timeScale = 1;
        GameManager.Instance.SceneController.OpenCurrentScene();
    }

    public void OnMainMenuButtonClick()
    {
        StopMenu.SetActive(false);
        FinishTheGameMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void OnNextButtonClick(Animator animator)
    {
        animator.SetTrigger("t");
    }
}
