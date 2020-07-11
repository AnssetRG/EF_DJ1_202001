using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : EnemyController
{
    protected override void Start()
    {
        SetUp(-0.75f, false);
        points = 10;
        this.tag = "Fly";
    }
}