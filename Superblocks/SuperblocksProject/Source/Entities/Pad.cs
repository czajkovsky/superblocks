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
    private int BOTTOM_OFFSET = WaveServices.Platform.ScreenHeight - 75;

    private int width, offset;
    private Entity entity;
    private Game game;

    public Pad (Game game)
    {
      this.width = INITIAL_WIDTH;
      this.offset = WaveServices.Platform.ScreenWidth / 2;
      this.game = game;

      this.entity = new Entity("pad")
        .AddComponent(new Transform2D() {
          X = this.offset,
          Y = BOTTOM_OFFSET,
          Origin = Vector2.Center
        })
        .AddComponent(new Sprite("textures/pad.wpk"))
        .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
        .AddComponent(new PerPixelCollider("textures/pad.wpk", 1f))
        .AddComponent(new RigidBody2D() {
          PhysicBodyType = PhysicBodyType.Dynamic,
          Mass = 400000f,
          Damping = 0,
          Restitution = 1f,
          Friction = 0f,
          IgnoreGravity = true,
          FixedRotation = true,
          CollisionCategories = Physic2DCategory.All
        })
        .AddComponent(new PadBehaviour(this));
    }

    public Entity Entity { get { return entity; } private set { entity = value; } }
    public int Width { get { return width; } private set { width = value; } }
    public Game Game { get { return game; } }
  }
}
