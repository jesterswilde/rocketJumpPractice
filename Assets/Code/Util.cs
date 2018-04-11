using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{



    public static Vector3 GetRocketDir(Vector3 _playerPos)
    {
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hit;
        if (Physics.Raycast(_ray, out _hit, 100, Settings.TargetingMask))
        {
            return (_hit.point - _playerPos).normalized;
        }
        return (_ray.GetPoint(100) - _playerPos).normalized;
    }
}

public static class ExtHelper {
    public static bool ContainsLayer(this LayerMask _mask, int _layer)
    {
        return (_mask == (_mask | (1 << _layer))); 
    }
}
