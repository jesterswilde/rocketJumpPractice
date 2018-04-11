using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class Player : MonoBehaviour {
    


    [SerializeField]
    float _speed;
    public float Speed { get { return _speed; } }
    float _modSpeed = 0; 
    public float ModSpeed { get { return Mathf.Max(_speed, _modSpeed); } }
    public Vector3 Velocity { get { return _rigid.velocity; } }

    [SerializeField]
    BlockerManager _blockers;
    public BlockerManager Blockers { get { return _blockers; } }
    [SerializeField]
    float _airbornSpeed;
    public float AirbornSpeed { get { return _airbornSpeed; } }
    [SerializeField]
    float _yFudge = 1.2f;
    [SerializeField]
    float _rotSpeed = 180;
    List<Renderer>_renderers; 

    Vector3 _dirFace;
    public Vector3 FacingDirection { get { return _dirFace; } set { _dirFace = value; } }

    bool _recentlyHit = false; 
    public bool RecentlyHit { get { return _recentlyHit; } }

    Rigidbody _rigid;
    PlayerMovement _movement = new PlayerMovement(); 

    public void SetModSpeed(float modSpeed)
    {
        _modSpeed = modSpeed; 
    }

    public void ApplyForce(Vector3 _force)
    {
        _force.y *= _yFudge;
        _force *= ModSpeed / _speed; 
        _rigid.AddForce(_force, ForceMode.VelocityChange);
        _recentlyHit = true;
        GameManager.FixedCB(() => _recentlyHit = false, 10); 
    }
    void LerpFacing()
    {
        if(_dirFace != transform.forward)
        {
            float _angle = Vector3.SignedAngle(transform.forward, _dirFace, Vector3.up);
            _angle = Mathf.Clamp(_angle, _rotSpeed * -1, _rotSpeed);
            transform.Rotate(Vector3.up, _angle); 
        }
    }
    public void MoveToCheckpoint(Vector3 _position)
    {
        transform.position = _position;
        _rigid.velocity = Vector3.zero; 
    }

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
        _dirFace = transform.forward;
        _renderers = GetComponentsInChildren<Renderer>().ToList(); 
    }

    private void Start()
    {
        GameManager.RegisterPlayer(this); 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            _renderers.ForEach((_rend) => _rend.material.color = new Color(0.5f, 0, 0.5f)); 
        }
    }
    private void FixedUpdate()
    {
        _blockers.UpdatePos(this); 
        _movement.Update(_rigid, this, Time.fixedDeltaTime);
        LerpFacing(); 
    }

}
