using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour {

    public ParticleSystem fxPrefab;

    void OnCollisionEnter(Collision col) {
        var fx = Instantiate(fxPrefab, col.transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(fx, 1f);
        Destroy(col.gameObject);
    }
}
