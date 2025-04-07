using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace LearnOpenGL;

public class Program : GameWindow {
    //settings
    const int SCR_WIDTH = 800;
    const int SCR_HEIGHT = 600;
    //creating window glfw
    private Program(GameWindowSettings gws, NativeWindowSettings nws) : base(gws, nws) { 

    }

    protected override void OnFramebufferResize(FramebufferResizeEventArgs e) {
        framebuffer_size_callback(SCR_WIDTH, SCR_HEIGHT);
    }

    protected override void OnRenderFrame(FrameEventArgs args) {
        //input
        processInput();

        SwapBuffers();
    }

    private static void Main(string[] args) {
        GameWindowSettings gws = GameWindowSettings.Default;

        NativeWindowSettings nws = NativeWindowSettings.Default;
        nws.ClientSize = ( SCR_WIDTH, SCR_HEIGHT );
        nws.Title = "LearnOpenGL";

        new Program(gws, nws).Run();
    }

    private void processInput() {
        if (KeyboardState.IsAnyKeyDown) {
            if (KeyboardState.IsKeyDown(Keys.Escape)) {
                Close();
            }
        }
    }

    private static void framebuffer_size_callback(int width, int height) {
        GL.Viewport(0, 0, width, height);
    }
}