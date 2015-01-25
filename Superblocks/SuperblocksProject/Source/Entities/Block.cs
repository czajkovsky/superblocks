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
    protected int id, lives, line;
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
    public bool Harmed { get { return harmed; } }
    public Entity Entity { get { return body.Entity; } }
  }
}

