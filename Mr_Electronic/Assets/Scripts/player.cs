using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float thrust = 12f;
    public float timeLeft = 4f;
    public Slider electricity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*thrust, 0, Input.GetAxis("Vertical")*Time.deltaTime*thrust);
        
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "insulator"){
            timeLeft -= Time.deltaTime;
                if (timeLeft < .5f){
                    timeLeft = 4f;
                    if (thrust <= 2f){
                        thrust = 2f;
                        electricity.value = thrust;
                    }
                    else{
                        thrust -= 2;
                        electricity.value = thrust;
                    }
                }
        }

        if (other.tag == "conductor"){
            timeLeft -= Time.deltaTime;
                if (timeLeft < 0){
                    timeLeft = 4f;
                    if (thrust >= 22){
                        thrust = 22;
                        electricity.value = thrust;
                    }
                    else{
                        thrust += 2;
                        electricity.value = thrust;
                    }
                }
        }
    }
}
