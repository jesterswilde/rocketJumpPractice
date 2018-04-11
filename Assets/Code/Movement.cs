using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement {

    public abstract void Move(Rigidbody _rigid, Player _player, float _delta);
    public abstract void Enter(Rigidbody _rigid, Player _player, float _delta);
    public abstract void Exit(Rigidbody _rigid, Player _player, float _delta);
    public abstract MoveStates CheckState(Player _player); 

    protected Vector3 GetMoveInputs()
    {
        Vector3 _inputs = new Vector3(); 
        if(Input.GetKey(KeyCode.W)){
            _inputs.z += 1; 
        }
        if (Input.GetKey(KeyCode.S))
        {
            _inputs.z -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _inputs.x += 1; 
        }
        if (Input.GetKey(KeyCode.A))
        {
            _inputs.x -= 1; 
        }

        return _inputs;
    }

}

public enum MoveStates
{
    grounded,
    airborn,
    current
}
