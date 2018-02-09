using OpenTK;

namespace ImpavidusCore {
  //TODO IDisposable
  //TODO Possibly use interface instead of abstract class
  public abstract class Component {
    public abstract void Start();
    public abstract void OnRender(FrameEventArgs e);
    public abstract void OnUpdate(FrameEventArgs e);
  }
}