using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Libraries;
using ProgrammingParadigms;

namespace DomainAbstractions
{
    public class GameScreen : Canvas, IUI
    {
        // Public fields and properties
        public string InstanceName = "Default";

        // Private fields

        // Ports
        private List<IEventHandler> eventHandlers = new List<IEventHandler>();
        private IDataFlow<Canvas> canvasOutput;

        public GameScreen()
        {
            Width = 1280;
            Height = 720;
            Background = Brushes.LightBlue;

            // Needs to be focusable to register mouse and key events
            Focusable = true;
            FocusVisualStyle = null;
            Focus();
        }

        private void PostWiringInitialize()
        {
            foreach (var eventHandler in eventHandlers)
            {
                eventHandler.Sender = this;
            }
        }

        // IUI implementation
        UIElement IUI.GetWPFElement()
        {
            if (canvasOutput != null) canvasOutput.Data = this;

            return this;
        }
    }
}
