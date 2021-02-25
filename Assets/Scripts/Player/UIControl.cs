using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public static UIControl UI;

    public Button useButton;
    public bool hasI;
    public Interactible currentI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        useButton.interactable = hasI;
    }

    public void OnUseButtonPressed() {
        if (currentI == null) {
            return;
        }
        currentI.Use(true);
    }
    public void Awake() {
        UI = this;
    }
}
