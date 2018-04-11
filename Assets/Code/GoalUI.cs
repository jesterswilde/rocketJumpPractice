using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalUI : MonoBehaviour {

    RectTransform _rect;
    [SerializeField]
    Image _image;


    public void Position(Vector3 _dir)
    {
        Transform _cam = Camera.main.transform; 
        
        Vector3 _dirNorm = _cam.InverseTransformDirection(_dir.normalized);
        Rect _canvasRect = UIManager.Canvas.pixelRect;
        float y = _canvasRect.height / 2;
        float x = _canvasRect.width / 2;
        _rect.anchoredPosition = new Vector2(x * _dirNorm.x, y * _dirNorm.y) * 0.9f;
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, Mathf.Min(1 - (_dir.magnitude / Settings.CheckpointVisibleDist), 1));
    }

    public void SetColor(Color _color)
    {
        _image.color = _color; 
    }
    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        transform.SetParent(UIManager.CanvasTrans); 
    }
}
