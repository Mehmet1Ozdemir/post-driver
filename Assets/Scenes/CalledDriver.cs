using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalledDriver : MonoBehaviour
{

    [SerializeField] float steerSpeed = 300; //Dönüş haraketi
    [SerializeField] float moveSpeed = 20; //İleri Geri Hareketi
    [SerializeField] float slowSpeed = 15;
    [SerializeField] float boostSpeed = 30;

    // Program ilk çalıştığında direk çalışan kodlar
    void Start()
    {
        
    }

    // Program çalıştığı sürece sürekli çalışması gereken kodlar 
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
    }
    
    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }

    }

}
