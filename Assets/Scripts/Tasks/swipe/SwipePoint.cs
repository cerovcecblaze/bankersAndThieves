using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipePoint : MonoBehaviour
{
    private SwipeTask swipeTask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        swipeTask = GetComponentInParent<SwipeTask>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        swipeTask.SwipePointTrigger(this);
    }
}
