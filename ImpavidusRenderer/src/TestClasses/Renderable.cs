using OpenTK.Graphics.OpenGL;
using System;

namespace ImpavidusRenderer {
  public class Renderable {

    int vertexBuffer;
    ShaderProgram shaderProgram;
    public Renderable(ShaderProgram shaderProgram){
      this.shaderProgram = shaderProgram;
      InitBuffers();
      // GetAttributes();
      GetUniforms();
    }

    public void Render(){
      GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBuffer);
      GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 0, 0);
      GL.DrawArrays(PrimitiveType.Triangles, 0, 6);
    }

    public void GetAttributes(){
      int count;
      ActiveAttribType type;
      int size;
      GL.GetProgram(shaderProgram.programID, GetProgramParameterName.ActiveAttributes, out count);
      Console.WriteLine(string.Format("Count of attributes is {0}", count));
      for(int i = 0; i < count; i++){
        string name = GL.GetActiveAttrib(shaderProgram.programID, i, out size, out type);
        Console.WriteLine(string.Format("Size: {0}", size));
        Console.WriteLine(string.Format("Type: {0}", type));
        Console.WriteLine(string.Format("Name: {0}", name));
      }
    }

    public void GetUniforms(){
      int count;
      int size;
      ActiveUniformType type;
      GL.GetProgram(shaderProgram.programID, GetProgramParameterName.ActiveUniforms, out count);
      Console.WriteLine(string.Format("Count of uniforms is {0}", count));
      for(int i = 0; i < count; i++){
        string name = GL.GetActiveUniform(shaderProgram.programID, i, out size, out type);
        Console.WriteLine(string.Format("Size: {0}", size));
        Console.WriteLine(string.Format("Type: {0}", type));
        Console.WriteLine(string.Format("Name: {0}", name));
      }
    }

    public void InitBuffers(){
      GL.GenBuffers(1, out vertexBuffer);
      Console.WriteLine(vertexBuffer);
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