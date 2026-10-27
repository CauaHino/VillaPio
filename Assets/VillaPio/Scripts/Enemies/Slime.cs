using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slime : Enemy
{
   protected override void Start()
   {
      vida = 3;
      base.Start();
   }
}
