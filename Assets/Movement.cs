using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Animator anim;

    [SerializeField] float speed;
    float horizontal;
    bool facingRight;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (horizontal !=0)
        {
            anim.SetBool("Run", true);
        }
        else { anim.SetBool("Run", false); }

        if (horizontal < 0 && !facingRight)
        {
            Flip();
        }
        else if (horizontal > 0 && facingRight)
        {
            Flip();
        }

    }

    private void FixedUpdate()
    {
        transform.Translate(new Vector2(horizontal, 0) * Time.fixedDeltaTime);
    }

    void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
