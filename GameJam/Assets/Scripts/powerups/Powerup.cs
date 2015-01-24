﻿using System;
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
    public Attribute Attribute;
    public void ModifyPower(Actor actor)
    {
      switch(Attribute)
      {
        case Attribute.Damage:
          actor.Attack += Value;
          break;
        case Attribute.Health:
          actor.HP += Value;
          break;
      }
    }
  }
}
