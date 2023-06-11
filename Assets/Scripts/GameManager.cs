using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary> This class is instantiated befor all other monobehaviors created by game developers. </summary>
public class GameManager : MonoBehaviour
{
    private GameManager() { } // singleton

    public static GameManager Instance { get; private set; }

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

    /// <summary>
    /// A class that contains tags as hashsets.  <br></br>
    /// Do not create an object from this class. Use GameManager to get object instead. <br></br>
    /// Use the public hashset variables to find that if your  game object in any of these hashsets. if yes this game object has this tag. <br></br>
    /// eg: if(Enemies.contains(MyGameObject)) { print("This is an enemy!"); } <br></br>
    ///  <br></br>
    /// Be careful; you should add your game object to any hashset in awake method and call them in start method or in the methods that's called after awake method.
    ///  <br></br>
    ///  Using hashsets for tagging is 9x faster than using unity's "gameObject.tag". Also you can set tags more than 1 for game objects.
    /// </summary>
    public TagSets tagSets { get; private set; }


    /* Put all Object Pools here:
    [Header("Object Pools")]
    public ObjectPoolingSystem OPFireVFX;
    */

    public GameStatistics GameStatistics;
    public SimpleInventory SimpleInventory;

    public SceneController SceneController;

    public TextMeshProUGUI WinText; 

    private void Awake()
    {
        if ( ! (Player && GameStatistics && SimpleInventory && PlayerStartPosition && PlayerCamera && SceneController) )
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
        tagSets = new TagSets();
    }

    private void Start()
    {
        AddOnPlayerDie(() => {
            Player.position = PlayerStartPosition.position;
            GameStatistics.DieCount++;
        });
    }

    public void PlayerDied()
    {
        foreach (var func in OnPlayerDie)
            func();
    }

    public void GameFinished()
    {
        WinText.gameObject.SetActive(true);
    }
}
