using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Primitive : NetworkBehaviour {

    public int points = 0;

    public GameObject explosionPrefab;
    public GameObject fireworksPrefab;

    public void Explode() {
        RpcExplode(transform.position);
    }

    [ClientRpc]
    public void RpcExplode(Vector3 position) {
        var ins = Instantiate(explosionPrefab, position, Quaternion.Euler(-90, 0, 0));
        Destroy(ins, 3f);
        Destroy(gameObject);
    }

    public void Fireworks() {
        RpcFireworks();
    }

    [ClientRpc]
    public void RpcFireworks() {
        var ins = Instantiate(fireworksPrefab, transform.position, Quaternion.Euler(-90, 0, 0));
        Destroy(ins, 3f);
        Destroy(gameObject);
    }
}
