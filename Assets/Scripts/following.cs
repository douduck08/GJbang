using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class following : MonoBehaviour
{
    public GameObject move, target;
    private float MoveRotataionSpeed = 50f;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }



    void FixedUpdate()
    {
        Quaternion MoveRotation = Quaternion.LookRotation(target.transform.position - move.transform.position, Vector3.up);//視差向量
        move.transform.rotation = Quaternion.Slerp(move.transform.rotation, MoveRotation, Time.deltaTime * MoveRotataionSpeed);//轉向視差向量
        rb.AddForce(transform.forward * MoveRotataionSpeed * Time.deltaTime);
    }


}