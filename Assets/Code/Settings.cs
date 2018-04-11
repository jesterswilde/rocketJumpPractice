using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

    static Settings t;

    [SerializeField]
    LayerMask _targetingMask; 
    public static LayerMask TargetingMask { get { return t._targetingMask; } }
    [SerializeField]
    LayerMask _rocketMask; 
    public static LayerMask RocketMask { get { return t._rocketMask; } }


    [SerializeField]
    float _rocketSpeed = 10; 
    public static float RocketSpeed { get { return t._rocketSpeed; } }
    [SerializeField]
    float _rocketForce = 10;
    public static float RocketForce { get { return t._rocketForce; } }
    [SerializeField]
    float _fireRate = 0.5f; 
    public static float FireRate { get { return t._fireRate; } }
    [SerializeField]
    Color _checkpointColor;
    public static Color CheckpoingColor { get { return t._checkpointColor; } }
    [SerializeField]
    float _checkpointVisibleDist;
    public static float CheckpointVisibleDist { get { return t._checkpointVisibleDist; } }

    private void Awake()
    {
        t = this; 
    }
}
