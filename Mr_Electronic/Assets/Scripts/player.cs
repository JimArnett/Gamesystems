using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float thrust = 10f;
    public float timeLeft = 8f;

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
                    timeLeft = 8f;
                    if (thrust <= .5f){
                        thrust = .5f;
                    }
                    else{
                        thrust -= 2;
                    }
                }
        }

        if (other.tag == "conductor"){
            timeLeft -= Time.deltaTime;
                if (timeLeft < 0){
                    timeLeft = 8f;
                    if (thrust >= 30){
                        thrust = 30;
                    }
                    else{
                        thrust += 2;
                    }
                }
        }
    }
}
