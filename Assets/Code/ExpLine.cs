using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpLine : MonoBehaviour {

    [SerializeField]
    float _width = 5; 
    [SerializeField]
    float _duration = 2; 
    LineRenderer _line;
    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
        GameManager.CB(() => Destroy(gameObject), _duration); 
    }

    public void PlacePoints(Vector3 _from, Vector3 _to)
    {
        _line.SetPositions(new Vector3[] { _from, _to });
        float _dist = Vector3.Distance(_from, _to);
        _line.startWidth = 1 / (1 + _dist * _dist) * _width;  
    }
}
