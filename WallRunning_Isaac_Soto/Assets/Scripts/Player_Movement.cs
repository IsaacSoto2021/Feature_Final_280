using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
/*
 * Isaac Soto
 * 4/17/2024
 * [ This Script is for the player to move and jump  and look around the scene]
 */

public class Player_Movement : MonoBehaviour
{
    private Rigidbody Player;
    private PlayerMovement Move;
    public float speed = 0f;
    public float jumpForce = 5.0f;

    public float turnSpeed = 0f;
    private float turn;

    public Transform maincamera;

   public void Awake()
    {
        Player = this.GetComponent<Rigidbody>();

        Move = new PlayerMovement();

        Move.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Move.PlayerMove.Jump.started += _ => Jump();

        // WASD keybind movements
        Vector2 direction = Move.PlayerMove.Inputs.ReadValue<Vector2>();
       Player.transform.position += new Vector3 (direction.x, 0, direction.y) * speed * Time.deltaTime;

        CameraMove();


    }

    public void Jump()
    {
        Player.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void CameraMove()
    {
        float mouseRotation = Move.PlayerMove.Camera.ReadValue<float>();
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed, mouseRotation);
    }
}