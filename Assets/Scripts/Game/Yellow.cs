using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : EnemyController
{
    protected override void Start()
    {
        SetUp(-0.75f, false);
        points = 15;
        this.tag = "Yellow";
    }
}