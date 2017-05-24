using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Spawner : MonoBehaviour {

    public float interval;
    public Primitive[] primitves;

    public Vector2 spawnRange;

    public IEnumerator SpawnCor() {
        while (true) {
            yield return new WaitForSeconds(interval);

            var prefab = PickPrimitive();
            var position = PickPositon();

            var sp = Instantiate(prefab, position, Random.rotation);
            NetworkServer.Spawn(sp.gameObject);

        }
    }

    public Primitive PickPrimitive() {
        int index = Random.Range(0, primitves.Length);

        return primitves[index];
    }

    public Vector3 PickPositon() {
        var positionX = Random.Range(-spawnRange.x, spawnRange.x);
        var positionY = Random.Range(-spawnRange.y, spawnRange.y);

        //Vector3 offset = new Vector3(positionX, positionY);

        return transform.position + new Vector3(positionX, 0f, positionY);

    }

    // Use this for initialization
    void Start() {
        if (NetworkServer.active)
            StartCoroutine(SpawnCor());

    }
}
