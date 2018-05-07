using OpenTK.Graphics.OpenGL;
using OpenTK;
using System;
using System.Linq;
using System.Collections.Generic;

namespace ImpavidusRenderer {
  public class ShaderProgram {
    int vertexID;
    int fragmentID;
    Dictionary<string, Tuple<int, ActiveUniformType>> uniforms;
    Dictionary<string, Tuple<int, ActiveAttribType>> attributes;
    public int programID {get;}

    public ShaderProgram(string vertexSource, string fragmentSource){
      this.vertexID = LoadShader(vertexSource, ShaderType.VertexShader);
      this.fragmentID = LoadShader(fragmentSource, ShaderType.FragmentShader);
      this.programID = GL.CreateProgram();
      GL.AttachShader(programID, vertexID);
      GL.AttachShader(programID, fragmentID);
      GL.LinkProgram(programID);
      GL.ValidateProgram(programID);
      GL.BindAttribLocation(programID, 0, "position");

      int status;
      GL.GetProgram(programID, GetProgramParameterName.LinkStatus, out status);
      if(status == 0)
      {
        throw new OpenTK.GraphicsException(
          string.Format("Error linking Program: {0}.", GL.GetProgramInfoLog(programID)));
      }
      uniforms = new Dictionary<string, Tuple<int, ActiveUniformType>>();
      GetUniforms();
      attributes = new Dictionary<string, Tuple<int, ActiveAttribType>>();
      GetAttributes();
    }

    private void GetUniforms(){
      int count;
      int size;
      ActiveUniformType type;
      GL.GetProgram(programID, GetProgramParameterName.ActiveUniforms, out count);
      for(int i = 0; i < count; i++){
        string name = GL.GetActiveUniform(programID, i, out size, out type);
        uniforms.Add(name, Tuple.Create(i, type));
      }
    }

    public string[] GetUniformNames(){
      return uniforms.Keys.ToArray();
    }

    public Tuple<int, ActiveUniformType> GetUniformInfo(string uniformName){
      if(uniforms.ContainsKey(uniformName)){
        return uniforms[uniformName];
      }
      throw new GraphicsException("Error fetching uniform info: " + uniformName);
    }
    
    public void GetAttributes(){
      int count;
      ActiveAttribType type;
      int size;
      GL.GetProgram(programID, GetProgramParameterName.ActiveAttributes, out count);
      Console.WriteLine(string.Format("Count of attributes is {0}", count));
      for(int i = 0; i < count; i++){
        string name = GL.GetActiveAttrib(programID, i, out size, out type);
        attributes.Add(name, Tuple.Create(i, type));
      }
    }

    public void SetUniform(string name, Vector2 value){
      Tuple<int, ActiveUniformType> uniform = uniforms[name];
      GL.Uniform2(uniform.Item1, (Vector2)(object)value);
    }

    public void UniformError<T>(ActiveUniformType type, T value){
      // throw new GraphicsException("Uniform type mismatch. Expected:" + type.ToString() + "Received:" + typeof(T));
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
      GL.UseProgram(programID);
    }

    public void Stop(){
      GL.UseProgram(0);
    }
    //TODO CleanUp! with disposable
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