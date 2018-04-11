using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerManager : MonoBehaviour {

    [SerializeField]
    Blocker _forward;
    public Blocker Forward { get { return _forward; } }
    [SerializeField]
    Blocker _right;
    public Blocker Right { get { return _right; } }
    [SerializeField]
    Blocker _back;
    public Blocker Back { get { return _back; } }
    [SerializeField]
    Blocker _left;
    public Blocker Left { get { return _left; } }
    [SerializeField]
    Blocker _down;
    public Blocker Down { get { return _down; } }

    public void UpdatePos(Player _player)
    {
        transform.position = _player.transform.position; 
    }
}
