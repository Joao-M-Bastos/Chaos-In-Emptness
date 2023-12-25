using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRb;
    public ParticleSystem bootsParticules;
    [SerializeField] float baseAscentVelocity;
    [SerializeField] float maxSpeed;

    float ascentVelocity;

    // Start is called before the first frame update
    void Start()
    {
        ascentVelocity = baseAscentVelocity;
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

    public void TakeKnockback(Vector3 knockbackDirection, float knockbackPower)
    {
        Debug.Log(knockbackDirection + "" + knockbackPower);
        this.playerRb.AddForce(knockbackDirection * (knockbackPower), ForceMode.Impulse);
    }

    public void ApplyEffect(float _speed)
    {
        ascentVelocity += baseAscentVelocity * (_speed / 100);
    }

    public void ClearEffect(float _speed)
    {
        ascentVelocity -= baseAscentVelocity * (_speed / 100);
    }
}
