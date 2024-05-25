using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed=5f;
    private bool isMoving;
    private Vector2 input;
    private Animator animator;
    public bool isFacingRight=true;
    private void Awake() {
        animator=GetComponent<Animator>();
    }
    private void Update() {
        //move keyboard
        if(!isMoving) {
            input.x=Input.GetAxisRaw("Horizontal");
            input.y=Input.GetAxisRaw("Vertical");
            if(isFacingRight==true && input.x==-1) {
                transform.localScale=new Vector3(-2,2,0);
                isFacingRight=false;
            }
            if(isFacingRight==false && input.x==1) {
                transform.localScale=new Vector3(2,2,0);
                isFacingRight=true;
            }

            if(input.x!=0) input.y=0;

            if(input!= Vector2.zero) {
                animator.SetFloat("moveX",input.x);
                animator.SetFloat("moveY",input.y);

                var targetPos = transform.position;
                targetPos.x+=input.x;
                targetPos.y+=input.y;

                StartCoroutine(Move(targetPos));
            }
        }
        animator.SetBool("isMoving",isMoving);
        // attack
        if(Input.GetMouseButtonDown(0)) {
            animator.SetTrigger("attack");
        }
    }
    IEnumerator Move(Vector3 targetPos) {
        isMoving=true;
        while((targetPos-transform.position).sqrMagnitude > Mathf.Epsilon) {
            transform.position=Vector3.MoveTowards(transform.position,targetPos,moveSpeed*Time.deltaTime);
            yield return null; 
        }
        transform.position=targetPos;
        isMoving=false;
    }
}
