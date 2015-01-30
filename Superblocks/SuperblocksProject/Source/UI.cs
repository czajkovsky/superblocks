#region Using Statements
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Components.Cameras;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.UI;
using WaveEngine.Framework.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;
#endregion

namespace SuperblocksProject
{
  public class UI
  {
    private TextBlock score;
    
    public UI ()
    {
      this.score = createScore();
    }
    
    private TextBlock createScore()
    {
      return new TextBlock()
      {  
        Text = "Score: 0",
        Width = 300,
        Foreground = Color.White,
        TextAlignment = TextAlignment.Left,
        HorizontalAlignment = HorizontalAlignment.Left,
        VerticalAlignment = VerticalAlignment.Bottom,
        Margin = new Thickness(10, 10, 0, 0)
      };
    }
    
    public TextBlock Score { get { return score; } }
  }
}

