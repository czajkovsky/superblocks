#region Using Statements
using System;
using System.Collections.Generic;
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
  public abstract class Block
  {
    protected int id, lives, line, type, points;
    protected BlockBody body;
    protected bool harmed = false;
    
    public Block(int id, int offsetX, int offsetY)
    {
      this.id = id;
      this.line = offsetY;
      this.body = new BlockBody(offsetX, offsetY, this);
    }
    
    public abstract void Hit(BlocksManager manager);
      
    public string Name { get { return "block" + id; } }
    public int Lives { get { return lives; } }
    public int Line { get { return line; } }
    public int Points { get { return points; } }
    public bool Harmed { get { return harmed; } }
    public int Type { get { return type; } }
    public BlockBody Body { get { return body; } }
    public Entity Entity { get { return body.Entity; } }
  }
}

