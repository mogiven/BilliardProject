using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum FollowType
{
    SetPosition,
    Lerp,
    MoveTowards,
    MoveTowardsAndLerp,
    SmoothDamp,
    RigibodyAddForce,
    Translate
}

public class AutoFollow : MonoBehaviour
{
    public Transform targetTansform;
    public FollowType myFollowType;
    public float lerpSpeed = 5f;
    public float moveSpeed = 5f;
    public float dampSpeed = 100f;
    private Vector3 velocity = Vector3.zero;
    public float forceSpeed = 50;
    public float bullet_move_speed = 10F; 

    // void Start()
    // {
    //     targetTansform=this.transform.parent;
    //     myFollowType=FollowType.Translate;
    // }

    private void FixedUpdate()
    {

        if(global.is_hold==0){
            //Debug.Log("没有拿球杆");
            this.transform.position+= global.move_forward_direction * bullet_move_speed * Time.deltaTime;
            return;
        }

        switch (myFollowType)
        {
            case FollowType.SetPosition:
                Vector3 forward = targetTansform.TransformDirection(Vector3.forward) ;
                this.transform.position = targetTansform.position + forward*1F +new Vector3(0,-0.5F,0);
                this.transform.rotation=Quaternion.LookRotation( forward);
                break;
            case FollowType.Lerp:
                this.transform.position = Vector3.Lerp(this.transform.position,targetTansform.position, lerpSpeed * Time.fixedDeltaTime);
                break;
            case FollowType.MoveTowards:
                this.transform.position = Vector3.MoveTowards(this.transform.position,targetTansform.position, moveSpeed * Time.fixedDeltaTime);
                break;
            case FollowType.MoveTowardsAndLerp:
                this.transform.position = Vector3.MoveTowards(this.transform.position,Vector3.Lerp(this.transform.position,targetTansform.position, lerpSpeed * Time.fixedDeltaTime), moveSpeed * Time.fixedDeltaTime);
                break;
            case FollowType.SmoothDamp:
                this.transform.position = Vector3.SmoothDamp(this.transform.position,targetTansform.position, ref velocity,dampSpeed * Time.fixedDeltaTime);
                break;
            case FollowType.RigibodyAddForce:
                Vector3 force = targetTansform.position - transform.position;
                force = force.normalized;
                force = force * forceSpeed;
                transform.GetComponent<Rigidbody>().AddForce(force);
                break;
            case FollowType.Translate:
                Vector3 moveDirection = targetTansform.position - transform.position;
                transform.Translate(moveDirection,Space.World);
                break;
            
        }
    }
}


