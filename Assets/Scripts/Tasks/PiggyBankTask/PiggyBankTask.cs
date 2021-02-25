using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiggyBankTask : MonoBehaviour
{
    private int count = 0;
    [SerializeField] public List<Coin> coinList = new List<Coin>();

    [SerializeField] Text text;

    private float countdown = 0;
    // Start is called before the first frame update
    void Start()
    {
        ResetCoins();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PiggyBankTrigger(Collider2D coin)
    {
        count++;
        Debug.Log(coin.gameObject);
        coin.gameObject.SetActive(false);
        if (count >= 4) {
            StartCoroutine(FinishTask(true));
        }
    }

    private IEnumerator FinishTask(bool success)
    {
        if (success)
        {
            text.text = "Awesome! Super Secure";

        }
        else
        {
            
        }
        yield return new WaitForSeconds(1f);

        if (success)
        {
            gameObject.SetActive(false);

            ResetCoins();
        }
        
    }
    private void ResetCoins()
    {
        text.text = "Put the Coins in the Super Secure Place";
        count = 0;
        //y = 10 - 97
        //x = -120 - 120
        for(int i = 0; i < coinList.Count; i++)
        {
            coinList[i].transform.localPosition = new Vector3(
               Random.Range(-120, 120),
               Random.Range(10, 97),
               -1
           );
            coinList[i].gameObject.SetActive(true);
        }
        

    }
}
