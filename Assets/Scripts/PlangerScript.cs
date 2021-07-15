using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlangerScript : MonoBehaviour
{
    float power;
    public float maxPower = 100f;
    public Slider powerSlider;
    bool ballReady;
    public GameObject ball;
    private Rigidbody ballRigidbody;

    void Start()
    {
        powerSlider.minValue = 0f;
        powerSlider.maxValue = maxPower;
        ballRigidbody = ball.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(ballReady){
            powerSlider.gameObject.SetActive(true);
        } else{
            powerSlider.gameObject.SetActive(false);
        }

        powerSlider.value = power;

        if(ballReady){
            if(Input.GetKey(KeyCode.Space)){
                if(power <= maxPower){
                    power += 150 * Time.deltaTime;
                }
            }

            if(Input.GetKeyUp(KeyCode.Space)){
                ballRigidbody.AddForce(power * Vector3.forward);
            }
        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Ball")){
            ballReady = true;
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Ball")){
            ballReady = false;
            power = 0f;
        }
    }
}
