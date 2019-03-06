using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringBehaviour : MonoBehaviour
{
    public float K = 10;
    float g = 9.81f;
    public float m = 2;
    public Rigidbody rb;
    
    float Y0;

    public float smoothTime = 1f;
    private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start ()
    {
        //Orginella jämviktsläge
        Y0 = transform.position.y;
        rb = GetComponent<Rigidbody>();
	}
	
	// Använder FixedUpdate istället för Update för att göra det mera "smooth"
	void FixedUpdate ()
    {
        //Nya jämviktsläge
        float Yj = Y0 - ((m * g) / K);

        float DeltaY = Yj - transform.position.y;
        float Ff = K * DeltaY;
        float Fg = -(m * g);

        float a = (Ff + Fg) / m;
        a /= 30;

        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + a, rb.velocity.z);
		
		
        float deltaTime = Time.deltaTime;
        transform.position = Vector3.SmoothDamp(transform.position, rb.velocity, ref velocity, smoothTime, deltaTime);
	}
}
