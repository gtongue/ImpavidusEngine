using OpenTK.Graphics.OpenGL;

namespace ImpavidusRenderer {
  public class ShaderProgram {
    int vertexID;
    int fragmentID;
    int programID;

    public ShaderProgram(string vertexSource, string fragmentSource){
      this.vertexID = LoadShader(vertexSource, ShaderType.VertexShader);
      this.fragmentID = LoadShader(fragmentSource, ShaderType.FragmentShader);
      this.programID = GL.CreateProgram();
    }

    public int LoadShader(string shaderSource, ShaderType type){
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