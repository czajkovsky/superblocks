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
    private Entity borderTopEntity, borderLeftEntity, borderRightEntity;
    public Border ()
    {
      this.borderLeftEntity = createBorder ("Left", -31, 0, 90);
      this.borderRightEntity = createBorder ("Right", WaveServices.Platform.ScreenWidth + 31, 0, 90);
      this.borderTopEntity = createBorder ("Top", 0, -20, 0);
    }
    
    private Entity createBorder (string name, float x, float y, float rotation)
    {
      Entity border = new Entity("border" + name)
        .AddComponent(new Transform2D() { X = x, Y = y, Origin = Vector2.Center, XScale = 15f, Rotation = MathHelper.ToRadians(rotation) })
        .AddComponent(new Sprite("textures/groundSprite.wpk"))
        .AddComponent(new RectangleCollider())
        .AddComponent(new RigidBody2D() { PhysicBodyType = PhysicBodyType.Static })
        .AddComponent(new SpriteRenderer(DefaultLayers.Opaque));
      return border;
    }
    
    public Entity BorderTopEntity { get { return borderTopEntity; } }
    public Entity BorderLeftEntity { get { return borderLeftEntity; } }
    public Entity BorderRightEntity { get { return borderRightEntity; } }
  }
}

