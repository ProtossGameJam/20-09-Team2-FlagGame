﻿using System;
using Photon.Pun;
using UnityEngine;

public class PlayerAnimation : MonoBehaviourPun
{
    [SerializeField] private Animator animator;

    private IMoveInput moveInput;

    [SerializeField] private string velocityParameterName;

    private void Awake()
    {
        if (animator == null) {
            animator = GetComponent<Animator>();
        }
        
        moveInput = GetComponentInParent<PlayerInput>();
    }

    private void Update()
    {
        if (photonView.IsMine) {
            WalkAnimation();
        }
    }

    private void WalkAnimation()
    {
        animator.SetFloat(velocityParameterName, moveInput.MoveVector.magnitude);
    }
}