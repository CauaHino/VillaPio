using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueFly : Enemy
{
    public void OnAnimatorHitFinished()
    {
        animator.SetTrigger("Death");
        Destroy(gameObject, 0.25f); 
    }
}
