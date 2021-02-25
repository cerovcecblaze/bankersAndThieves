using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    public static UIControl Instance;

    public Button useButton;
    public bool HasInteractible;
    public Interactible CurrentInteractible;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        useButton.interactable = HasInteractible;
    }

    public void OnUseButtonPressed() {
        if (CurrentInteractible == null) {
            return;
        }
        CurrentInteractible.Use(true);
    }
    public void Awake() {
        Instance = this;
    }
}
