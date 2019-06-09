﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Xacor.Platform.Windows
{
    internal class Win32GameWindow : IGameWindow
    {
        private readonly MainView _mainView;

        public IntPtr Handle { get; }

        public int Height => _mainView.ClientSize.Height;

        public string Title
        {
            get => _mainView.Text;
            set => _mainView.Text = value;
        }

        public int Width => _mainView.ClientSize.Width;

        public bool IsOpen { get; private set; } = true;

        public void Close()
        {
            _mainView.Close();
        }

        public void Dispose()
        {
            _mainView.Dispose();
        }

        public Win32GameWindow(string caption)
        {
            _mainView = new MainView
            {
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen,
                ClientSize = new Size(1920, 1080)
            };

            _mainView.Closed += (_, __) => { IsOpen = false; };

            Handle = _mainView.Handle;
        }

        public void Show()
        {
            _mainView.Show();
        }
    }
}