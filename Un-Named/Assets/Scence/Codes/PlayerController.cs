using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    public float MoveSpeed = 5f;

    public float collisionOffset = 0.02f;
    public Rigidbody2D rb;

    public ContactFilter2D MovementFilter;
    Vector2 MovementInput;

    private bool isMoving;
    private Animator animator;
    public bool isFacingRight=true;
    List<RaycastHit2D> castCollision = new List<RaycastHit2D>();


    private void Awake() {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue MovementValue){
        MovementInput = MovementValue.Get<Vector2>();
    }

    private void FixedUpdate(){
        // Movemnent
        if (MovementInput != Vector2.zero){
            int count = rb.Cast(MovementInput,MovementFilter,castCollision,MoveSpeed * Time.deltaTime + collisionOffset);
            if (count == 0){
                rb.MovePosition(rb.position + MoveSpeed * Time.deltaTime * MovementInput);
            }
        }

        if(!isMoving) {
            MovementInput.x = Input.GetAxisRaw("Horizontal");
            MovementInput.y = Input.GetAxisRaw("Vertical");
            if(isFacingRight == true && MovementInput.x == -1) {
                transform.localScale = new Vector3(-2,2,0);
                isFacingRight=false;
            }
            if(isFacingRight == false && MovementInput.x == 1) {
                transform.localScale = new Vector3(2,2,0);
                isFacingRight = true;
            }

        if(MovementInput.x != 0) MovementInput.y = 0;

        animator.SetBool("isMoving",isMoving);
        // attack
        if(Input.GetMouseButtonDown(0)) {
            animator.SetTrigger("attack");
        }
    }    
}


}