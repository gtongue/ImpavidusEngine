using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.Collections.Generic;
using System;

namespace ImpavidusRenderer {
  public class Material {
    ShaderProgram shaderProgram;
    Dictionary<string, Uniform> uniforms;
    public Material(ShaderProgram shaderProgram){
      this.shaderProgram = shaderProgram;
      InitMaterial();
              // shaderProgram.SetUniform("u_color", new Vector2(1.0f, 0));
      SetUniform("u_color", new Vector2(1.0f, -1.0f));
    }

    public void SetUniform(string uniformName, object uniformValue){
      // shaderProgram.SetUniform(uniformName, uniformValue);
      uniforms[uniformName].value = uniformValue;
    }

    public void InitMaterial(){
      uniforms = new Dictionary<string, Uniform>();
      string[] uniformNames = shaderProgram.GetUniformNames();
      foreach(string uniformName in uniformNames){
        Tuple<int, ActiveUniformType> uniformInfo = shaderProgram.GetUniformInfo(uniformName);
        uniforms[uniformName] = new Uniform(uniformName, uniformInfo.Item1, uniformInfo.Item2, null);
      }
    }

    public void Prepare(){
      shaderProgram.Start();
      foreach(string uniformName in uniforms.Keys){
        Uniform uniform = uniforms[uniformName];
        object rawValue = uniform.value;
        if(rawValue == null)
          continue;
        if(uniform.type == ActiveUniformType.FloatVec2)
        {
          Vector2 value = (Vector2)rawValue;
          shaderProgram.SetUniform(uniformName, value);
        }
      }
    }
    
    public void Finish(){
      shaderProgram.Stop();
    }
  }
}