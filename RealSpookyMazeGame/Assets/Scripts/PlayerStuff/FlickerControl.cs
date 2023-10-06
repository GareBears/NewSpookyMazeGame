using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerControl : MonoBehaviour
{
    public bool isFlickering = true;
    public bool flickerOK = true;
    public float timeDelay;

    // Update is called once per frame
    void Update()
    {
        if (flickerOK == true)
        {
            if (isFlickering == false)
            {
                StartCoroutine(FlickeringLight());
            }
        }
    }

    IEnumerator FlickeringLight()
    {
        isFlickering=true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);
        //isFlickering = false;
    }

    public void FlickerFalse()
    {
        isFlickering = false;
    }

    public void FlickerTrue()
    {
        isFlickering = true;
    }

    public void FlickerOKSettings()
    {
        flickerOK = true;
    }

    public void FlickerNotOkSettings()
    {
        flickerOK = false;
    }
}
