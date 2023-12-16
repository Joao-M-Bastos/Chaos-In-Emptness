using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerRotation : MonoBehaviour
{
    Transform playerRotaion;
    // Start is called before the first frame update
    void Start()
    {
        playerRotaion = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = playerRotaion.position + playerRotaion.up*5;
        Debug.Log(playerRotaion);
    }
}
