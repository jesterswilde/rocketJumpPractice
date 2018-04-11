using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour {

    static CheckpointManager t;

    Checkpoint _latestCheckpoint;
    [SerializeField]
    float _killYPos = -10; 


    public static void ReachedCheckpoint(Checkpoint _checkpoint)
    {
        if(t._latestCheckpoint == null || _checkpoint.Priority >= t._latestCheckpoint.Priority)
        {
            if (t._latestCheckpoint != null) {
                t._latestCheckpoint.Deselected(); 
            }
            _checkpoint.Selected();
            t._latestCheckpoint = _checkpoint; 
        }
    }

    private void Update()
    {
        if(GameManager.Player.transform.position.y < _killYPos || Input.GetKeyDown(KeyCode.F))
        {
            GameManager.Player.MoveToCheckpoint(_latestCheckpoint.DropPos);
        }
    }

    private void Awake()
    {
        t = this; 
    }
}
