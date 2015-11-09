using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KukaTrajectory
{
    class Mouse3D
    {
        private TDx.TDxInput.Device device;
        private NLX.Robot.Kuka.Controller.CartesianPosition lastMouvement;
        private float MIN_rotValue = 0f;
        private float MIN_mouvValue = 0f;

        public Mouse3D()
        {
            connect();
            Thread ihmEngineThread = new Thread(new ThreadStart(Update));
            ihmEngineThread.Start();
        }
        public void connect()
        {
            device = new TDx.TDxInput.Device();
            device.Connect();
        }
        public void Update()
        {
            //double xMax = 0, yMax = 0, zMax = 0, aMax = 0, bMax = 0, cMax = 0;
            double xMax = 2047, yMax = 2189, zMax = 948, aMax = 2062, bMax = 2062, cMax = 2062;

            while (true)
            {

                if (device.IsConnected)
                {
                    System.Threading.Thread.Sleep(100);
                    NLX.Robot.Kuka.Controller.CartesianPosition currentMouvement = new NLX.Robot.Kuka.Controller.CartesianPosition();
                    
                    if (device.Keyboard.IsKeyDown(15))
                        Console.WriteLine("gneeeeeeeeeeeee");
                    //Program.robot.swapGripper();

                    // WITHOUT DOMINANT CONFIG
                    /* TEST 1  MAX calibrage*/
                    /*
                    // ROTATION 
                    if (Math.Abs(device.Sensor.Rotation.X) > aMax)
                        aMax = Math.Abs(device.Sensor.Rotation.X);
                    if (Math.Abs(device.Sensor.Rotation.Y) > bMax)
                        bMax = Math.Abs(device.Sensor.Rotation.Y);
                    if (Math.Abs(device.Sensor.Rotation.Z) > cMax)
                        cMax = Math.Abs(device.Sensor.Rotation.Z);

                    // TRANSLATION 
                    if (Math.Abs(device.Sensor.Translation.Z) > xMax)
                        xMax = Math.Abs(device.Sensor.Translation.X);
                    if (Math.Abs(device.Sensor.Translation.Y) > yMax)
                        yMax = Math.Abs(device.Sensor.Translation.Y);
                    if (Math.Abs(device.Sensor.Translation.Z) > zMax)
                        zMax = Math.Abs(device.Sensor.Translation.Z);
                        */
                    //Console.WriteLine("MAX: (x:" + xMax + ")(y:" + yMax + ")(z:" + zMax + ")(A:" + aMax + ")(B:" + bMax + ")(C:" + cMax + ")");
                    //Console.WriteLine("MAX: (x:" + device.Sensor.Translation.X + ")(y:" + device.Sensor.Translation.Y + ")(z:" + device.Sensor.Translation.Z + ")(A:" + device.Sensor.Rotation.X + ")(B:" + device.Sensor.Rotation.Y + ")(C:" + device.Sensor.Rotation.Z + ")");

                    /* TEST 2 pourcentage*/
                    /*
                    double px = Math.Abs(Math.Round((device.Sensor.Translation.X / xMax) * 100)/100);
                    double py = Math.Abs(Math.Round((device.Sensor.Translation.Y / yMax) * 100)/ 100);
                    double pz = Math.Abs(Math.Round((device.Sensor.Translation.Z / zMax) * 100)/ 100);

                    double pa = Math.Abs(Math.Round((device.Sensor.Rotation.X / aMax) * 100)/ 100);
                    double pb = Math.Abs(Math.Round((device.Sensor.Rotation.Y / bMax) * 100)/ 100);
                    double pc = Math.Abs(Math.Round((device.Sensor.Rotation.Z / cMax) * 100)/ 100);

                    //Console.WriteLine("MAX: (x:" + px + ")(y:" + py + ")(z:" + pz + ")(A:" + pa + ")(B:" + pb + ")(C:" + pc + ")");

                    if (px > 0.3 && px > py && px > pz)
                        currentMouvement.X = Math.Round((device.Sensor.Translation.X / xMax) * 1000) / 1000;
                    else if (py > 0.3 && py > px && py > pz)
                        currentMouvement.Y = Math.Round((device.Sensor.Translation.Y / yMax) * 1000) / 1000;
                    else if (pz > 0.3 && pz > px && pz > py)
                        currentMouvement.Z = Math.Round((device.Sensor.Translation.Z / zMax) * 1000) / 1000;

                    else if (pa > pb && pa > pc)
                        currentMouvement.A = Math.Round((device.Sensor.Rotation.X / aMax) * 1000) / 1000;
                    else if (pb > pa && pb > pc)
                        currentMouvement.B = Math.Round((device.Sensor.Rotation.Y / bMax) * 1000) / 1000;
                    else if (pc > pa && pc > pb)
                        currentMouvement.C = Math.Round((device.Sensor.Rotation.Z / cMax) * 1000) / 1000;


                    //Console.WriteLine("CurrentMouvement: (x:" + currentMouvement.X + ")(y:" + currentMouvement.Y + ")(z:" + currentMouvement.Z + ")(A:" + currentMouvement.A + ")(B:" + currentMouvement.B + ")(C:" + currentMouvement.C + ")");
                    */
                    
                    // WITH DOMINANT CONFIG
                    currentMouvement.X = Math.Round((device.Sensor.Translation.X / xMax) * 1000) / 1000;
                    currentMouvement.Y = Math.Round((device.Sensor.Translation.Y / yMax) * 1000) / 1000;
                    currentMouvement.Z = Math.Round((device.Sensor.Translation.Z / zMax) * 1000) / 1000;
                    currentMouvement.A = Math.Round((device.Sensor.Rotation.X * device.Sensor.Rotation.Angle / aMax) * 1000) / 1000;
                    currentMouvement.B = Math.Round((device.Sensor.Rotation.Y * device.Sensor.Rotation.Angle / bMax) * 1000) / 1000;
                    currentMouvement.C = Math.Round((device.Sensor.Rotation.Z * device.Sensor.Rotation.Angle / cMax) * 1000) / 1000;
                    

                    if (lastMouvement != null)
                    {
                        if (currentMouvement.A != lastMouvement.A ||
                                                currentMouvement.B != lastMouvement.B ||
                                                currentMouvement.C != lastMouvement.C ||
                                                currentMouvement.X != lastMouvement.X ||
                                                currentMouvement.Y != lastMouvement.Y ||
                                                currentMouvement.Z != lastMouvement.Z)
                        {
                            Console.WriteLine("CurrentMouvement: (x:" + currentMouvement.X + ")(y:" + currentMouvement.Y + ")(z:" + currentMouvement.Z + ")(A:" + currentMouvement.A + ")(B:" + currentMouvement.B + ")(C:" + currentMouvement.C + ")");

                            changeLocation(currentMouvement);
                        }
                    }
                    else
                    {
                        lastMouvement = new NLX.Robot.Kuka.Controller.CartesianPosition();
                        changeLocation(currentMouvement);
                    }
                }

            }
        }
        public void changeLocation(NLX.Robot.Kuka.Controller.CartesianPosition currentMouvement)
        {
            lastMouvement.A = currentMouvement.A;
            lastMouvement.B = currentMouvement.B;
            lastMouvement.C = currentMouvement.C;
            lastMouvement.X = currentMouvement.X;
            lastMouvement.Y = currentMouvement.Y;
            lastMouvement.Z = currentMouvement.Z;

            NLX.Robot.Kuka.Controller.CartesianPosition posRelRobot = new NLX.Robot.Kuka.Controller.CartesianPosition();
            
            posRelRobot.A = lastMouvement.A * Program.robot.getRotSpeed(); // B
            posRelRobot.B = lastMouvement.C * Program.robot.getRotSpeed(); // C
            posRelRobot.C = lastMouvement.B * Program.robot.getRotSpeed(); // A
            posRelRobot.X = -lastMouvement.Z * Program.robot.getSpeed();
            posRelRobot.Y = -lastMouvement.X * Program.robot.getSpeed();
            posRelRobot.Z = lastMouvement.Y * Program.robot.getSpeed();
            //Console.WriteLine("[" + posRelRobot.A + ":" + posRelRobot.B + ":" + posRelRobot.C + "]   [" + posRelRobot.X + ":" + posRelRobot.Y + ":" + posRelRobot.Z + "]");
            Program.robot.translateRelative(posRelRobot);
        }
    }
}
