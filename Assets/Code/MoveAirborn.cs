using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAirborn : Movement
{
    public override MoveStates CheckState(Player _player)
    {
        if (_player.Blockers.Down.IsBlocked)
        {
            return MoveStates.grounded;
        }
        return MoveStates.current; 
    }

    public override void Enter(Rigidbody _rigid, Player _player, float _delta)
    {
        //_player.FacingDirection = new Vector3(_rigid.velocity.x, 0, _rigid.velocity.z).normalized;
    }

    public override void Exit(Rigidbody _rigid, Player _player, float _delta)
    {
    }

    public override void Move(Rigidbody _rigid, Player _player, float _delta)
    {
        Vector3 _inputs = GetMoveInputs();
        Vector3 _camFoward = Camera.main.transform.forward;
        _camFoward = new Vector3(_camFoward.x, 0, _camFoward.z).normalized;
        Vector3 _camRight = Camera.main.transform.right;
        _camRight = new Vector3(_camRight.x, 0, _camRight.z).normalized;
        Vector3 _playerDir = _camFoward * _inputs.z + _camRight * _inputs.x;
        _rigid.AddForce(_playerDir * _player.AirbornSpeed, ForceMode.Acceleration);
        if (_playerDir != Vector3.zero)
        {
            _player.FacingDirection = _playerDir;
        }
    }
}
