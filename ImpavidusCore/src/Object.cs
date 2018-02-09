using OpenTK;

namespace ImpavidusCore {
  public abstract class Object {
    int id;
    public Object(int id){
      this.id = id;
    }

    public abstract void OnRender(object sender, FrameEventArgs e);
    public abstract void OnUpdate(object sender, FrameEventArgs e);

  }
}