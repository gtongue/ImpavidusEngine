namespace ImpavidusCore {
  //TODO IDisposable
  //TODO Possibly use interface instead of abstract class
  public abstract class Component {
    //TODO use event handlers instead of methods.
    public abstract void Start();
    public abstract void Update();
  }
}