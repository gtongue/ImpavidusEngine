using OpenTK.Graphics.OpenGL;
using System;

namespace ImpavidusRenderer {
  public class Renderable {

    int vertexBuffer;
    public Renderable(){
      InitBuffers();
    }

    public void Render(){
      GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);
      GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 0, 0);
      GL.DrawArrays(PrimitiveType.Triangles, 0, 6);
    }

    public void InitBuffers(){
      GL.CreateBuffers(1, out vertexBuffer);
      GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);
      float[] data = {
        0.0f, 0.0f,
        1.0f, 0.0f,
        1.0f, -1.0f };

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