﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camscript : MonoBehaviour{
private Transform who;
public Transform[] Players;
public int height = 20;
Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        who = Players[PlayerPrefs.GetInt("selected_hero")];
    }

    // Update is called once per frame
    void Update()
    {
        position = who.position;
        position.z = 30;
        position.x = 30;
        position.y = position.y + height;
        transform.position = Vector3.Lerp (transform.position, position, 1f * Time.deltaTime );
        
    }
}