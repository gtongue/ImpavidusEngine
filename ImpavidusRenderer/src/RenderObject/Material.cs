using OpenTK;
using System.Collections.Generic;

namespace ImpavidusRenderer {
  public class Material {
    ShaderProgram shaderProgram;
    Dictionary<string, object> uniforms;
    public Material(ShaderProgram shaderProgram){
      this.shaderProgram = shaderProgram;
      InitMaterial();
              // shaderProgram.SetUniform("u_color", new Vector2(1.0f, 0));
      SetUniform("u_color", new Vector2(1.0f, 0));
    }

    public void SetUniform<T>(string uniformName, T uniformValue){
      shaderProgram.SetUniform(uniformName, uniformValue);
      uniforms[uniformName] = uniformValue;
    }

    public void InitMaterial(){
      uniforms = new Dictionary<string, object>();
      string[] uniformNames = shaderProgram.GetUniformNames();
      foreach(string uniformName in uniformNames){
        //TODO init default values for all of the uniforms
        uniforms[uniformName] = null;
      }
    }

    public void Prepare(){
      shaderProgram.Start();
      foreach(string uniformName in uniforms.Keys){
        object value = uniforms[uniformName];
        if(value != null)
          shaderProgram.SetUniform(uniformName, value);
      }
    }
    public void Finish(){
      shaderProgram.Stop();
    }
  }
}