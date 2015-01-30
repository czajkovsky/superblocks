#region Using Statements
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Components.UI;
using WaveEngine.Framework.UI;
using WaveEngine.Common.Math;
using WaveEngine.Components.Cameras;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Resources;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.Physics2D;
#endregion

namespace SuperblocksProject
{
  public class UI
  {
    private TextBlock score;
    private TextBlock lives;
    private Entity background;
    
    public UI ()
    {
      this.score = createText("Score 0", TextAlignment.Left, HorizontalAlignment.Left);
      this.lives = createText("Lives 3", TextAlignment.Right, HorizontalAlignment.Right);
      this.background = createBackground();
    }
    
    private TextBlock createText(string text, TextAlignment textAlignment, HorizontalAlignment horizontalAlignment)
    {
      return new TextBlock()
      {  
        Text = text,
        Width = 300,
        Foreground = Color.White,
        TextAlignment = textAlignment,
        HorizontalAlignment = horizontalAlignment,
        VerticalAlignment = VerticalAlignment.Bottom,
        Margin = new Thickness(10, 0, 10, 0)
      };
    }

    private Entity createBackground()
    {
      Entity background = new Entity("background")
        .AddComponent(new Transform2D() { Y = 10, DrawOrder = 1f })
        .AddComponent(new SpriteRenderer(DefaultLayers.Alpha))
        .AddComponent(new Sprite("textures/background.wpk"));
      return background;
    }
    
    public void SetScore(int points)
    {
      score.Text = "Score: " + points;
    }
    
    public Entity Background { get { return background; } }    
    public TextBlock Score { get { return score; } }
    public TextBlock Lives { get { return lives; } }
  }
}

