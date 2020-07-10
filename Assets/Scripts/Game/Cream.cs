using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cream : EnemyController
{
    protected override void Start()
    {
        SetUp(1.2f, true);
        points = 20;
        this.tag = "Cream";
    }
}