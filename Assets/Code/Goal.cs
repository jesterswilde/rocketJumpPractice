using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    [SerializeField]
    Color _tintColor;
    [SerializeField]
    GoalUI _UIPrefab;
    GoalUI _ui; 

    bool IsVisible
    {
        get
        {
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
            return screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        }
    }

    private void Update()
    {
        if (!IsVisible)
        {
            if(_ui == null)
            {
                _ui = Instantiate(_UIPrefab);
                _ui.SetColor(_tintColor); 
            }
            _ui.Position(transform.position - GameManager.Player.transform.position);
        }
        else
        {
            if(_ui != null)
            {
                Destroy(_ui.gameObject); 
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        GameManager.GotGoal();
        Destroy(gameObject); 
    }
    private void Awake()
    {
        GetComponent<Renderer>().material.color = _tintColor; 
    }
}
