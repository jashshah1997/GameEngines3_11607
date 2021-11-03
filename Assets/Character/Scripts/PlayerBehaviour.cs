using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 1.0f;
    private static float x_pos = 4;
    private static float y_pos = 0;
    private static bool firstRun = true;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        if (!firstRun)
            gameObject.transform.position = new Vector3(x_pos, y_pos, 0);
        firstRun = false;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        animator.ResetTrigger("FrontTrigger");
        animator.ResetTrigger("BackTrigger");
        animator.ResetTrigger("LeftTrigger");
        animator.ResetTrigger("RightTrigger");
        animator.ResetTrigger("IdleTrigger");

        if (inputX > 0)
        {
            animator.SetTrigger("RightTrigger");
        }
        else if (inputX < -0)
        {
            animator.SetTrigger("LeftTrigger");
        }
        else if (inputY > 0)
        {
            animator.SetTrigger("BackTrigger");
        }
        else if (inputY < -0)
        {
            animator.SetTrigger("FrontTrigger");
        }
        else
        {
            animator.SetTrigger("IdleTrigger");
        }

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector3(inputX * moveSpeed, inputY * moveSpeed, 0);
        x_pos = gameObject.transform.position.x;
        y_pos = gameObject.transform.position.y;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Bush")
        {
            if (Random.Range(0, 250) < 2)
            {
                SceneManager.LoadScene("FightScene");
            }
        }
    }
}
