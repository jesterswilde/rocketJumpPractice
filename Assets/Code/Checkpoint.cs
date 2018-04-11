using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    [SerializeField]
    int _priority;
    public int Priority { get { return _priority; } }
    [SerializeField]
    Transform _dropTrans; 
    public Vector3 DropPos { get { return _dropTrans.position; } }
    [SerializeField]
    Renderer _rend;
    Color _baseColor; 

    private void Awake()
    {
        if(_rend != null)
        {
            _baseColor = _rend.material.color;
        }
        if(_dropTrans == null)
        {
            _dropTrans = transform; 
        }
    }
    public void Selected()
    {
        if(_rend != null)
        {
            _rend.material.color = Settings.CheckpoingColor; 
        }
    }
    public void Deselected()
    {
        if(_rend != null)
        {
            _rend.material.color = _baseColor; 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        CheckpointManager.ReachedCheckpoint(this); 
    }

}
