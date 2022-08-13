using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationState : MonoBehaviour
{
    public HUD Hud;
    
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    int isJumpingHash;
    
    // Start is called before the first frame update
    void Start()
    {
     
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
        isRunningHash = Animator.StringToHash("isJumping");

    }

    // Update is called once per frame
    void Update()
    {
        

        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isJumping = animator.GetBool(isJumpingHash);

        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool JumpPressed = Input.GetKeyDown(KeyCode.Space);

        if (!isWalking && forwardPressed)
        {
            animator.SetBool(isWalkingHash, true);
            Debug.Log(animator);
        }

        if (isWalking && !forwardPressed)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if (!isRunning && (forwardPressed && runPressed))
        {
            animator.SetBool(isRunningHash, true);
        }
        if (isRunning && (!forwardPressed || !runPressed))
        {
            animator.SetBool(isRunningHash, false);
        }

        if (JumpPressed)
        {
            animator.SetBool(isJumpingHash, true);
        }

        

        
    }
}
