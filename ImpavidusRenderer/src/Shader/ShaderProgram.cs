using OpenTK.Graphics.OpenGL;
using System;

namespace ImpavidusRenderer {
  public class ShaderProgram {
    int vertexID;
    int fragmentID;
    public int programID {get;}

    public ShaderProgram(string vertexSource, string fragmentSource){
      this.vertexID = LoadShader(vertexSource, ShaderType.VertexShader);
      this.fragmentID = LoadShader(fragmentSource, ShaderType.FragmentShader);
      this.programID = GL.CreateProgram();
      GL.AttachShader(programID, vertexID);
      GL.AttachShader(programID, fragmentID);
      GL.LinkProgram(programID);
      GL.ValidateProgram(programID);

      int status;
      GL.GetProgram(programID, GetProgramParameterName.LinkStatus, out status);
      if(status == 0)
      {
        throw new OpenTK.GraphicsException(
          string.Format("Error linking Program: {0}.", GL.GetProgramInfoLog(programID)));
      }
      int test = GL.GetAttribLocation(programID, "position");
      Console.WriteLine(test);
    }

    int LoadShader(string shaderSource, ShaderType type){
      int shaderID = GL.CreateShader(type);
      GL.ShaderSource(shaderID, shaderSource);
      GL.CompileShader(shaderID);
      int status;
      GL.GetShader(shaderID, ShaderParameter.CompileStatus, out status);
      if(status == 0)
        throw new OpenTK.GraphicsException(
          string.Format("Error compiling {0} shader: {1}",
          type, GL.GetShaderInfoLog(shaderID))
        );

      return shaderID;
    }
    public void Start(){
      GL.EnableVertexAttribArray(0);
      GL.UseProgram(programID);
    }

    public void Stop(){
      GL.DisableVertexAttribArray(0);
      GL.UseProgram(0);
    }
    //TODO CleanUp!
    public void CleanUp()
    {
      GL.UseProgram(0);
      GL.DetachShader(programID, vertexID);
      GL.DetachShader(programID, fragmentID);
      GL.DeleteShader(vertexID);
      GL.DeleteShader(fragmentID);
      GL.DeleteProgram(programID);
    }
  }
}