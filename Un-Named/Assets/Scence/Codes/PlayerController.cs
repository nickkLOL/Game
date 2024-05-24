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

    List<RaycastHit2D> castCollision = new List<RaycastHit2D>();

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
    }
}
