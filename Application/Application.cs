using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            Apply<KeyEventArgs,object> id_94b4d7a7a9d44167b274549f91425e64 = new Apply<KeyEventArgs,object>() { InstanceName = "Default", Lambda = args => { if (args.Key == Key.A) { return "L" as object;} if (args.Key == Key.D) { return "R" as object;} if (args.Key == Key.W) { return "U" as object;} if (args.Key == Key.S) { return "D" as object;} return "" as object;} };
            Cast<object,Vector> id_eee7d6d4227a44d096d1f1f1dbc62fee = new Cast<object,Vector>() { InstanceName = "Default" };
            Data<object> id_14180dadcc5a42299b907ebbe26ecaa5 = new Data<object>() { InstanceName = "Default", storedData = "U" as object };
            DataFlowConnector<object> id_7cc2c7f3a9ba465b917ab80eca883d09 = new DataFlowConnector<object>() { InstanceName = "Default" };
            DataFlowConnector<object> snakeDirection = new DataFlowConnector<object>() { InstanceName = "snakeDirection" };
            EventConnector id_3babe233bb07413086c85807fcc6fff4 = new EventConnector() { InstanceName = "Default" };
            GameScreen id_568c58e3544e4ba1a0d1f0ad64eb4672 = new GameScreen() { InstanceName = "Default" };
            KeyEvent id_4f46cbcb3ae1463f8dcf949245e8e01c = new KeyEvent("KeyDown" ) { InstanceName = "Default" };
            MovingRender snakeHead = new MovingRender() { InstanceName = "snakeHead", Position = new Point(500,500) };
            Operation<object> moveSnake = new Operation<object>() { InstanceName = "moveSnake", Lambda = ops => {var direction = ops[0] as string; var vertScalar = 10; var horizScalar = 10; if (direction == "U") { return new Vector(0,-vertScalar);} else if (direction == "D") { return new Vector(0,vertScalar);} else if (direction == "L") {return new Vector(-horizScalar,0);} else if (direction == "R") {return new Vector(horizScalar,0);} else { return new Vector(0,0);}} };
            Operation<object> validateMovementDirection = new Operation<object>() { InstanceName = "validateMovementDirection", Lambda = ops => {var _set = new HashSet<string> {"U","D","L","R"}; if (_set.Contains(ops[0] as string)) {return ops[0];} else { return ops[1]; } } };
            Timer gameTimer = new Timer() { InstanceName = "gameTimer", Interval = 1.0 / 60 };
            // END AUTO-GENERATED INSTANTIATIONS FOR SnakeALA.xmind

            // BEGIN AUTO-GENERATED WIRING FOR SnakeALA.xmind
            mainWindow.WireTo(id_568c58e3544e4ba1a0d1f0ad64eb4672, "iuiStructure"); // (@MainWindow (mainWindow).iuiStructure) -- [IUI] --> (GameScreen (id_568c58e3544e4ba1a0d1f0ad64eb4672).child)
            mainWindow.WireTo(id_3babe233bb07413086c85807fcc6fff4, "appStart"); // (@MainWindow (mainWindow).appStart) -- [IEvent] --> (EventConnector (id_3babe233bb07413086c85807fcc6fff4).start)
            id_568c58e3544e4ba1a0d1f0ad64eb4672.WireTo(id_4f46cbcb3ae1463f8dcf949245e8e01c, "eventHandlers"); // (GameScreen (id_568c58e3544e4ba1a0d1f0ad64eb4672).eventHandlers) -- [IEventHandler] --> (KeyEvent (id_4f46cbcb3ae1463f8dcf949245e8e01c).eventHandler)
            id_568c58e3544e4ba1a0d1f0ad64eb4672.WireTo(snakeHead, "canvasOutput"); // (GameScreen (id_568c58e3544e4ba1a0d1f0ad64eb4672).canvasOutput) -- [IDataFlow<Canvas>] --> (MovingRender (snakeHead).mainCanvasInput)
            id_4f46cbcb3ae1463f8dcf949245e8e01c.WireTo(id_94b4d7a7a9d44167b274549f91425e64, "argsOutput"); // (KeyEvent (id_4f46cbcb3ae1463f8dcf949245e8e01c).argsOutput) -- [IDataFlow<KeyEventArgs>] --> (Apply<KeyEventArgs,object> (id_94b4d7a7a9d44167b274549f91425e64).input)
            id_4f46cbcb3ae1463f8dcf949245e8e01c.WireTo(validateMovementDirection, "eventHappened"); // (KeyEvent (id_4f46cbcb3ae1463f8dcf949245e8e01c).eventHappened) -- [IEvent] --> (Operation<object> (validateMovementDirection).startOperation)
            id_94b4d7a7a9d44167b274549f91425e64.WireTo(id_7cc2c7f3a9ba465b917ab80eca883d09, "output"); // (Apply<KeyEventArgs,object> (id_94b4d7a7a9d44167b274549f91425e64).output) -- [IDataFlow<object>] --> (DataFlowConnector<object> (id_7cc2c7f3a9ba465b917ab80eca883d09).input)
            validateMovementDirection.WireTo(id_7cc2c7f3a9ba465b917ab80eca883d09, "operands"); // (Operation<object> (validateMovementDirection).operands) -- [IDataFlowB<object>] --> (DataFlowConnector<object> (id_7cc2c7f3a9ba465b917ab80eca883d09).outputsB)
            validateMovementDirection.WireTo(snakeDirection, "operands"); // (Operation<object> (validateMovementDirection).operands) -- [IDataFlowB<object>] --> (@DataFlowConnector<object> (snakeDirection).outputsB)
            validateMovementDirection.WireTo(snakeDirection, "operationResultOutput"); // (Operation<object> (validateMovementDirection).operationResultOutput) -- [IDataFlow<object>] --> (DataFlowConnector<object> (snakeDirection).input)
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
