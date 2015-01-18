#region Using Statements
using System;
using WaveEngine.Common.Math;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services;
#endregion

namespace SuperblocksProject
{
  public class Border
  {
    private Entity entity;
    
    public Border(string name, float x, float y, float rotation)
    {
      this.entity = new Entity("border" + name)
        .AddComponent(new Transform2D() { X = x, Y = y, Origin = Vector2.Center, XScale = 15f,
                                          Rotation = MathHelper.ToRadians(rotation) })
        .AddComponent(new Sprite("textures/ground.wpk"))
        .AddComponent(new RectangleCollider())
        .AddComponent(new RigidBody2D() { PhysicBodyType = PhysicBodyType.Static })
        .AddComponent(new SpriteRenderer(DefaultLayers.Opaque));
    }
        
    public Entity Entity { get { return entity; } }
  }
}

