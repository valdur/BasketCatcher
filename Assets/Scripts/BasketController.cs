using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour {

    public float speed;
    public Vector2 movementRange;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        vertical *= speed;
        horizontal *= speed;

        transform.Translate(new Vector3(horizontal,0F,vertical));

        var pos = transform.position;

        //if (pos.x <= -movementRange.x) {
        //    pos.x = -movementRange.x;
        //} else if(pos.x >= movementRange.x) {
        //    pos.x = movementRange.x;
        //}

        //if (pos.z >= movementRange.y) {
        //    pos.z = movementRange.y;
        //} else if (pos.z <= -movementRange.y) {
        //    pos.z = -movementRange.y;
        //}

        var r = movementRange;
        transform.position = new Vector3(Mathf.Clamp(pos.x, -r.x, r.x), pos.y, Mathf.Clamp(pos.z, -r.y, r.y));

        //transform.position = pos;

        

    }
}
