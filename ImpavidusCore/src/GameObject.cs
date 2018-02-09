using System;
using System.Collections.Generic;
using OpenTK;

namespace ImpavidusCore 
{
  public class GameObject: Object {
    List<Component> components;
    public int id;
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;
    public GameObject(int id):base(id){
      components = new List<Component>();
      this.position = new Vector3(0,0,0);
      this.rotation = new Vector3(0,0,0);
      this.scale = new Vector3(1,1,1);
    }

    //TOOD this needs to be more generic I think just couldn't figure out how to
    // add class of ComponentType to the list even though I do type checking above.
    public Component AddComponent<ComponentType>(){
      if(!typeof(ComponentType).IsSubclassOf(typeof(Component))){
        throw new Exception("Attempted to add component that is not a component");
      }
      Component component = (Component)Activator.CreateInstance(typeof(ComponentType));
      components.Add(component);
      return component;
    }


    public override void OnRender(object sender, FrameEventArgs e){
      foreach(Component component in components){
        component.OnRender(e);
      }
    }

    public override void OnUpdate(object sender, FrameEventArgs e){
      foreach(Component component in components){
        component.OnUpdate(e);
      }
    }
  }
}