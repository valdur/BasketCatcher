using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Floor : MonoBehaviour {

    ScoreManager scm;

    private void Start() {
        scm = FindObjectOfType<ScoreManager>();
    }

    void OnCollisionEnter(Collision col) {
        if (NetworkServer.active) {
            var prim = col.transform.GetComponent<Primitive>();
            if (prim) {
                prim.Explode();
                scm.LoseLife();
            }
        }
    }
}
