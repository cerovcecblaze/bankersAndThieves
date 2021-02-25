using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeTask : MonoBehaviour
{
    public Text screenText;

    public List<SwipePoint> swipePoints = new List<SwipePoint>();

    public float countMax = 0.5f;

    private int currentSP = 0;

    public GameObject green;
    public GameObject red;

    private float countdown = 0;
    // Start is called before the first frame update
    void Start()
    {
        screenText.text = "Swipe";
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (currentSP != 0 && countdown <= 0) {
            currentSP = 0;
            StartCoroutine(FinishTask(false));
        }
    }

    public void SwipePointTrigger(SwipePoint swipePoint)
    {
        if (swipePoint == swipePoints[currentSP]) {
            currentSP++;
            countdown = countMax;
        }
        if (currentSP >= swipePoints.Count) {
            currentSP = 0;
            
            StartCoroutine(FinishTask(true));
        }
    }

    private IEnumerator FinishTask(bool success) {
        if (success)
        {
            green.SetActive(true);
            screenText.text = "Success";
            
        }
        else {
            red.SetActive(true);
            screenText.text = "Failed";
        }
        yield return new WaitForSeconds(1f);

        if (success)
        {
            gameObject.SetActive(false);
        }
        green.SetActive(false);
        red.SetActive(false);
        screenText.text = "Swipe";

    }
}
