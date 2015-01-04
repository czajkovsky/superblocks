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
  public class Pad
  {
    private const int INITIAL_WIDTH = 256;
    private int BOTTOM_OFFSET = WaveServices.Platform.ScreenHeight - 55;

    private int width, offset;
    private Entity entity;
    
    public Pad ()
    {
      this.width = INITIAL_WIDTH;
      this.offset = WaveServices.Platform.ScreenWidth / 2;
      
      this.entity = new Entity("pad")
        .AddComponent(new Transform2D() { X = this.offset, Y = BOTTOM_OFFSET, Origin = Vector2.Center })
        .AddComponent(new Sprite("textures/pad.wpk"))
        .AddComponent(new RectangleCollider())
        .AddComponent(new RigidBody2D() { PhysicBodyType = PhysicBodyType.Static })
        .AddComponent(new SpriteRenderer(DefaultLayers.Opaque))
        .AddComponent(new PadBehaviour(this));
    }
    
    public Entity Entity { get { return entity; } private set { entity = value; } }
    public int Width { get { return width; } private set { width = value; } }
  }
}

