﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugHeadController : MonoBehaviour
{

    string playerFoot = "playerFoot";


    void Start()
    {
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        //playerFootに衝突したときの動作
        if (other.gameObject.tag.Equals(playerFoot)) PlayerController.CollisionSlug();

    }


}
