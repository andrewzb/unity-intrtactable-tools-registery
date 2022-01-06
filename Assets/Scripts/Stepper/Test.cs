using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    [SerializeField] private Animator animator;


    private void Update() {
        var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("ExitIdle")) {
            Debug.Log(true);
        }
        else {
            Debug.Log(false);
        }
    }

    [ContextMenu("play")]
    private void Play() {
        animator.SetTrigger("Play");
    }

    [ContextMenu("reset")]
    private void ResetClip() {
        animator.SetTrigger("Reset");
    }
}
