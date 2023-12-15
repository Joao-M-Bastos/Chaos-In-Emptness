using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRb;
    public ParticleSystem bootsParticules;
    [SerializeField] float ascentVelocity;
    [SerializeField] float maxSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerVelocity = playerRb.velocity;        

        if (Input.GetKey(KeyCode.W))
        {
            bootsParticules.Play();
            playerVelocity += this.transform.up * (ascentVelocity / 100);
        }

        if (getSpeedFromVelocity(playerVelocity) > maxSpeed)
        {
            playerVelocity -= playerVelocity * (ascentVelocity / 50);
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            this.transform.Rotate(0,0, (-Input.GetAxis("Horizontal") * 2));
        }
        playerRb.velocity = playerVelocity;
    }

    private float getSpeedFromVelocity(Vector3 playerVelocity)
    {
        return Mathf.Abs(playerVelocity.x) + Mathf.Abs(playerVelocity.y);
    }
}
