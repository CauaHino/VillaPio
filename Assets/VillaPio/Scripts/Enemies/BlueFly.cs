using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueFly : Enemy
{
    protected override void Start()
    {
        vida = 2;
        base.Start();
    }
}
