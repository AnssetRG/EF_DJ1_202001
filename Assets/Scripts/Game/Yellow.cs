using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : EnemyController
{
    protected override void Start()
    {
        SetUp(-0.9f, false);
        points = 15;
        this.tag = "Yellow";
    }
}