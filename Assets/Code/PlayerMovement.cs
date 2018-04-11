using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement  {

    MoveStates _curentState = MoveStates.airborn;
    Movement _currentMovement = new MoveAirborn(); 

    public void Update(Rigidbody _rigid, Player _player, float _delta)
    {
        CheckState(_rigid, _player, _delta);
        Move(_rigid, _player, _delta); 
    }

    void Move(Rigidbody _rigid, Player _player, float _delta)
    {
        _currentMovement.Move(_rigid, _player, _delta);
    }
    void CheckState(Rigidbody _rigid, Player _player, float _delta)
    {
        MoveStates _state = _currentMovement.CheckState(_player);
        if (_state != MoveStates.current)
        {
            _currentMovement.Exit(_rigid, _player, _delta);
            switch (_state)
            {
                case MoveStates.grounded: _currentMovement = new MoveGround(); break;
                case MoveStates.airborn: _currentMovement = new MoveAirborn(); break;
            }
            _currentMovement.Enter(_rigid, _player, Time.deltaTime);
        }
    }
}
