using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.powerups
{
  public enum ActorAttribute { Health, Damage }

  public class Powerup
  {
    public int Value;
    public ActorAttribute Attribute;
    public void ModifyPower(Actor actor)
    {
      switch (Attribute)
      {
        case ActorAttribute.Damage:
          actor.Attack += Value;
          break;
        case ActorAttribute.Health:
          actor.HP += Value;
          break;
      }
    }
  }
}
