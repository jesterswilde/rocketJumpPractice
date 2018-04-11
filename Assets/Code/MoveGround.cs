using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : Movement
{
    public override MoveStates CheckState(Player _player)
    {
        if (_player.Blockers.Down.IsBlocked)
        {
            return MoveStates.current; 
        }
        return MoveStates.airborn; 
    }

    public override void Enter(Rigidbody _rigid, Player _player, float _delta)
    {
        _player.SetModSpeed(Mathf.Abs(_rigid.velocity.x) * 0.8f);
    }

    public override void Exit(Rigidbody _rigid, Player _player, float _delta)
    {
    }

    public override void Move(Rigidbody _rigid, Player _player, float _delta)
    {
        if (!_player.RecentlyHit)
        {
            Vector3 _inputs = GetMoveInputs();
            Vector3 _camFoward = Camera.main.transform.forward;
            _camFoward = new Vector3(_camFoward.x, 0, _camFoward.z).normalized;
            Vector3 _camRight = Camera.main.transform.right;
            _camRight = new Vector3(_camRight.x, 0, _camRight.z).normalized;
            _rigid.velocity = (_camFoward * _inputs.z + _camRight * _inputs.x) * _player.ModSpeed; 
            if(_rigid.velocity != Vector3.zero)
            {
                _player.FacingDirection = _rigid.velocity;
            }
            else
            {
                _player.SetModSpeed(0); 
            }
        }
    }
}
