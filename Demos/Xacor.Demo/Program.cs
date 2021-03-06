﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DryIoc;
using Xacor.Graphics.Api;
using Xacor.Graphics.Api.GL46;
using Xacor.Graphics.Api.D3D11;
using Xacor.Graphics.Api.GL33;
using Xacor.Input;
using Xacor.Input.DirectInput;
using Xacor.Platform;
using Xacor.Platform.Windows;

namespace Xacor.Demo
{
    internal static class Program
    {
        private static IContainer CreateCompositionRoot()
        {
            var container = new Container(rules => rules.WithTrackingDisposableTransients());
            //container.Register<IProfiler>();
            
            var inputMappings = new List<InputMapping>
            {
                new KeyboardInputMapping("MoveForward", InputButton.W, InputButton.Mouse1),
                new KeyboardInputMapping("MoveBackward", InputButton.S, InputButton.Mouse2),
                new KeyboardInputMapping("SlideLeft", InputButton.A),
                new KeyboardInputMapping("SlideRight", InputButton.D),

                new MouseInputMapping("Horizontal", Axis.Horizontal),
                new MouseInputMapping("Vertical", Axis.Vertical),
            };

            container.RegisterInstance(inputMappings);
            container.Register<InputOptions>(Reuse.Singleton);
            container.RegisterInstance(new GraphicsOptions(new Size(1920, 1080), WindowState.Windowed, true));
            container.Register<Options>(Reuse.Singleton);
            container.Register<IGamePlatformFactory, Win32GamePlatformFactory>(Reuse.Singleton);
            container.RegisterInstance(DeviceType.Hardware);
            //container.Register<IGraphicsFactory, D3D11GraphicsFactory>(Reuse.Singleton);
            container.Register<IGraphicsFactory, GL33GraphicsFactory>(Reuse.Singleton);
            //container.Register<IGraphicsFactory, GL33GraphicsFactory>(Reuse.Singleton);
            container.Register<InputMapper>();
            container.Register<IInputFactory, DirectInputInputFactory>();
            container.Register<DemoGame>(Reuse.Singleton);
            return container;
        }

        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using var compositionRoot = CreateCompositionRoot();
            using var game = compositionRoot.Resolve<DemoGame>();

            game.Run();
        }
    }
}