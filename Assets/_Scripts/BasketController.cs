using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BasketController : NetworkBehaviour {

    public float speed;
    public Vector2 movementRange;
    ScoreManager scoreManager;
    public ParticleSystem fxPrefab;

    // Use this for initialization
    void Awake() {
        scoreManager = FindObjectOfType<ScoreManager>();

    }

    // Update is called once per frame
    void Update() {
        if (isLocalPlayer) {
            var vertical = Input.GetAxis("Vertical");
            var horizontal = Input.GetAxis("Horizontal");

            vertical *= speed;
            horizontal *= speed;

            transform.Translate(new Vector3(horizontal, 0F, vertical));

            var pos = transform.position;

            var r = movementRange;
            transform.position = new Vector3(Mathf.Clamp(pos.x, -r.x, r.x), pos.y, Mathf.Clamp(pos.z, -r.y, r.y));
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (isServer) {
            var prim = other.GetComponent<Primitive>();
            if (prim != null) {
                scoreManager.AddPoints(prim.points);
                prim.Fireworks();
            }
        }
    }

}
