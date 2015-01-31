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
  public class Ball
  {
    private Entity entity;
    private int id;
    
    public Ball(int id)
    {
      this.id = id;
      this.entity = new Entity("Ball" + id)
        .AddComponent(
          new Transform2D() { X = WaveServices.Platform.ScreenWidth / 2,
            Y = 400,
            Origin = Vector2.Center }
        )
        .AddComponent(new Sprite("textures/ball.wpk"))
        .AddComponent(new CircleCollider())
        .AddComponent(new RigidBody2D() {
          PhysicBodyType = PhysicBodyType.Dynamic,
          IgnoreGravity = true,
          Damping = 0,
          Restitution = 1.0f,
          Friction = 0.0f,
          FixedRotation = true,
          CollisionCategories = Physic2DCategory.Cat2,
          CollidesWith = Physic2DCategory.Cat1
        })
        .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
        .AddComponent(new BallBehaviour());
    }

    public string Name { get { return "Ball" + id; } }
    public Entity Entity { get { return entity; } private set { entity = value; } }
  }
}

