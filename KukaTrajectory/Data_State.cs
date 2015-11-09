using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KukaTrajectory
{
    class Data_State
    {
        private bool gripper;
        private NLX.Robot.Kuka.Controller.CartesianPosition location;
        private int id;
        private dynamic s;

        public Data_State(int id, double x, double y, double z, double a, double b, double c, bool gripper)
        {
            this.id = id;
            this.gripper = gripper;
            this.location = new NLX.Robot.Kuka.Controller.CartesianPosition();
            this.location.A = a;
            this.location.B = b;
            this.location.C = c;
            this.location.X = x;
            this.location.Y = y;
            this.location.Z = z;
        }

        public Data_State(dynamic s)
        {
            this.id = s.id;
            this.gripper = s.gripper;
            this.location = new NLX.Robot.Kuka.Controller.CartesianPosition();
            this.location.A = s.location.A;
            this.location.B = s.location.B;
            this.location.C = s.location.C;
            this.location.X = s.location.X;
            this.location.Y = s.location.Y;
            this.location.Z = s.location.Z;
        }

        public int getId()
        {
            return this.id;
        }
        public void setId(int val)
        {
            this.id = val;
        }
        public NLX.Robot.Kuka.Controller.CartesianPosition getLocation()
        {
            return this.location;
        }
        public void setLocation(NLX.Robot.Kuka.Controller.CartesianPosition val)
        {
            this.location = val;
        }
        public bool isGripper()
        {
            return this.gripper;
        }
        public void setGripper(bool val)
        {
            this.gripper = val;
        }
        public String ToString()
        {
            if (!this.gripper)
                return this.id + " : [" + this.location.X + ":" + this.location.Y + ":" + this.location.Z + "] [" + this.location.A + ":" + this.location.B + ":" + this.location.C + "] (gripper close)";
            else
                return this.id + " : [" + this.location.X + ":" + this.location.Y + ":" + this.location.Z + "] [" + this.location.A + ":" + this.location.B + ":" + this.location.C + "] (gripper open)";
        }
        public Dictionary<String, Object> toDict()
        {
            Dictionary<String, Object> dict = new Dictionary<String, Object>();
            dict.Add("id", this.id);
            dict.Add("gripper", this.gripper);
            dict.Add("location", Program.data.transformCartPointToDict(this.location));
            return dict;
        }
    }
}
