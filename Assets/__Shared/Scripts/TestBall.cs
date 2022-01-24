using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
         
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 5 * JoySticksAnalog.Instance.GetP1Potval(),  transform.position.z);
    }
}
