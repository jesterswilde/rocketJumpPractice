using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    static UIManager t;


    [SerializeField]
    Canvas _canvas; 
    public static Canvas Canvas { get { return t._canvas; } }
    public static Transform CanvasTrans { get { return t._canvas.transform; } }


    private void Awake()
    {
        t = this; 
    }
}
