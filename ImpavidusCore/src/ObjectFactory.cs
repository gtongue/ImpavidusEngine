using OpenTK;

namespace ImpavidusCore {
  public class ObjectFactory {
    static GameWindow window;
    
    static int objectId = 0;
    public ObjectFactory(){
      throw new System.Exception("Do not create instances of Object Factory!");
    }

    public static void Init(GameWindow window){
      ObjectFactory.window = window;
    }

    public static GameObject InstantiateGameObject(Vector3 position, Vector3 rotation, Vector3 scale){
      GameObject gameObject = new GameObject(objectId++);
      ObjectFactory.window.RenderFrame += gameObject.OnRender;
      ObjectFactory.window.UpdateFrame += gameObject.OnUpdate;
      return gameObject;
    } 

    public static void InstantiatePrefab(){

    }
  }
}