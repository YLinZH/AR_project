using UnityEngine;

public class HumanAnimationController : MonoBehaviour
{
    private Animator animator;
    private bool isWalking = false, wave = false;
    private Rect touchArea;

    void Start()
    {
        animator = GetComponent<Animator>();
        touchArea = new Rect(0, 0, Screen.width, Screen.height * 0.5f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) toggleWalk();

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (Input.GetTouch(0).phase == TouchPhase.Began && IsTouchWithinArea(touch.position)) toggleWave();
        }
    }

    public void toggleWalk()
    {
        isWalking = !isWalking;
        animator.SetBool("isWalking", isWalking);
    }

    public void toggleWave()
    {
        wave = !wave;
        animator.SetBool("wave", wave);
    }

    private bool IsTouchWithinArea(Vector2 touchPosition)
    {
        return touchArea.Contains(new Vector2(touchPosition.x, Screen.height - touchPosition.y));
    }
}
