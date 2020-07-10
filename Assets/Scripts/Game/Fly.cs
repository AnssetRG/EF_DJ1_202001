using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : EnemyController
{
    protected override void Start()
    {
        SetUp(0, false);
        points = 50;
        this.tag = "Fly";
    }
}