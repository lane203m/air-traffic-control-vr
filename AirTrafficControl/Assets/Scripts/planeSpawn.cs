using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planeSpawn : MonoBehaviour
{
    public GameObject spawnPrefab;

    float starttime = 0f;

    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        GameObject newInstance = (GameObject)Instantiate(spawnPrefab, transform.position, Quaternion.identity);
        newInstance.transform.LookAt(Camera.main.transform);
        newInstance.tag = "Player";
    }
    void Despawn()
    {

    }
}

