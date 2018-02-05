using System;
using ImpavidusRenderer;

namespace ImpavidusClient
{
    class Program
    {
        static void Main(string[] args)
        {
            // GameObject b = new GameObject();
            // b.Test();
          using(GameWindow window = new GameWindow(1280, 720)){
            window.Run();
          }
        }
    }
}
