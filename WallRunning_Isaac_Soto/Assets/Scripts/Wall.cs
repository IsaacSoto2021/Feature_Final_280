using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
/*
 * Isaac Soto
 * 4/17/2024
 * [ This script is for the player to collide and wall runn across the way]
 */

public class Wall : MonoBehaviour
{
    public float RunningPower;
    public float RunningTimer;
   

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Runtime());
            // Apply the forces variables to simulate wall running 
            Rigidbody playerRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRigidbody != null)
            {
                Vector3 wallNormal = transform.forward; 
                Vector3 wallRunDirection = Vector3.Cross(wallNormal, Vector3.up).normalized; 
                playerRigidbody.AddForce(wallRunDirection * RunningPower, ForceMode.Impulse);
            }
       
        }
    }
  
    IEnumerator Runtime()
    {
        yield return new WaitForSeconds(RunningTimer);

    }

}
