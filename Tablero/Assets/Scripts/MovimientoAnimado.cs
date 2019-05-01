using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAnimado : MonoBehaviour
{
    float speed = 1;
    float rotSpeed = 80;
    float rot = 0f;
    float gravity = 0;

    Vector3 velocidad;
    float tiempo = 1f;

    Vector3 targetPos;
    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        targetPos = controller.transform.position;
        anim.SetInteger("cond", 0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position);
        Debug.Log(targetPos);
        if (controller.isGrounded)
        {
            if (transform.position != targetPos)
            {
                var cc = GetComponent<CharacterController>();
                var offset = targetPos - transform.position;
                //Get the difference.
                if (offset.magnitude > .1f)
                {
                    //If we're further away than .1 unit, move towards the target.
                    //The minimum allowable tolerance varies with the speed of the object and the framerate. 
                    // 2 * tolerance must be >= moveSpeed / framerate or the object will jump right over the stop.
                    offset = offset.normalized * speed;
                    //normalize it and account for movement speed.
                    cc.Move(offset * Time.deltaTime);
                    //actually move the character.
                }
            }
            if(transform.position == targetPos){
                
                anim.SetInteger("cond", 0);
            }
        }


        /*if (controller.isGrounded)
        {
            if (controller.transform.position != targetPos)
            {
                anim.SetInteger("cond", 1);

                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
                moveDir = transform.TransformDirection(moveDir);
                //transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocidad, tiempo);
            }
            else
            {
                anim.SetInteger("cond", 0);
            }
        }
        */
        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
        
    }

    public void setTargetPos(Vector3 pos)
    {
        //Debug.Log("caca");
        targetPos = pos;
        velocidad = Vector3.zero;
    }

    public void MoveTowardsTarget(Vector3 target)
    {
        targetPos = target;
        anim.SetInteger("cond", 1);

    }
}
