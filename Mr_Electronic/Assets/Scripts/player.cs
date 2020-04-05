﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float thrust = 20f;
    public float timeLeft = 2f;
    public Slider electricity;
    public GameObject slider;
    public int insuItem;
    public int condItem;
    public Text insuText;
    public Text condText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*thrust, 0, Input.GetAxis("Vertical")*Time.deltaTime*thrust);

        if (Input.GetKeyDown(KeyCode.Q) && insuItem > 0){
            insuItem -= 1;
            insuText.text = "" + insuItem;
            if (thrust == 8f){
                thrust -= 4f;
                electricity.value = thrust;
                //possible animation letting player know they only have one tick left
                slider.GetComponent<Animator>().SetTrigger("danger");
            }
            else{
                thrust -= 4f;
                electricity.value = thrust;
            }
            if (thrust <= 0f){
                SceneManager.LoadScene(0);
            }
        }
        if (Input.GetKeyDown(KeyCode.E) && condItem > 0){
            condItem -= 1;
            condText.text = "" + condItem;
            if (thrust == 32f){
                thrust += 4f;
                electricity.value = thrust;
                //possible animation letting player know they only have one tick left
                slider.GetComponent<Animator>().SetTrigger("danger");
            }
            else{
                thrust += 4f;
                electricity.value = thrust;
            }
            if (thrust >= 40f){
                SceneManager.LoadScene(0);
            }
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag == "insulator"){
            timeLeft -= Time.deltaTime;
                if (timeLeft < 0f){
                    timeLeft = 2f;
                    if (thrust == 8f){
                        thrust -= 4f;
                        electricity.value = thrust;
                        //possible animation letting player know they only have one tick left
                        slider.GetComponent<Animator>().SetTrigger("danger");
                    }
                    else{
                        thrust -= 4f;
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
                    timeLeft = 2f;
                    if (thrust == 32f){
                        thrust += 4f;
                        electricity.value = thrust;
                        //possible animation letting player know they only have one tick left
                        slider.GetComponent<Animator>().SetTrigger("danger");
                    }
                    else{
                        thrust += 4f;
                        electricity.value = thrust;
                    }
                    if (thrust >= 40f){
                        SceneManager.LoadScene(0);
                    }
                }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "insulator"){
            timeLeft = 2f;
        }

        if (other.tag == "conductor"){
            timeLeft = 2f;
        }

    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "death"){
           SceneManager.LoadScene(0); 
        }

        if (other.tag == "goal"){
            SceneManager.LoadScene(1);
        }

        if (other.tag == "insulatorItem"){
            insuItem += 1;
            insuText.text = "" + insuItem;
            Destroy(other.gameObject);
        }

        if (other.tag == "conductorItem"){
            condItem += 1;
            condText.text = "" + condItem;
            Destroy(other.gameObject);
        }
    }
}
