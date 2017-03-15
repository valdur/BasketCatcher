using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour {

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

        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        vertical *= speed;
        horizontal *= speed;

        transform.Translate(new Vector3(horizontal, 0F, vertical));

        var pos = transform.position;

        var r = movementRange;
        transform.position = new Vector3(Mathf.Clamp(pos.x, -r.x, r.x), pos.y, Mathf.Clamp(pos.z, -r.y, r.y));
    }

    private void OnTriggerEnter(Collider other) {
        var prim = other.GetComponent<Primitive>();
        if (prim != null) {
            scoreManager.AddPoints(prim.points);

            var fx = Instantiate(fxPrefab, other.transform.position, Quaternion.Euler(-90,0,0));
            Destroy(fx, 2f);
            Destroy(other.gameObject);
        }
    }

}
