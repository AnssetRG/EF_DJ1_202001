using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brown : EnemyController
{
    protected override void Start()
    {
        SetUp(-1.2f, true);
        points = 5;
        this.tag = "Brown";
    }
}