using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinerScript : MonoBehaviour
{
    public float rotateValue = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateValue, 0, 0);
    }
}
