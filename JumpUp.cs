using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpUp : MonoBehaviour {

    public Rigidbody rigid;
    public float force;
    public FacialExpressions facialExp;
    public float max_dist;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        facialExp = GetComponent<FacialExpressions>();

	}
	
	// Update is called once per frame
	void Update () {

        if (facialExp.joy == true)
        {
            Ray ray = new Ray(transform.position, -transform.up);
            if (Physics.Raycast(transform.position, -transform.up, max_dist)){
                rigid.AddForce(Vector3.up * force, ForceMode.Force);
            }

        }
        

    }
}
