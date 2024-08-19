using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLCMenuItem : MonoBehaviour {
    [SerializeField]
    private GameObject insufficientFundsPrefab;
    [SerializeField] 
    private float spawnChaosRange;
    [SerializeField]
    GameObject brokePool;

    public void GenerateText() {
        Vector2 pos = transform.position;
        Vector2 textPos = new Vector2(pos.x + spawnChaosRange * (UnityEngine.Random.value - 0.5f),
					                  pos.y + spawnChaosRange * (UnityEngine.Random.value - 0.5f));
        GameObject go = Instantiate(insufficientFundsPrefab, textPos, Quaternion.identity);
        go.transform.SetParent(brokePool.transform);
    }
}
