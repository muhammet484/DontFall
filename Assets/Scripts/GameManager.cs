using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary> This class is instantiated before all other monobehaviors created by game developers. </summary>
public class GameManager : MonoBehaviour
{
    private GameManager() { } // singleton

    public static GameManager Instance { get; private set; }

    public float SceneTransitionDelay = 3;

    [Header("Important instances")]
    public Transform Player;
    [SerializeField] private Camera _PlayerCamera;

    public Transform PlayerStartPosition;

    public Camera PlayerCamera
    {
        get { return _PlayerCamera; }
        set { _PlayerCamera = value;
            foreach (var action in OnPlayerCameraChanged) action();
        }
    }
    HashSet<Action> OnPlayerCameraChanged;
    public void AddOnPlayerCameraChanged(Action action) { OnPlayerCameraChanged.Add(action); }
    public void RemoveOnPlayerCameraChanged(Action action) { OnPlayerCameraChanged.Remove(action); }

    HashSet<Action> OnPlayerDie = new HashSet<Action>();
    public void AddOnPlayerDie(Action action) { OnPlayerDie.Add(action); }
    public void RemoveOnPlayerDie(Action action) { OnPlayerDie.Remove(action); }

    [HideInInspector] public GameStatistics GameStatistics;
    [HideInInspector] public SimplePlayerInventory PlayerInventory;

    public SceneController SceneController;

    private int _playerHealthCount = 3;
    public int GetPlayerHealthCount() { return _playerHealthCount; }
    public int IncreasePlayerHealthCount(int Quantity) { 
        _playerHealthCount += Quantity;
        foreach (var act in OnPlayerHealthIncrease)
            act();
        return _playerHealthCount; 
    }
    private int DecreasePlayerHealthCount(int Quantity)
    {
        _playerHealthCount -= Quantity;

        if (_playerHealthCount < 1)
        {
            foreach (var act in OnPlayerLoose)
                act();
        }

        return _playerHealthCount;
    }

    HashSet<Action> OnPlayerHealthIncrease = new HashSet<Action>();
    public void AddOnPlayerHealthIncrease(Action action) { OnPlayerHealthIncrease.Add(action); }
    public void RemoveOnPlayerHealthIncrease(Action action) { OnPlayerHealthIncrease.Remove(action); }

    [Tooltip("Runs when player health count become 0")]
    HashSet<Action> OnPlayerLoose = new HashSet<Action>();
    public void AddOnPlayerLoose(Action action) { OnPlayerLoose.Add(action); }
    public void RemoveOnPlayerLoose(Action action) { OnPlayerLoose.Remove(action); }

    [Tooltip("Will be called when player win the last level")]
    public HashSet<Action> OnPlayerWinTheGame = new HashSet<Action>();

    [Tooltip("Will be called when player win a level except last level")]
    public HashSet<Action> OnPlayerWinLevel = new HashSet<Action>();

    private void Awake()
    {
        if ( ! (Player && (GameStatistics != null) && (PlayerInventory != null) && PlayerStartPosition && PlayerCamera && SceneController) )
        {
            Debug.LogError("Null object in Game Manager!");
        }
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        //new instances:
        OnPlayerCameraChanged = new HashSet<Action>();
    }

    private void Start()
    {
        AddOnPlayerDie(() => {
            DecreasePlayerHealthCount(1);
            if(_playerHealthCount > 0)
                Player.position = PlayerStartPosition.position;
            GameStatistics.DieCount++;
        });

        AddOnPlayerLoose(() => { print("Player lost. All health is finished."); });

        Time.timeScale = 0;
    }

    public void PlayerDied()
    {
        foreach (var func in OnPlayerDie)
            func();
    }

    public void GameFinished()
    {
        foreach (var act in OnPlayerWinTheGame)
            act();
    }

    public void LoadFromLastCheckPoint()
    {
        Player.position = PlayerStartPosition.position;
    }
}
