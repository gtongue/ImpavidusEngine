// using OpenTK.Graphics.OpenGL;
// using System;

// namespace ImpavidusRenderer {
//   public class Mesh {
//     int vaoID;
//     int vboID;
//     public Mesh(){
//       LoadToGPU();
//     }

//     public void LoadToGPU(){
//       //TODO Gen all arays necessary not just one at a time
//       vaoID = GL.GenVertexArray();
//       GL.BindVertexArray(vaoID);
//       vboID = GL.GenBuffer();
//       GL.BindBuffer(BufferTarget.ArrayBuffer, vboID);
//       float[] data = {
//         1.0f, -1.0f,
//         1.0f, 0.0f,
//         0.0f, 0.0f,
//       };
//       GL.BufferData(
//         BufferTarget.ArrayBuffer,
//         (IntPtr)(data.Length * sizeof(float)), 
//         data, 
//         BufferUsageHint.StaticDraw);
//       GL.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 0, 0);
//       //TODO I don't know if this is necessary just doing for safety to not edit by mistake elsewhere
//       GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
//       GL.BindVertexArray(0);
//     }

//     public void Render(){
//       GL.BindVertexArray(vaoID);
//       GL.EnableVertexAttribArray(0);
//       GL.DrawArrays(PrimitiveType.Triangles, 0, 6);
//       GL.DisableVertexAttribArray(0);
//       GL.BindVertexArray(0);
//     }
//   }
// }