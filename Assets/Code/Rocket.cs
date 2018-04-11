using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    [SerializeField]
    UnityEngine.Object _explosionPrefab;
    [SerializeField]
    ExpLine _forceLinePrefab;
    Rigidbody _rigid; 

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
        _rigid.velocity = Util.GetRocketDir(GameManager.Player.transform.position) * Settings.RocketSpeed + GameManager.Player.Velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 _playerPos = GameManager.Player.transform.position;
        Vector3 _point = collision.contacts[0].point;
        float _force = (1 / (1 + (_playerPos - transform.position).magnitude)) * Settings.RocketForce;
        if (_force > 0.1f)
        {
            Vector3 _dir = (_playerPos - transform.position).normalized;
            GameManager.Player.ApplyForce(_dir * _force);
            ExpLine _forceLine = Instantiate(_forceLinePrefab, _point, Quaternion.identity);
            _forceLine.PlacePoints(transform.position, _playerPos); 
        }
        GameObject _explosionGO = Instantiate(_explosionPrefab, transform.position, Quaternion.identity) as GameObject;
        _explosionGO.transform.up = collision.contacts[0].normal;
        Destroy(gameObject); 
    }


}
