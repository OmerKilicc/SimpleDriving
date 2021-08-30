using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Car : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float speedChange = 2f;
    [SerializeField] private float steerAmount = 200f;

    private int steerDirection;
    // Start is called before the first frame update}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = speed + speedChange * Time.deltaTime;
        
        transform.Rotate(0f,steerDirection * steerAmount * Time.deltaTime,0f);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("Collided");
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void Steer(int value)
    {
        steerDirection = value;
    }
}
