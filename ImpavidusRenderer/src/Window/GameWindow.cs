using System;
using System.IO;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK;

namespace ImpavidusRenderer {
  public class GameWindow : OpenTK.GameWindow {
    Renderable renderable;
    //TODO Need much better way of loading files in based on relative path
    ShaderProgram shaderProgram;
    RenderObject renderObject;
    Mesh mesh;
    public GameWindow(int width, int height):base(
      width, //Width
      height, //Height
      OpenTK.Graphics.GraphicsMode.Default, //Graphics Mode
      "Initial Window", //Title
      OpenTK.GameWindowFlags.Default, //Flags
      OpenTK.DisplayDevice.Default, //Display Device
      4, //Major
      0, //Minor
      OpenTK.Graphics.GraphicsContextFlags.ForwardCompatible){ //Compatibility
        Console.WriteLine("OpenGL Version: " + GL.GetString(StringName.Version));
        // this.RenderFrame += Subscriber;
      }

      public void Subscriber(object sender, OpenTK.FrameEventArgs e){
        Console.WriteLine("Subscribed!");
      }

      protected override void OnLoad(EventArgs e){
        base.OnLoad(e);
        shaderProgram = new ShaderProgram(
              File.ReadAllText("./ImpavidusRenderer/src/Shader/Shaders/vs.glsl"),
              File.ReadAllText("./ImpavidusRenderer/src/Shader/Shaders/fs.glsl"));
        mesh = new Mesh();
        renderObject = new RenderObject(shaderProgram);
        // renderable = new Renderable(shaderProgram);
      }
      
      protected override void OnRenderFrame(OpenTK.FrameEventArgs e){
        base.OnRenderFrame(e);
        GL.Clear(ClearBufferMask.ColorBufferBit);
        GL.ClearColor(Color4.Green);
        renderObject.Render();
        // shaderProgram.Start();
        // shaderProgram.SetUniform("u_color", new Vector2(1.0f, 0));
        // mesh.Render();
        // renderable.Render();
        // shaderProgram.Stop();
        // GL.Begin(PrimitiveType.Triangles);
        // GL.Color4(Color4.Red);
        // GL.Vertex2(0,0);
        // GL.Color4(Color4.Green);
        // GL.Vertex2(1,0);
        // GL.Color4(Color4.Blue);
        // GL.Vertex2(1,-1);

        // GL.End();

        this.SwapBuffers();
      }
  }
}