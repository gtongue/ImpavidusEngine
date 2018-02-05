using System;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;

namespace ImpavidusRenderer {
  public class GameWindow : OpenTK.GameWindow {
    public GameWindow(int width, int height):base(
      width, //Width
      height, //Height
      OpenTK.Graphics.GraphicsMode.Default, //Graphics Mode
      "Initial Window", //Title
      OpenTK.GameWindowFlags.Default, //Flags
      OpenTK.DisplayDevice.Default, //Display Device
      3, //Major
      0, //Minor
      OpenTK.Graphics.GraphicsContextFlags.ForwardCompatible){ //Compatibility
        Console.WriteLine("OpenGL Version: " + GL.GetString(StringName.Version));
      }

      protected override void OnLoad(EventArgs e){
        base.OnLoad(e);
      }

      protected override void OnUpdateFrame(OpenTK.FrameEventArgs e){
        base.OnUpdateFrame(e);
      }

      protected override void OnRenderFrame(OpenTK.FrameEventArgs e){
        base.OnRenderFrame(e);
        GL.Clear(ClearBufferMask.ColorBufferBit);
        GL.ClearColor(Color4.Green);

        GL.Begin(PrimitiveType.Quads);
        GL.Color4(Color4.Red);
        GL.Vertex2(0,0);
        GL.Color4(Color4.Green);
        GL.Vertex2(1,0);
        GL.Color4(Color4.Blue);
        GL.Vertex2(1,-1);
        GL.Color4(Color4.Orange);
        GL.Vertex2(0,-1);

        GL.End();

        this.SwapBuffers();
      }
  }
}