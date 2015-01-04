#region Using Statements
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Cameras;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.Graphics3D;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Resources;
using WaveEngine.Framework.Services;

#endregion

namespace SuperblocksProject
{
  // IMPORTANT NOTE
  // Currently Wave Engine references (WaveEngine.*.dll) *must* be added manually.
  // Please follow these steps:
  // 1. Under YourGame project, do right click on References and select "Edit references..."
  // 2. Select ".Net Assembly" tab, and go to:
  //    /Library/Frameworks/WaveEngine.framework/MacLibraries/
  //    , and select the following assemblies:
  //    WaveEngine.Adapter.dll
  //    WaveEngine.Common.dll
  //    WaveEngine.Framework.dll
  // 3. Click on "Add", followed by "Accept", in order to close the window
  // 4. Under YourGameProject project (please note the difference with previous step 1),
  //    do right click on References and select "Edit references..."
  // 5. Select ".Net Assembly" tab, and go to:
  //    /Library/Frameworks/WaveEngine.framework/MacLibraries/
  //    , and select the following assemblies:
  //    WaveEngine.Common.dll
  //    WaveEngine.Components.dll
  //    WaveEngine.Framework.dll
  //    WaveEngine.Materials.dll
  // 6. Click on "Add", followed by "Accept"
  // 7. Build, sorry for the inconveniences, and enjoy :-)

  // One last thing:
  // Some versions of Mono framework need X11, but Mac OS X Mavericks (10.9) does no longer include it.
  // If you have experienced problems with Wave Engine tools, you need to install X11 libraries,
  // that are available from the XQuartz project:
  // https://xquartz.macosforge.org

  public class MyScene : Scene
  {
    protected override void CreateScene ()
    {
      //Insert your scene definition here.

      #region Simple test
      //Create a 3D camera
      var camera3D = new FreeCamera ("Camera3D", new Vector3 (0, 2, 4), Vector3.Zero) { BackgroundColor = Color.CornflowerBlue };
      EntityManager.Add (camera3D);

      // Draw a cube
      Entity cube = new Entity ()
				.AddComponent (new Transform3D ())
				.AddComponent (Model.CreateCube ())
				.AddComponent (new Spinner () { AxisTotalIncreases = new Vector3 (1, 2, 3) })
				.AddComponent (new MaterialsMap ())
				.AddComponent (new ModelRenderer ());

      EntityManager.Add (cube);

      // Create a 2D camera
      var camera2D = new FixedCamera2D ("Camera2D") { ClearFlags = ClearFlags.DepthAndStencil }; // Transparent background need this clearFlags.
      EntityManager.Add (camera2D);

      // Draw a simple sprite
      Entity sprite = new Entity ()
				.AddComponent (new Transform2D ())
                   // Change this line for a custom assets "new Sprite("Content/MyTexture"))"
                   // Manage assets using the Resources.weproj link to open the Assets Exporter tool.
				.AddComponent (new Sprite (StaticResources.DefaultTexture))
				.AddComponent (new SpriteRenderer (DefaultLayers.Opaque));

      EntityManager.Add (sprite);
      #endregion
    }

    protected override void Start ()
    {
      base.Start ();

      // This method is called after the CreateScene and Initialize methods and before the first Update.
    }
  }
}

