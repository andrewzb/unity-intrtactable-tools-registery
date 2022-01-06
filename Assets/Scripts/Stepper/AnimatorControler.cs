using System;
using UnityEngine;
public class AnimatorControler : MonoBehaviour {
    [SerializeField] private Animator animator;
    [SerializeField] [Range(0.1f, 2)] private float speed;

    public Action OnAnimationFinishAction;

    private bool isPlaying;

    public void SetAnimationClip(RuntimeAnimatorController controler) {
        animator.runtimeAnimatorController = controler;
    }

    public void Play() {
        if (!isPlaying) {
            animator.speed = speed;
            animator.SetTrigger("Play");
            isPlaying = true;
        }
    }

    public void FixedUpdate() {
        if (isPlaying) {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("ExitIdle")) {
                isPlaying = false;
                OnAnimationFinishAction?.Invoke();
            }
        }
    }
}
