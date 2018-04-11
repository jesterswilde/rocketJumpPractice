using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    private void Start()
    {
        GameManager.CB(() => Destroy(gameObject), 5); 
    }
}
