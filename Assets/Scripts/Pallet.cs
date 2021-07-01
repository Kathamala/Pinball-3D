using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pallet : MonoBehaviour
{
    public GameObject pivot;
    public int side; //0 left 1 right
    public float maxDegree = 25;
    public float minDegree = -20;


    // Start is called before the first frame update
    void Start()
    {
        if(side == 0){
            transform.RotateAround(pivot.transform.position, Vector3.right, 25);
        } else{
            transform.RotateAround(pivot.transform.position, Vector3.left, 25);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow) && side == 0)
        {
            /*
            while(transform.rotation.x > minDegree){
                
            }*/
            transform.RotateAround(pivot.transform.position, Vector3.left, 1);
        }
        
        if(Input.GetKeyUp(KeyCode.LeftArrow) && side == 0){
            transform.RotateAround(pivot.transform.position, Vector3.right, 1);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && side == 1)
        {
            transform.RotateAround(pivot.transform.position, Vector3.right, 1);
        }
        
        if(Input.GetKeyUp(KeyCode.RightArrow) && side == 1){
            transform.RotateAround(pivot.transform.position, Vector3.left, 1);
        }
    }
}
