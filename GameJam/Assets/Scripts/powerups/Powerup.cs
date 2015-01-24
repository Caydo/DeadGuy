using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.powerups
{
  public enum Attribute { Health, Damage}

  [Serializable]
  public class Powerup
  {
    public int Value;
    public void ModifyPower(Actor actor)
    {

    }
  }
}
