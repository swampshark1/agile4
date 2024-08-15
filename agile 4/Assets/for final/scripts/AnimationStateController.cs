using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash); // Use isWalkingHash without quotes
        bool forwardPressed = Input.GetKey(KeyCode.W);

        // if player presses the "W" key
        if (!isWalking && forwardPressed)
        {
            // then set the isWalking to be true
            animator.SetBool(isWalkingHash, true); // Use isWalkingHash without quotes
        }

        // if player is not pressing the "W" key
        if (isWalking && !forwardPressed)
        {
            // set the isWalking to be false
            animator.SetBool(isWalkingHash, false); // Use isWalkingHash without quotes
        }
    }
}
