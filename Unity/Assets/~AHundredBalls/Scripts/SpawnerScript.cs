﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public GameObject[] prefabs = null;
    public float spawnRadius = 5.0f;
    public float spawnRate = 1.0f;
    private float spawnFactor = 0.0f;
    public Renderer rend;

    public Material red, blue, green;

    void Start()
    {
        
    }
    void Update()
    {
        HandleSpawn();

    }

    void HandleSpawn()
    {
        spawnFactor += Time.deltaTime;

        if(spawnFactor > spawnRate)
        {
            int randomIndex = Random.Range(0, prefabs.Length);
            Spawn(prefabs[randomIndex]);
            spawnFactor = 0;
        }
    }

    void Spawn(GameObject _object)
    {
        GameObject newObject = Instantiate(_object);
        rend = newObject.GetComponent<Renderer>();

        rend.material.SetColor("Red", Color.red);

        Vector3 randomPoint = Random.insideUnitCircle * spawnRadius;
        newObject.transform.position = transform.position + randomPoint;
    }
}
