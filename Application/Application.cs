using System;
using Libraries;
using ProgrammingParadigms;
using DomainAbstractions;

namespace Application
{
    public class Application
    {
        private MainWindow mainWindow = new MainWindow("SnakeALA");

        private Application Initialize()
        {
            Wiring.PostWiringInitialize();
            return this;
        }

        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Initialize().mainWindow.Run();
        }

        private Application()
        {
            // BEGIN AUTO-GENERATED INSTANTIATIONS FOR SnakeALA.xmind
            
            // END AUTO-GENERATED INSTANTIATIONS FOR SnakeALA.xmind

            // BEGIN AUTO-GENERATED WIRING FOR SnakeALA.xmind
            // END AUTO-GENERATED WIRING FOR SnakeALA.xmind

            // BEGIN MANUAL INSTANTIATIONS
            // END MANUAL INSTANTIATIONS

            // BEGIN MANUAL WIRING
            // END MANUAL WIRING
        }
    }
}
