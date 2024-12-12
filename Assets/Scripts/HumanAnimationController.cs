using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class HumanAnimationController : MonoBehaviour
{
    private Animator animator;
    private bool isWalking = false, shoved = false, wave = false;
    private float walkDistance = 0.7f; // Distance to walk before turning around
    private float currentWalkDistance = 0f;
    private Vector3 walkDirection;
    private bool isTurning = false;

    public float turnSpeed = 5f;

    public Transform cameraTransform; // Reference to the camera
    public float rotationSpeed = 5f;  // Speed of character rotation
    void Start()
    {
        animator = GetComponent<Animator>();
        walkDirection = transform.forward;
        Debug.Log("forward " + transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        //substitute Input.GetMouseButtonDown(0) to input.getTouch(0)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            toggleWalk();
        }

        if (isWalking) WalkAndTurn();


        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     wave = !wave;
        //     Vector3 directionToCamera = cameraTransform.position - transform.position;
        //     directionToCamera.y = 0; // Ignore vertical rotation
        //     Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
        //     transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        //     animator.SetBool("wave", wave);
        // }

        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     shoved = !shoved;
        //     animator.SetBool("shoved", shoved);
        // }

        //Debug.Log("Current Animation: " + GetAnimationName(animator.GetCurrentAnimatorStateInfo(0).shortNameHash));
    }

    public void PlayAnimation()
    {

        Debug.Log("Current Animation: " + GetAnimationName(animator.GetCurrentAnimatorStateInfo(0).shortNameHash));
    }

    private void toggleWalk()
    {
        isWalking = !isWalking;
        animator.SetBool("isWalking", isWalking);
    }

    private void toggleWave()
    {
        wave = !wave;
        animator.SetBool("wave", wave);
    }

    private void WalkAndTurn()
    {

        //transform.Translate(walkDirection * Time.deltaTime, Space.World);
        currentWalkDistance += Time.deltaTime;
        Debug.Log("walking... " + currentWalkDistance);

        // Check if the character has walked the specified distance
        if (currentWalkDistance >= walkDistance)
        {
            Debug.Log("distance reached and reset !!" + transform.forward);
            // Trigger the turn and reset walk distance
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            //walkDirection = -walkDirection;
            toggleWalk();

            //StartCoroutine(TurnAround());
            currentWalkDistance = 0f;
        }
    }

    private IEnumerator TurnAround()
    {
        // Trigger the turn animation (optional) or handle turn with smooth rotation
        float turnTime = 0f;

        // Rotate the character to face the opposite direction smoothly
        while (turnTime < 1f)
        {
            Debug.Log("turning...");
            turnTime += Time.deltaTime * turnSpeed;
            transform.rotation = Quaternion.Euler(0, Mathf.Lerp(0f, 180f, turnTime), 0);
            yield return null;
        }
        // After turning, reverse the walk direction to continue in the opposite direction
        //walkDirection = -walkDirection;
        Debug.Log("walk direction: " + transform.forward);
        toggleWalk();

        // Continue walking after turning
        //animator.SetBool("isWalking", true);
    }

    private string GetAnimationName(int stateHash)
    {
        foreach (AnimationClip clip in animator.runtimeAnimatorController.animationClips)
        {
            if (Animator.StringToHash(clip.name) == stateHash)
            {
                return clip.name;
            }
        }
        return "Unknown Animation";
    }

    // if (Input.touchCount > 0)
    // {
    //     Touch touch = Input.GetTouch(0);
    //     Debug.Log("Toque detectado: " + touch.position);
    //     if (touch.phase == TouchPhase.Began)
    //     {
    //         animator.SetBool("isWalking", true);
    //         Debug.Log("Toque detectado: Iniciando caminar");
    //     }
    //     if (touch.phase == TouchPhase.Ended)
    //     {
    //         animator.SetBool("isWalking", false);
    //         Debug.Log("Toque finalizado: Deteniendo caminar");
    //     }
    // }


}
