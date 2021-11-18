using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
   [SerializeField] private float speed;
   private Rigidbody2D body;
   private Animator anim;
   private bool grounded;

   private void Awake(){

       body = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();

   }

   private void Update(){

      float HorizontalInput = Input.GetAxis("Horizontal");
       body.velocity = new Vector2(HorizontalInput * speed, body.velocity.y);


//obrne karakterja levo-desno
      if(HorizontalInput > 0.01f)
         transform.localScale = Vector3.one;
      else if (HorizontalInput < -0.01f)
      transform.localScale = new Vector3(-1, 1, 1);


      if (Input.GetKey(KeyCode.Space) && grounded)
      Jump();

   anim.SetBool("run", HorizontalInput != 0);
   anim.SetBool("grounded", grounded);

   }

   private void Jump()
    {
       body.velocity = new Vector2(body.velocity.x, speed);
       anim.SetTrigger("jump");
       grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if(collision.gameObject.tag == "Ground")
        grounded = true; 
    }
}
