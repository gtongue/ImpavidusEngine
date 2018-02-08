using OpenTK.Graphics.OpenGL;
using OpenTK;
using System;

namespace ImpavidusRenderer {
  public class Renderable {

    int vertexBuffer;
    int u;
    ShaderProgram shaderProgram;
    public Renderable(ShaderProgram shaderProgram){
      this.shaderProgram = shaderProgram;
      InitBuffers();
      u = GL.GetUniformLocation(shaderProgram.programID, "u_color");
      Console.WriteLine(u);
    }

    public void Render(){
      GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);
      GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, Vector2.SizeInBytes, 0);
      GL.Uniform2(u, new Vector2(1.0f, 0.0f));
      GL.DrawArrays(PrimitiveType.Triangles, 0, 6);
      ErrorCode err = GL.GetError();
      if(err != ErrorCode.NoError)
        Console.WriteLine(err.ToString());
    }

    public void InitBuffers(){
      GL.GenBuffers(1, out vertexBuffer);
      Console.WriteLine(vertexBuffer);
      GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);
      float[] data = {
        1.0f, -1.0f,
        1.0f, 0.0f,
        0.0f, 0.0f,
         };

      GL.BufferData(
        BufferTarget.ArrayBuffer,
        (IntPtr)(data.Length * sizeof(float)), 
        data, 
        BufferUsageHint.StaticDraw);
      GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 0, 0);
      //Todo VAO's and VBO's      
    }

  }
}