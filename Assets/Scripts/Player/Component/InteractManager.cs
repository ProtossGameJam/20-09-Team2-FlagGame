﻿using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

// ReSharper disable InconsistentNaming
// ReSharper disable Unity.PerformanceCriticalCodeInvocation
// ReSharper disable InvertIf

public class InteractManager : MonoBehaviourPun
{
    [SerializeField] private float     checkRadius;
    [SerializeField] private LayerMask npcLayer;

    [ReadOnly] [SerializeField] private bool isInteracting;

    private void Update() {
        if (photonView.IsMine) TryInteractNPC(KeyCode.F);
    }

    private void TryInteractNPC(KeyCode key) { InputManager.InputAction(key, CheckNPCAvailable); }

    private void CheckNPCAvailable() {
        var castNpc = Physics2D.OverlapCircle(transform.position + Vector3.up, checkRadius, npcLayer);
        if (castNpc) StartInteract(castNpc.transform.GetComponents<InteractModule>());
    }

    private void StartInteract(IEnumerable<InteractModule> modules) {
        if (!isInteracting) {
            //isInteracting = true;
            foreach (var module in modules) {
                module.Interact();
            }
        }
    }

    public void EndInteract() { isInteracting = false; }
}