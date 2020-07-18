using System;
using System.Windows;
using System.Windows.Controls;
using Libraries;
using ProgrammingParadigms;
using DomainAbstractions;
using GALADE.DomainAbstractions;

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
            Cast<object,Vector> id_eee7d6d4227a44d096d1f1f1dbc62fee = new Cast<object,Vector>() { InstanceName = "Default" };
            Data<object> id_14180dadcc5a42299b907ebbe26ecaa5 = new Data<object>() { InstanceName = "Default", storedData = "U" as object };
            DataFlowConnector<object> snakeDirection = new DataFlowConnector<object>() { InstanceName = "snakeDirection" };
            EventConnector id_3babe233bb07413086c85807fcc6fff4 = new EventConnector() { InstanceName = "Default" };
            GameScreen id_568c58e3544e4ba1a0d1f0ad64eb4672 = new GameScreen() { InstanceName = "Default" };
            KeyEvent id_4f46cbcb3ae1463f8dcf949245e8e01c = new KeyEvent("KeyDown" ) { InstanceName = "Default" };
            MovingRender snakeHead = new MovingRender() { InstanceName = "snakeHead", Position = new Point(500,500) };
            Operation<object> moveSnake = new Operation<object>() { InstanceName = "moveSnake", Lambda = ops => {var direction = ops[0] as string; var vertScalar = 10; var horizScalar = 10; if (direction == "U") { return new Vector(0,-vertScalar);} else if (direction == "D") { return new Vector(0,vertScalar);} else if (direction == "L") {return new Vector(-horizScalar,0);} else if (direction == "R") {return new Vector(horizScalar,0);} else { return new Vector(0,0);}} };
            Timer gameTimer = new Timer() { InstanceName = "gameTimer", Interval = 1.0 / 60 };
            // END AUTO-GENERATED INSTANTIATIONS FOR SnakeALA.xmind

            // BEGIN AUTO-GENERATED WIRING FOR SnakeALA.xmind
            mainWindow.WireTo(id_568c58e3544e4ba1a0d1f0ad64eb4672, "iuiStructure"); // (@MainWindow (mainWindow).iuiStructure) -- [IUI] --> (GameScreen (id_568c58e3544e4ba1a0d1f0ad64eb4672).child)
            mainWindow.WireTo(id_3babe233bb07413086c85807fcc6fff4, "appStart"); // (@MainWindow (mainWindow).appStart) -- [IEvent] --> (EventConnector (id_3babe233bb07413086c85807fcc6fff4).start)
            id_568c58e3544e4ba1a0d1f0ad64eb4672.WireTo(id_4f46cbcb3ae1463f8dcf949245e8e01c, "eventHandlers"); // (GameScreen (id_568c58e3544e4ba1a0d1f0ad64eb4672).eventHandlers) -- [IEventHandler] --> (KeyEvent (id_4f46cbcb3ae1463f8dcf949245e8e01c).eventHandler)
            id_568c58e3544e4ba1a0d1f0ad64eb4672.WireTo(snakeHead, "canvasOutput"); // (GameScreen (id_568c58e3544e4ba1a0d1f0ad64eb4672).canvasOutput) -- [IDataFlow<Canvas>] --> (MovingRender (snakeHead).mainCanvasInput)
            id_3babe233bb07413086c85807fcc6fff4.WireTo(gameTimer, "fanoutList"); // (EventConnector (id_3babe233bb07413086c85807fcc6fff4).fanoutList) -- [IEvent] --> (Timer (gameTimer).toggleStartStop)
            id_3babe233bb07413086c85807fcc6fff4.WireTo(id_14180dadcc5a42299b907ebbe26ecaa5, "fanoutList"); // (EventConnector (id_3babe233bb07413086c85807fcc6fff4).fanoutList) -- [IEvent] --> (Data<object> (id_14180dadcc5a42299b907ebbe26ecaa5).start)
            gameTimer.WireTo(moveSnake, "tickHappened"); // (Timer (gameTimer).tickHappened) -- [IEvent] --> (Operation<object> (moveSnake).startOperation)
            moveSnake.WireTo(snakeDirection, "operands"); // (Operation<object> (moveSnake).operands) -- [IDataFlowB<object>] --> (@DataFlowConnector<object> (snakeDirection).outputsB)
            moveSnake.WireTo(id_eee7d6d4227a44d096d1f1f1dbc62fee, "operationResultOutput"); // (Operation<object> (moveSnake).operationResultOutput) -- [IDataFlow<object>] --> (Cast<object,Vector> (id_eee7d6d4227a44d096d1f1f1dbc62fee).input)
            id_eee7d6d4227a44d096d1f1f1dbc62fee.WireTo(snakeHead, "output"); // (Cast<object,Vector> (id_eee7d6d4227a44d096d1f1f1dbc62fee).output) -- [IDataFlow<Vector>] --> (MovingRender (snakeHead).offsetPosition)
            id_14180dadcc5a42299b907ebbe26ecaa5.WireTo(snakeDirection, "dataOutput"); // (Data<object> (id_14180dadcc5a42299b907ebbe26ecaa5).dataOutput) -- [IDataFlow<object>] --> (DataFlowConnector<object> (snakeDirection).input)
            // END AUTO-GENERATED WIRING FOR SnakeALA.xmind

            // BEGIN MANUAL INSTANTIATIONS
            // END MANUAL INSTANTIATIONS

            // BEGIN MANUAL WIRING
            mainWindow.WireTo(new GameScreen());
            // END MANUAL WIRING
        }
    }
}
