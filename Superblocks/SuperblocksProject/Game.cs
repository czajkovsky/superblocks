#region Using Statements
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;

#endregion

namespace SuperblocksProject
{
  public class Game : WaveEngine.Framework.Game
  {
    public override void Initialize (IApplication application)
    {
      base.Initialize (application);

      ViewportManager vm = WaveServices.ViewportManager;
      vm.Activate (1280, 720, ViewportManager.StretchMode.Uniform);

      Player player = new Player(5);
      ScreenContext screenContext = new ScreenContext(new LevelScene(player));	
      WaveServices.ScreenContextManager.To (screenContext);
    }

  }
}

