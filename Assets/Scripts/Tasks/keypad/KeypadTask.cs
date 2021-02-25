using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadTask : MonoBehaviour
{

    public Text employeeNum;
    public Text input;
    public int length = 6;
    private bool reset = false;

    // Start is called before the first frame update
    void OnEnable()
    {
        employeeNum.text = Random.Range(111111, 999999).ToString();
        input.text = "";

    }

    public void NumberClicked(int number) {
        if (reset) {
            return;
        }

        input.text += number;

        if (input.text == employeeNum.text)
        {
            input.text = "SUCCESS";
            StartCoroutine(ResetPad());
            

        }
        else if (input.text.Length >= length) {
            input.text = "FAILED";
            StartCoroutine(ResetPad());
        }

    }

    private IEnumerator ResetPad()
    {
        reset = true;

        yield return new WaitForSeconds(1f);
        if (input.text == "SUCCESS")
        {
            gameObject.SetActive(false);
        }
        input.text = "";
        reset = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
