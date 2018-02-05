using System;
using System.Collections.Generic;

namespace ImpavidusCore 
{
  public class GameObject {
    List<Component> components;        
    public GameObject(){
      components = new List<Component>();
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

  }
}