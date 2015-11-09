using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KukaTrajectory
{
    class Data_Stock
    {
        private NLX.Robot.Kuka.Controller.CartesianPosition location = new NLX.Robot.Kuka.Controller.CartesianPosition();
        private bool empty = true;

        public Data_Stock(NLX.Robot.Kuka.Controller.CartesianPosition loc)
        {
            location.X = loc.X;
            location.Y = loc.Y;
            location.Z = loc.Z;
            location.A = loc.A;
            location.B = loc.B;
            location.C = loc.C;
        }
        public void setEmpty(bool val)
        {
            this.empty = val;
        }
        public bool isEmpty()
        {
            return this.empty;
        }
        public NLX.Robot.Kuka.Controller.CartesianPosition getLocation()
        {
            return this.location;
        }
    }
}
