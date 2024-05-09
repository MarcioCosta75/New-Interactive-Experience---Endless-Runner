using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteraction : MonoBehaviour
{
    public GameObject objectToSetActiveFalse;

    public bool timerDown;
    public float timer, startTimer;

    // Start is called before the first frame update
    void Start()
    {
        startTimer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerDown == true)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                objectToSetActiveFalse.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Switch")
        {
            //objectToSetActiveFalse.SetActive(false);
            timerDown = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Switch")
        {
            //objectToSetActiveFalse.SetActive(false);
            timerDown = false;
            timer = startTimer;
        }
    }
}
