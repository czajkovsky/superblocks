using System;
using MonoMac.Foundation;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Common.Graphics;
using System.IO;
using System.Reflection;
using WaveEngine.Common.Input;

namespace Superblocks
{
  [Register ("AppDelegate")]
  public class App : WaveEngine.Adapter.Application
  {
    SuperblocksProject.Game game;
    SpriteBatch spriteBatch;
    TimeSpan time;
    Color backgroundSplashColor;

    public App ()
    {
      this.WindowTitle = "Superblocks";
      this.Width = 1280;
      this.Height = 720;
    }

    public override void Initialize ()
    {
      this.game = new SuperblocksProject.Game();
      this.game.Initialize(this);
    }

    public override void Update (TimeSpan elapsedTime)
    {
      if (this.game != null && !this.game.HasExited) {
        if (WaveServices.Input.KeyboardState.F10 == ButtonState.Pressed) {
          this.FullScreen = !this.FullScreen;
        }

        if (WaveServices.Input.KeyboardState.Escape == ButtonState.Pressed) {
          WaveServices.Platform.Exit ();
        } else {
          this.game.UpdateFrame (elapsedTime);
        }
      }
    }

    public override void Draw (TimeSpan elapsedTime)
    {
      if (this.game != null && !this.game.HasExited) {
        this.game.DrawFrame (elapsedTime);
      }
    }
  }
}
