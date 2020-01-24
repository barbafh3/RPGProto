using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public Rigidbody2D rb;

  public Animator animator;

  public float speed = 2.0f;

  float horizontal, vertical = 0f;

  public bool bowEquipped = false;

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.F))
    {
      if (bowEquipped)
      {
        animator.SetTrigger("BowAttack");
      }
      else
      {
        animator.SetTrigger("Attack");
      }
    }
  }

  void FixedUpdate()
  {
    horizontal = Input.GetAxisRaw("Horizontal");
    vertical = Input.GetAxisRaw("Vertical");

    Move(horizontal, vertical);

    SetAnimatorVariables(horizontal, vertical);

    Flip(horizontal);
  }

  private void SetAnimatorVariables(float horizontal, float vertical)
  {
    if (horizontal != 0 || vertical != 0)
    {
      animator.SetFloat("Horizontal", Mathf.Abs(horizontal));
      animator.SetFloat("Vertical", vertical);
      animator.SetFloat("Speed", 1.0f);
    }
    else
    {
      animator.SetFloat("Speed", 0.0f);
    }
  }

  void Flip(float horizontal)
  {
    if (horizontal > 0)
    {
      transform.localScale = new Vector3(1f, 1f, 0f);
    }
    else if (horizontal < 0)
    {
      transform.localScale = new Vector3(-1f, 1f, 0f);
    }
  }

  void Move(float horizontal, float vertical)
  {
    var force = new Vector2(horizontal, vertical);
    rb.velocity = force * speed;
  }

}
