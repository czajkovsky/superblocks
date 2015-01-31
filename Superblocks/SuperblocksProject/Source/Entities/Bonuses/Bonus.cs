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
  public abstract class Bonus
  {
    protected Entity entity;
    protected int id;

    public Bonus(int id, float x, float y, string texture)
    {
      this.id = id;
      this.entity = new Entity("Bonus" + id)
        .AddComponent(new Transform2D() { X = x - 20f, Y = y - 130f })
        .AddComponent(new Sprite("textures/" + texture + ".wpk"))
        .AddComponent(new CircleCollider())
        .AddComponent(new RigidBody2D() {
          PhysicBodyType = PhysicBodyType.Dynamic,
          IgnoreGravity = true,
          Damping = 0,
          Restitution = 1.0f,
          Friction = 0.0f,
          FixedRotation = true,
          CollidesWith = Physic2DCategory.Cat1
        })
        .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
        .AddComponent(new BonusBehaviour());
    }

    public string Name { get { return "Bonus" + id; } }
    public Entity Entity { get { return entity; } }
  }
}

