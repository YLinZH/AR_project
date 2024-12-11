using UnityEngine;

public class HumanAnimationController : MonoBehaviour
{
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Debug.Log("Toque detectado: " + touch.position);
            if (touch.phase == TouchPhase.Began)
            {
                animator.SetBool("isWalking", true);
                Debug.Log("Toque detectado: Iniciando caminar");


            }
            if (touch.phase == TouchPhase.Ended)
            {
                animator.SetBool("isWalking", false);
                Debug.Log("Toque finalizado: Deteniendo caminar");
            }
        }


    }
}
