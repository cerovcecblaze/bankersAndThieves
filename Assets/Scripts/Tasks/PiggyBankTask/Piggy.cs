using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piggy : MonoBehaviour
{
    private PiggyBankTask piggyTask;


    private Vector3 _startPos;
    private float _timer;
    private Vector3 _randomPos;
    public float _time = 0.1f;
    public float _distance = 0.001f;
    public float _delayBetweenShakes = 0.05f;

    private void OnValidate()
    {
        if (_delayBetweenShakes > _time)
            _delayBetweenShakes = _time;
    }

    public void Begin()
    {
        _startPos = transform.position;
        StopAllCoroutines();
        StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        _timer = 0f;

        while (_timer < _time)
        {
            _timer += Time.deltaTime;

            _randomPos = transform.position + (Random.insideUnitSphere * _distance);

            transform.position = _randomPos;

            if (_delayBetweenShakes > 0f)
            {
                yield return new WaitForSeconds(_delayBetweenShakes);
            }
            else
            {
                yield return null;
            }
        }
        transform.position = _startPos;
    }


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
        
        piggyTask = GetComponentInParent<PiggyBankTask>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Coin")
        {
            piggyTask.PiggyBankTrigger(collision);
            Begin();
        }
        
    }


}
