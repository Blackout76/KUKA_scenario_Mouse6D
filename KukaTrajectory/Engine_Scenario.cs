using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KukaTrajectory
{
    class Engine_Scenario
    {
        private Data_Scenario currentScenario;
        private Dictionary<String, Object> currentAction;
        private int currentStage = -1;
        private bool isStageFinished = true;
        private bool isJobFinished = false;
        private bool areaStageTmp1 = false;
        private bool areaStageTmp2 = false;
        private List<NLX.Robot.Kuka.Controller.CartesianPosition> locations1 = new List<NLX.Robot.Kuka.Controller.CartesianPosition>();
        private List<NLX.Robot.Kuka.Controller.CartesianPosition> locations2 = new List<NLX.Robot.Kuka.Controller.CartesianPosition>();


        public void startScenario(String scenaName)
        {
            if (currentScenario == null)
            {
                this.currentScenario = Program.data.getScenario(scenaName);
                if (currentScenario != null)
                    start();
            }
            else
                Console.WriteLine("Cant start a new scenario. A current scenario is running !");

        }

        private void start()
        {
            Console.WriteLine("Launch scenario : " + currentScenario.getname());
            Thread ihmEngineThread = new Thread(new ThreadStart(run));
            ihmEngineThread.Start();
        }

        private void run()
        {
            isJobFinished = false;
            loadNextStage(0);
            while (!isJobFinished)
            {
                System.Threading.Thread.Sleep(100);
                isStageFinished = checkFinishedStage();
                if (isStageFinished)
                    loadNextStage(currentStage + 1);
            }
            this.currentStage = -1;
            this.currentScenario = null;
            Console.WriteLine("Job finished !");
        }

        private bool checkFinishedStage()
        {
            if (this.currentAction["action"].ToString().Equals("stock"))
                return checkStockAction();
            else if (this.currentAction["action"].ToString().Equals("moveTrajectory"))
                return checkMoveAction();
            else if (this.currentAction["action"].ToString().Equals("gripper"))
            {
                return checkGripperAction();
            }
            else
                return false;
        }
        private void loadNextStage(int stageID)
        {
            if (currentStage >= this.currentScenario.getActions().Count - 1)
                isJobFinished = true;
            else
            {
                currentStage = stageID;
                isStageFinished = false;
                this.currentAction = this.currentScenario.getActions().ElementAt(currentStage);
                Console.WriteLine("Loaded next stage: " + this.currentAction["action"]);
                if (this.currentAction["action"].ToString().Equals("stock"))
                    launchStockAction();
                else if (this.currentAction["action"].ToString().Equals("moveTrajectory"))
                    launchMoveAction();
                else if (this.currentAction["action"].ToString().Equals("gripper")) {
                        launchGripperAction();
                    }
            }
        }
        private void launchMoveAction()
        {
            List<Data_State> states = Program.data.getTrajectoryByName(this.currentAction["trajectoryName"].ToString());
            Program.robot.clearTrajectory();
            foreach (Data_State s in states)
                Program.robot.addCartesianPointToTrajectory(s.getLocation());
            Program.robot.sendTrajectory();
        }
        private bool checkMoveAction()
        {
            double xrobot = Program.robot.getLocation().X;
            double yrobot = Program.robot.getLocation().Y;
            double zrobot = Program.robot.getLocation().Z;
            double xLocation = Program.data.getTrajectoryByName(this.currentAction["trajectoryName"].ToString()).ElementAt(Program.data.getTrajectoryByName(this.currentAction["trajectoryName"].ToString()).Count - 1).getLocation().X;
            double yLocation = Program.data.getTrajectoryByName(this.currentAction["trajectoryName"].ToString()).ElementAt(Program.data.getTrajectoryByName(this.currentAction["trajectoryName"].ToString()).Count - 1).getLocation().Y;
            double zLocation = Program.data.getTrajectoryByName(this.currentAction["trajectoryName"].ToString()).ElementAt(Program.data.getTrajectoryByName(this.currentAction["trajectoryName"].ToString()).Count - 1).getLocation().Z;
            if (Math.Sqrt(Math.Pow(xLocation - xrobot, 2) + Math.Pow(yLocation - yrobot, 2) + Math.Pow(zLocation - zrobot, 2)) < 5)
                return true;
            else
                return false;
        }
        private void launchStockAction()
        {
            locations1.Clear();
            locations2.Clear();
            areaStageTmp1 = false;
            areaStageTmp2 = false;
            Data_Area area = Program.data.getAreaByName(this.currentAction["area"].ToString());

            locations1.Add(area.getP0());

            if (this.currentAction["stockType"].ToString().Equals("drop"))
            {
                Data_Stock stockLocation =  area.getBestStockLocationToDrop();
                stockLocation.setEmpty(false);
                NLX.Robot.Kuka.Controller.CartesianPosition posUp = new NLX.Robot.Kuka.Controller.CartesianPosition(stockLocation.getLocation());
                posUp.Z = area.getP0().Z;
                NLX.Robot.Kuka.Controller.CartesianPosition posDown = new NLX.Robot.Kuka.Controller.CartesianPosition(stockLocation.getLocation());
                locations1.Add(posUp);
                locations1.Add(posDown);
                locations2.Add(posUp);
                locations2.Add(area.getP0());

            }
            else if (this.currentAction["stockType"].ToString().Equals("pick"))
            {
                Program.robot.openGripper();
                Data_Stock stockLocation = area.getBestStockLocationToPick();
                stockLocation.setEmpty(true);
                NLX.Robot.Kuka.Controller.CartesianPosition posUp = new NLX.Robot.Kuka.Controller.CartesianPosition(stockLocation.getLocation());
                posUp.Z = area.getP0().Z;
                NLX.Robot.Kuka.Controller.CartesianPosition posDown = new NLX.Robot.Kuka.Controller.CartesianPosition(stockLocation.getLocation());

                locations1.Add(posUp);
                locations1.Add(posDown);
                locations2.Add(posUp);
                locations2.Add(area.getP0());
                stockLocation.setEmpty(true);
            }
            Program.robot.clearTrajectory();
            foreach (NLX.Robot.Kuka.Controller.CartesianPosition pos in locations1)
                Program.robot.addCartesianPointToTrajectory(pos);
            Program.robot.sendTrajectory();

        }
        private bool checkStockAction()
        {
            if (!areaStageTmp1)
            {
                double xrobot = Program.robot.getLocation().X;
                double yrobot = Program.robot.getLocation().Y;
                double zrobot = Program.robot.getLocation().Z;
                double xLocation = locations1.ElementAt(locations1.Count - 1).X;
                double yLocation = locations1.ElementAt(locations1.Count - 1).Y;
                double zLocation = locations1.ElementAt(locations1.Count - 1).Z;
                if (Math.Sqrt(Math.Pow(xLocation - xrobot, 2) + Math.Pow(yLocation - yrobot, 2) + Math.Pow(zLocation - zrobot, 2)) < 5)
                {
                    areaStageTmp1 = true;
                    if (this.currentAction["stockType"].ToString().Equals("drop"))
                        Program.robot.openGripper();
                    else if (this.currentAction["stockType"].ToString().Equals("pick"))
                        Program.robot.closeGripper();

                    Program.robot.clearTrajectory();
                    foreach (NLX.Robot.Kuka.Controller.CartesianPosition pos in locations2)
                        Program.robot.addCartesianPointToTrajectory(pos);
                    Program.robot.sendTrajectory();
                }
            }
            else
            {
                double xrobot = Program.robot.getLocation().X;
                double yrobot = Program.robot.getLocation().Y;
                double zrobot = Program.robot.getLocation().Z;
                double xLocation = locations2.ElementAt(locations2.Count - 1).X;
                double yLocation = locations2.ElementAt(locations2.Count - 1).Y;
                double zLocation = locations2.ElementAt(locations2.Count - 1).Z;
                if (Math.Sqrt(Math.Pow(xLocation - xrobot, 2) + Math.Pow(yLocation - yrobot, 2) + Math.Pow(zLocation - zrobot, 2)) < 5)
                {
                    areaStageTmp2 = true;
                }
            }
            if (areaStageTmp1 && areaStageTmp2)
                return true;
            else
                return false;
        }
        private void launchGripperAction()
        {
            if (this.currentAction["type"].ToString().Equals("open"))
            {
                Program.robot.openGripper();
            }
            else if (this.currentAction["type"].ToString().Equals("close"))
            {
                Program.robot.closeGripper();
            }
        }
        private bool checkGripperAction()
        {
            if ((this.currentAction["type"].ToString().Equals("open") && Program.robot.getGripper()) ||
                (this.currentAction["type"].ToString().Equals("close") && !Program.robot.getGripper()))
                return true;
            else
                return false;
        }

    }

}


/*
if(act.action == "stock")
                {
                    action.Add("action", act.action);
                    action.Add("area", act.area);
                    action.Add("stockType", act.stockType);
                    action.Add("id", act.id);
                }
                else if (act.action == "moveTrajectory")
                {
                    action.Add("action", act.action);
                    action.Add("trajectoryName", act.trajectoryName);
                    action.Add("id", act.id);
                }
                else if (act.action == "gripper")
                {
                    action.Add("action", act.action);
                    action.Add("type", act.type);
                    action.Add("id", act.id);
                }
*/
