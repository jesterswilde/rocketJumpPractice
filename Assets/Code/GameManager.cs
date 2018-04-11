using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    static GameManager t;

    Callbacks _cb = new Callbacks(); 

    Player _player; 
    public static Player Player { get { return t._player; } }
    bool _canShoot = true; 

    [SerializeField]
    Rocket _rocketPrefab;

    [SerializeField]
    int _goalsNeeded = 1;
    int _goalsGotten = 0; 

    public static void GotGoal()
    {
        t._goalsGotten++; 
        if(t._goalsGotten >= t._goalsNeeded)
        {
            if(SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }


    public static void FixedCB(Action _action, int _duration)
    {
        t._cb.AddFixedAction(_action, _duration);
    }
    public static void CB(Action _action, float _duration)
    {
        t._cb.AddAction(_action, _duration); 
    }
    public static void RegisterPlayer(Player player)
    {
        t._player = player; 
    }

    void MakeRockets()
    {
        if (Input.GetMouseButtonDown(0) && _canShoot)
        {
            Instantiate(_rocketPrefab, _player.transform.position, Quaternion.identity);
            _canShoot = false;
            _cb.AddAction(() =>
                {
                    _canShoot = true;
                }, Settings.FireRate);
        }
    }
    void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        }
    }

    private void Update()
    {
        MakeRockets();
        Restart();
        _cb.Update(Time.deltaTime); 
    }
    private void FixedUpdate()
    {
        _cb.FixedUpdate(); 
    }

    private void Awake()
    {
        t = this; 
    }
}
