using OpenTK.Graphics.OpenGL;

namespace ImpavidusRenderer {
  public class Uniform {
    public string name;
    public int location;
    public ActiveUniformType type;
    public object value;
    public Uniform(string name, int location, ActiveUniformType type, object value){
      this.type = type;
      this.name = name;
      this.location = location;
      this.value = value;
    }
    
  }
}