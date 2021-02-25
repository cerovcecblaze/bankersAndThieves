using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Coin : MonoBehaviour, IDragHandler
{
    private Canvas canvas;

    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        Debug.Log(canvas);

    }

    public void OnDrag(PointerEventData ed)
    {
        Vector2 p;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            ed.position,
            canvas.worldCamera,
            out p);
        transform.position = canvas.transform.TransformPoint(p);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
