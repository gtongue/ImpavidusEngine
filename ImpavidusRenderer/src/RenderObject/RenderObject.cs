using ImpavidusCore;
using OpenTK;

namespace ImpavidusRenderer {
  public class RenderObject {
    Material material;
    Mesh mesh;

    public RenderObject(ShaderProgram shaderProgram){
      material = new Material(shaderProgram);
      mesh = new Mesh();
    }

    public void Render(){
      material.Prepare();
      mesh.Render();
      material.Finish();
    }
  }
}