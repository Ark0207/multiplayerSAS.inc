using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class flicklight : MonoBehaviour
{
    public Light FlickerLight;
    public float minIntensity;
    public float maxIntensity;
    public float flickeringspeed;
    // Start is called before the first frame update
    void Start()
    {
        if(FlickerLight == null)
        {
            FlickerLight = GetComponent<Light>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        float lightIntesity = Random.Range(minIntensity, maxIntensity) ;
        FlickerLight.intensity = Mathf.Lerp(FlickerLight.intensity, lightIntesity,flickeringspeed) ;
    }
}
