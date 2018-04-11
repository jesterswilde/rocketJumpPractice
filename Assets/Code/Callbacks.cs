using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq; 

class TimeAction
{
    public TimeAction(float time, Action action)
    {
        Time = time;
        _action = action; 
    }
    Action _action;
    public float Time;
    public Action Action { get { return _action; } } 
}
public class Callbacks  {

    List<TimeAction> _fixedActions = new List<TimeAction>();
    List<TimeAction> _actions = new List<TimeAction>(); 

    public void AddFixedAction(Action _action, int _time)
    {
        TimeAction _cb = new TimeAction((float)_time, _action);
        _fixedActions.Add(_cb); 
    }
    public void AddAction(Action _action, float _time)
    {
        TimeAction _cb = new TimeAction(_time, _action);
        _actions.Add(_cb);
    }

    public void Update(float _delta)
    {

        bool _shouldFilter = false;
        _actions.ForEach((_cb) =>
        {
            _cb.Time -= _delta;
            if (_cb.Time <= 0)
            {
                _shouldFilter = true;
                _cb.Action();
            }
        });
        if (_shouldFilter)
        {
            _actions = _actions.Where((_cb) => _cb.Time > 0).ToList();
        }
    }
    public void FixedUpdate()
    {
        bool _shouldFilter = false; 
        _fixedActions.ForEach((_cb) =>
        {
            _cb.Time -= 1;
            if (_cb.Time <= 0)
            {
                _shouldFilter = true; 
                _cb.Action();
            }
        });
        if (_shouldFilter)
        {
            _fixedActions = _fixedActions.Where((_cb) => _cb.Time > 0).ToList(); 
        }
    }
}
