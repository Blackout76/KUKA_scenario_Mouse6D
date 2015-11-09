using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KukaTrajectory
{

    class Robot
    {
        private bool fakeRobot = false;
        private bool connected = false;
        private float defaultIncrementSpeed = 1f;
        private float defaultIncrementRot = 0.5f;
        private float speedMotion = 5f;
        private float speedRotMotion = 2f;
        private NLX.Robot.Kuka.Controller.RobotController controller;
        List<NLX.Robot.Kuka.Controller.CartesianPosition> trajectory;

        public Robot()
        {
            controller = new NLX.Robot.Kuka.Controller.RobotController();
            connect();
        
        }
        public void connect()
        {
            controller.Connect("192.168.1.1");
            if (!fakeRobot)
            {
                try
                {
                    controller.GetCurrentPosition();
                    connected = true;
                    controller.StartRelativeMovement();
                    Console.WriteLine("Robot Connected !");
                    Console.WriteLine("Robot start Cposition: [ " + controller.GetCurrentPosition().X + ";" + controller.GetCurrentPosition().Y + ";" + controller.GetCurrentPosition().Z + "]");
                    Console.WriteLine("Robot start Cplan: [ " + controller.GetCurrentPosition().A + ";" + controller.GetCurrentPosition().B + ";" + controller.GetCurrentPosition().C + "]");
                }
                catch (Exception e)
                {
                    connected = false;
                    Console.WriteLine("Cant connect !");
                }
            }
            
        }


        /**
        *   Robot informations
        **/
        public bool isConnected()
        {
            return connected;
        }
        public NLX.Robot.Kuka.Controller.CartesianPosition getLocation()
        {
            if (connected)
            {
                return this.controller.GetCurrentPosition();
            }
            else
                return null;
        }
        public void incrementSpeed()
        {
            this.speedMotion += defaultIncrementSpeed;
        }
        public void decrementSpeed()
        {
            this.speedMotion -= defaultIncrementSpeed;
            if (this.speedMotion < 0)
                this.speedMotion = 0;
        }
        public void incrementRot()
        {
            this.speedRotMotion += defaultIncrementRot;
        }
        public void decrementRot()
        {
            this.speedRotMotion -= defaultIncrementRot;
            if (this.speedRotMotion < 0)
                this.speedRotMotion = 0;
        }
        public float getSpeed()
        {
            return this.speedMotion;
        }
        public float getRotSpeed()
        {
            return this.speedRotMotion;
        }

        /**
        *   Robot actions
        **/
        public void stop()
        {
            if (connected)
                controller.StopRelativeMovement();
        }
        public void start()
        {
            if(connected)
                controller.StartRelativeMovement();
        }
        public bool getGripper()
        {
            controller.StopRelativeMovement();
            return controller.IsGripperOpen();
            controller.StartRelativeMovement();
        }
        public void swapGripper()
        {
            controller.StopRelativeMovement();
            if (connected) {
                if (!controller.IsGripperOpen())
                    openGripper();
                else
                    closeGripper();
            }

        }
        public void openGripper()
        {
            Console.WriteLine("gne4");
            controller.StopRelativeMovement();
            if (connected)
                controller.OpenGripper();
            controller.StartRelativeMovement();
        }
        public void closeGripper()
        {
            Console.WriteLine("gne3");
            controller.StopRelativeMovement();
            if (connected)
                controller.CloseGripper();
            controller.StartRelativeMovement();
        }

        public void translateRelative(NLX.Robot.Kuka.Controller.CartesianPosition mouvement)
        {
            if (connected)
                controller.SetRelativeMovement(mouvement);
        }

        public void goToPoint(NLX.Robot.Kuka.Controller.CartesianPosition mouvement)
        {
            if (connected)
            {
                NLX.Robot.Kuka.Controller.CartesianPosition cartPos = new NLX.Robot.Kuka.Controller.CartesianPosition();

                cartPos.A = controller.GetCurrentPosition().A + mouvement.A;
                cartPos.B = controller.GetCurrentPosition().B + mouvement.B;
                cartPos.C = controller.GetCurrentPosition().C + mouvement.C;

                cartPos.X = controller.GetCurrentPosition().X + mouvement.X;
                cartPos.Y = controller.GetCurrentPosition().Y + mouvement.Y;
                cartPos.Z = controller.GetCurrentPosition().Z + mouvement.Z;

                clearTrajectory();
                addCartesianPointToTrajectory(cartPos);
                sendTrajectory();
            }
        }

        /**
        *   Trajectory manipulation
        **/
        public void clearTrajectory()
        {
            trajectory = new List<NLX.Robot.Kuka.Controller.CartesianPosition>();
        }
        public void addCartesianPointToTrajectory(NLX.Robot.Kuka.Controller.CartesianPosition pos)
        {
            trajectory.Add(pos);
        }
        public void sendTrajectory()
        {
            controller.StopRelativeMovement();
            controller.PlayTrajectory(trajectory);
        }

    }
}
