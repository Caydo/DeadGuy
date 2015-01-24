using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.powerups
{
  public abstract class Powerup:MonoBehaviour
  {
    public abstract void ModifyPower(Actor actor);
  }
}
