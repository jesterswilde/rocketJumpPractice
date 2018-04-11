using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocker : MonoBehaviour {

    [SerializeField]
    LayerMask _mask;

    List<Collider> _colls = new List<Collider>(); 
    public bool IsBlocked { get { return _colls.Count > 0; } }

    private void OnTriggerEnter(Collider other)
    {
        if (_mask.ContainsLayer(other.gameObject.layer))
        {
            if (!_colls.Contains(other))
            {
                _colls.Add(other); 
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (_mask.ContainsLayer(other.gameObject.layer))
        {
            if (_colls.Contains(other))
            {
                _colls.Remove(other); 
            }
        }
    }
}
