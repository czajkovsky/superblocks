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
  public class Block
  {
    private const int WIDTH = 114;
    private const int HEIGHT = 49;
    private const int GUTTER = 5;
    private const int OFFSET_X = 20;
    private const int OFFSET_Y = 28;
    
    private Entity entity;
    int id, offsetX, offsetY;
    int id, offsetX, offsetY, lives;
    
    public Block(int id, int offsetX, int offsetY)
    {
      this.id = id;
      this.lives = 1;
      this.offsetX = OFFSET_X + GUTTER + offsetX * (WIDTH + 2 * GUTTER) + (int)((float)WIDTH / 2f);
      this.offsetY = OFFSET_Y + GUTTER + offsetY * (HEIGHT + 2 * GUTTER) + (int)((float)HEIGHT / 2f);
      
      this.entity = new Entity("block" + this.id)
        .AddComponent(new Transform2D() { X = this.offsetX, Y = this.offsetY, Origin = Vector2.Center })
        .AddComponent(new Sprite("textures/blockRed.wpk"))
        .AddComponent(new RectangleCollider())
        .AddComponent(new RigidBody2D () { PhysicBodyType = PhysicBodyType.Static })
        .AddComponent(new SpriteRenderer(DefaultLayers.Opaque))
        .AddComponent(new BlockBehaviour(this));
    }
        
    public bool Hit() 
    {
      this.lives--;
      if (lives > 0)
        changeTexture ();
        return false;
      return true;
    }
    
    private void changeTexture() 
    {
      this.entity
        .RemoveComponent<Sprite>()
        .AddComponent(new Sprite ("textures/groundSprite.wpk"))
        .RefreshDependencies();
    }
    
    public string Name { get { return "block" + id; } }
    public Entity Entity { get { return entity; } private set { entity = value; } }
  }
}

