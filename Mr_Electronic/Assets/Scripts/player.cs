using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float thrust = 12f;
    public float timeLeft = 4f;
    public Slider electricity;
    public GameObject slider;

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
                if (timeLeft < 0f){
                    timeLeft = 4f;
                    if (thrust == 4f){
                        thrust -= 2f;
                        electricity.value = thrust;
                        //possible animation letting player know they only have one tick left
                        slider.GetComponent<Animator>().SetTrigger("danger");
                        Debug.Log("fuck");
                    }
                    else{
                        thrust -= 2f;
                        electricity.value = thrust;
                    }
                    if (thrust <= 0f){
                        SceneManager.LoadScene(0);
                    }
                }
        }

        if (other.tag == "conductor"){
            timeLeft -= Time.deltaTime;
                if (timeLeft < 0f){
                    timeLeft = 4f;
                    if (thrust == 20f){
                        thrust += 2f;
                        electricity.value = thrust;
                        //possible animation letting player know they only have one tick left
                        slider.GetComponent<Animator>().SetTrigger("danger");
                    }
                    else{
                        thrust += 2f;
                        electricity.value = thrust;
                    }
                    if (thrust >= 24f){
                        SceneManager.LoadScene(0);
                    }
                }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "insulator"){
            timeLeft = 4f;
        }

        if (other.tag == "conductor"){
            timeLeft = 4f;
        }

    }
}
