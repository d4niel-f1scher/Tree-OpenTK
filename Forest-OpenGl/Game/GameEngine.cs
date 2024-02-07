using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Common;

namespace Forest_OpenGl.Game
{
    public class GameEngine : GameWindow
    {
        public bool IsRunning { get; private set; }
        public float[] vertices = new float[] 
        { 
            0.0f,0.0f,1.0f,
            0.0f,0.0f,1.0f,
            0.0f,0.0f,1.0f,

            0.0f,0.0f,1.0f,
            0.0f,0.0f,1.0f,
            0.0f,0.0f,1.0f,

            0.0f,0.0f,1.0f,
            0.0f,0.0f,1.0f,
            0.0f,0.0f,1.0f,
        };
        int simulatedDays;
        PineTree pineTree;
        public GameEngine(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings, PineTree pineTree,int simulatedDays) : base(gameWindowSettings, nativeWindowSettings)
        {
            this.pineTree = pineTree;
            this.simulatedDays = simulatedDays;
        }
        public bool Initialise()
        {
            IsRunning = false;
            if (InitialiseOpenGL())
            {
                Console.WriteLine("Sucessfully initialised Game Engine");
                return true;
            }
            else 
            {
                Console.WriteLine("Failed to  initialise Game Engine");
                return false;
            }
        }
        public bool InitialiseOpenGL() 
        {
            GLFWBindingsContext binding = new GLFWBindingsContext();
            GL.LoadBindings(binding);
            if (GLFW.Init())
            {
                Console.WriteLine("Sucessfully initialised GLFW and OpenGl");
                return true;
            }
            else 
            {
                Console.WriteLine("Failed to  initialise GLFW and OpenGl");
                return false;
            }
        }
        public void RunGameLoop()
        {
            if (!IsRunning) 
            {
                IsRunning = true;
                Console.WriteLine("Starting Game Loop");
                base.Run();
            }
        }
        int vao;
        int vbo;
        protected override void OnLoad()
        {
            base.OnLoad();
            vao = GL.GenVertexArray();
            GL.BindVertexArray(vao);
            vbo = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices.ToArray(), BufferUsageHint.StaticDraw);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0,3,VertexAttribPointerType.Float, true,0,0);
            
        }
        protected override void OnUnload()
        {
            base.OnUnload();
        }
        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            if (simulatedDays > 0) 
            {
                GL.Clear(ClearBufferMask.ColorBufferBit);
                pineTree.Grow();
                vertices = new float[]
                {
                    -pineTree.radius, -1.0f,1.0f,
                    pineTree.radius,  -1.0f,1.0f,
                    0.0f,-1 + pineTree.height,1.0f,

                    (pineTree.radius/2.0f) - (pineTree.branches[0].radius / (float)Math.Sqrt(2)), (-1.0f + (pineTree.height / 2.0f)) + (pineTree.branches[0].radius / (float)Math.Sqrt(2)),1.0f,
                    (pineTree.radius/2.0f) + (pineTree.branches[0].radius / (float)Math.Sqrt(2)), (-1.0f + (pineTree.height / 2.0f)) - (pineTree.branches[0].radius / (float)Math.Sqrt(2)),1.0f,
                    (pineTree.radius/2.0f) + (pineTree.branches[0].height / (float)Math.Sqrt(2)), (-1.0f + (pineTree.height / 2.0f)) + (pineTree.branches[0].height / (float)Math.Sqrt(2)),1.0f,

                    (-pineTree.radius/2.0f) + (pineTree.branches[1].radius / (float)Math.Sqrt(2)), (-1.0f + (pineTree.height / 2.0f)) + (pineTree.branches[1].radius / (float)Math.Sqrt(2)),1.0f,
                    (-pineTree.radius/2.0f) - (pineTree.branches[1].radius / (float)Math.Sqrt(2)), (-1.0f + (pineTree.height / 2.0f)) - (pineTree.branches[1].radius / (float)Math.Sqrt(2)),1.0f,
                    (-pineTree.radius/2.0f) - (pineTree.branches[1].height / (float)Math.Sqrt(2)), (-1.0f + (pineTree.height / 2.0f)) + (pineTree.branches[1].height / (float)Math.Sqrt(2)),1.0f,
                };
                GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices.ToArray(), BufferUsageHint.DynamicDraw);
                simulatedDays -= 1;
            }
            
            base.OnUpdateFrame(args);
            GameTime.Delta = (float)args.Time;
        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Viewport(0, 0, Size.X, Size.Y);
            GL.BindVertexArray(vao);
            GL.DrawArrays(BeginMode.Triangles, 0, vertices.Length);

            Context.SwapBuffers();
        }
    }
}
