﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrensTestMovement : MonoBehaviourPun
{
    #region inputVars

    bool rightHeld = false;
    bool leftHeld = false;
    bool upHeld = false;
    bool downHeld = false;
    float dashTime = 0;

    #endregion

    #region internal references
    Rigidbody rb = null;
    #endregion

    float leftVal, rightVal, upVal, downVal = 0.0f;

    public float speed = 3.0f;

    #region Unity Callbacks
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }

        rightHeld = Input.GetKey(KeyCode.D) ? true : false;
        leftHeld = Input.GetKey(KeyCode.A) ? true : false;
        upHeld = Input.GetKey(KeyCode.W) ? true : false;
        downHeld = Input.GetKey(KeyCode.S) ? true : false;
        if(Input.GetKeyDown(KeyCode.LeftShift)) dashTime = .5f;
    }

    private void FixedUpdate()
    {
        leftVal = leftHeld ? 1.0f : 0.0f;
        rightVal = rightHeld ? 1.0f : 0.0f;
        upVal = upHeld ? 1.0f : 0.0f;
        downVal = downHeld ? 1.0f : 0.0f;

        float zVal = upVal - downVal;
        float xVal = rightVal - leftVal;

        if(dashTime > 0)
        {
            rb.velocity = new Vector3(xVal, 0, zVal) * speed * 3.0f;
            dashTime -= Time.deltaTime;
        }
        else rb.velocity = new Vector3(xVal, 0, zVal) * speed;
    }
    #endregion

}
