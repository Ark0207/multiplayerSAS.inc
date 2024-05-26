using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float amplitude = 1.5f;
    public float speed = 1.0f;
    public float initialY;
    // Start is called before the first frame update
    void Start()
    {
        initialY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = initialY + amplitude + Mathf.Sin(speed * Time.time);

        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
