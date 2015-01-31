#region Using Statements
using System;
using WaveEngine.Common.Math;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Resources;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.Physics2D;
#endregion

namespace SuperblocksProject
{
  public class Bonus
  {
    private Entity entity;
    private int id;

    public Bonus(int id, float x, float y)
    {
      this.id = id;
      this.entity = new Entity("Bonus" + id)
        .AddComponent(new Transform2D() { X = x - 20f, Y = y - 130f })
        .AddComponent(new Sprite("textures/bonusHeart.wpk"))
        .AddComponent(new CircleCollider())
        .AddComponent(new RigidBody2D() {
          PhysicBodyType = PhysicBodyType.Dynamic,
          IgnoreGravity = true,
          Damping = 0,
          Restitution = 1.0f,
          Friction = 0.0f,
          FixedRotation = true
        })
        .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
        .AddComponent(new BonusBehaviour());
    }

    public string Name { get { return "Bonus" + id; } }
    public Entity Entity { get { return entity; } }
  }
}

