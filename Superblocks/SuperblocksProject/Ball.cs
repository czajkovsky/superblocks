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
    
    public Ball()
    {
      this.entity = new Entity("Ball")
        .AddComponent(
          new Transform2D() { X = WaveServices.Platform.ScreenWidth / 2,
            Y = 400,
            Origin = Vector2.Center }
        )
        .AddComponent(new Sprite("textures/ball.wpk"))
        .AddComponent(new CircleCollider())
        .AddComponent(new RigidBody2D())
        .AddComponent(new SpriteRenderer(DefaultLayers.Alpha));
    }

    public Entity Entity { get { return entity; } private set { entity = value; } }
  }
}

