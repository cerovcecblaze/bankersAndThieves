using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TaskInteraction : MonoBehaviourPun
{

    [SerializeField] private float range = 10f;
    private Interactible target;

    private void Awake()
    {
        if (!photonView.IsMine) { return; }
        StartCoroutine(SearchForInteraction());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public IEnumerator SearchForInteraction()
    {
        while (true)
        {
            Interactible newT = null;
            Interactible[] interactionList = FindObjectsOfType<Interactible>();

            UIControl.Instance.HasInteractible = false;


            foreach (Interactible interactible in interactionList)
            {
                float distance = Vector3.Distance(transform.position, interactible.transform.position);
                if (distance > range) { continue; }

                newT = interactible;
                UIControl.Instance.HasInteractible = true;
                break;
            }

            if (UIControl.Instance.CurrentInteractible != newT &&
                    UIControl.Instance.CurrentInteractible != null)
            {
                UIControl.Instance.CurrentInteractible.Use(false);

            }

            target = newT;
            UIControl.Instance.CurrentInteractible = target;

            yield return new WaitForSeconds(0.25f);
        }
    }
}
