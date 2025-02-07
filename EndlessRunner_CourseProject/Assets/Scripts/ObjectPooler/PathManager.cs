﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class PathManager : MonoBehaviour {
    private Transform playerTransofrm;
    private float spawnX = -10.0f;
    private float pathLenght = 10.0f;
    private int amnPathsOnScreen = 9;
    private List<GameObject> activePaths;

    void Start() {
        activePaths = new List<GameObject>();
        playerTransofrm = GameObject.FindGameObjectWithTag(GameObjectsTags.PlayerTag).transform;

        for (int i = 0; i < amnPathsOnScreen; i++) {
            SpawnPath();
        }
    }

    void Update() {

        if (playerTransofrm != null) {
            if (playerTransofrm.position.x - Constants.SAFE_ZONE > (spawnX - amnPathsOnScreen * pathLenght)) {
                SpawnPath();
                DeletePath();
            }
        }
    }

    private void SpawnPath() {
        GameObject go;
        go = ObjectPooler.SharedInstance.GetPooledCleanPath();
        if (go != null) {
            go.SetActive(true);
            go.transform.SetParent(transform);
            go.transform.position = new Vector3(1, 0, 0) * spawnX;
            spawnX += pathLenght;
            activePaths.Add(go);
        }
    }
    private void DeletePath() {
        activePaths[0].SetActive(false);
        activePaths.RemoveAt(0);
    }

}
