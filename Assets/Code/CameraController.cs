using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    float _rotationSpeed = 90;
    [SerializeField]
    float _rotationSensitivty = 1; 
    private void LateUpdate()
    {
        transform.position = GameManager.Player.transform.position;
        /*
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime * -1); 
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        }
        */
    }

    void HardRotation()
    {
        float _x = Input.GetAxisRaw("Mouse X") * _rotationSensitivty;
        float _y = Input.GetAxisRaw("Mouse Y") * _rotationSensitivty * -1;
        transform.Rotate(Vector3.right, _y);
        transform.Rotate(Vector3.up, _x);
        Vector3 _temp = transform.rotation.eulerAngles;
        _temp.z = 0;
        transform.rotation = Quaternion.Euler(_temp);
    }
}
