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
        if (photonView.IsMine)
        {
            StartCoroutine(SearchForInteraction());
        }
        else {
            return;
        }
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
            UIControl.UI.hasI = false;
            Interactible newT = null;
            Interactible[] interactionList = FindObjectsOfType<Interactible>();

            foreach (Interactible interactible in interactionList)
            {
                float distance = Vector3.Distance(transform.position, interactible.transform.position);
                if (distance <= range)
                {
                    newT = interactible;
                    UIControl.UI.hasI = true;
                    break;
                }
            }

            if (UIControl.UI.currentI != newT &&
                    UIControl.UI.currentI != null)
            {
                UIControl.UI.currentI.Use(false);

            }

            target = newT;
            UIControl.UI.currentI = target;

            yield return new WaitForSeconds(0.25f);
        }
    }
}
