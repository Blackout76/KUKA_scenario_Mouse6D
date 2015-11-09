using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KukaTrajectory
{
    class Data_Area
    {
        private NLX.Robot.Kuka.Controller.CartesianPosition p0 = new NLX.Robot.Kuka.Controller.CartesianPosition();
        private NLX.Robot.Kuka.Controller.CartesianPosition p1 = new NLX.Robot.Kuka.Controller.CartesianPosition();
        private NLX.Robot.Kuka.Controller.CartesianPosition p2 = new NLX.Robot.Kuka.Controller.CartesianPosition();
        private NLX.Robot.Kuka.Controller.CartesianPosition p3 = new NLX.Robot.Kuka.Controller.CartesianPosition();
        private String name;
        private bool monoPoint = false;
        private int nbSpotInX;
        private int nbSpotInY;
        private int id;
        private List<List<Data_Stock>> stock = new List<List<Data_Stock>>();

        public Data_Area() { }
        public Data_Area(dynamic a)
        {
            this.id = a.id;
            this.name = a.name;
            this.monoPoint = a.monoPoint;
            this.nbSpotInX = a.nbSpotX;
            this.nbSpotInY = a.nbSpotY;
            this.p0.X = a.p0.X;
            this.p0.Y = a.p0.Y;
            this.p0.Z = a.p0.Z;
            this.p0.A = a.p0.A;
            this.p0.B = a.p0.B;
            this.p0.C = a.p0.C;

            this.p1.X = a.p1.X;
            this.p1.Y = a.p1.Y;
            this.p1.Z = a.p1.Z;
            this.p1.A = a.p0.A;
            this.p1.B = a.p0.B;
            this.p1.C = a.p0.C;

            this.p2.X = a.p2.X;
            this.p2.Y = a.p2.Y;
            this.p2.Z = a.p2.Z;
            this.p2.A = a.p0.A;
            this.p2.B = a.p0.B;
            this.p2.C = a.p0.C;

            this.p3.X = a.p3.X;
            this.p3.Y = a.p3.Y;
            this.p3.Z = a.p3.Z;
            this.p3.A = a.p0.A;
            this.p3.B = a.p0.B;
            this.p3.C = a.p0.C;
            load();
        }

        public Data_Area(Data_Area a)
        {
            this.id = a.getId();
            this.name = a.getName();
            this.monoPoint = a.isMonoPoint();
            this.nbSpotInX = a.getNBSpotX();
            this.nbSpotInY = a.getNBSpotY();
            this.p0.X = a.getP0().X;
            this.p0.Y = a.getP0().Y;
            this.p0.Z = a.getP0().Z;
            this.p0.A = a.getP0().A;
            this.p0.B = a.getP0().B;
            this.p0.C = a.getP0().C;

            this.p1.X = a.getP1().X;
            this.p1.Y = a.getP1().Y;
            this.p1.Z = a.getP1().Z;
            this.p1.A = a.getP1().A;
            this.p1.B = a.getP1().B;
            this.p1.C = a.getP1().C;

            this.p2.X = a.getP2().X;
            this.p2.Y = a.getP2().Y;
            this.p2.Z = a.getP2().Z;
            this.p2.A = a.getP2().A;
            this.p2.B = a.getP2().B;
            this.p2.C = a.getP2().C;

            this.p3.X = a.getP3().X;
            this.p3.Y = a.getP3().Y;
            this.p3.Z = a.getP3().Z;
            this.p3.A = a.getP3().A;
            this.p3.B = a.getP3().B;
            this.p3.C = a.getP3().C;
        }
        public void setId(int id)
        {
            this.id = id;
        }

        public int getId()
        {
            return this.id;
        }
        public void setMonoPoint(bool val)
        {
            this.monoPoint = val;
        }
        public bool isMonoPoint()
        {
            return this.monoPoint;
        }
        public void setName(String name)
        {
            this.name = name;
        }
        public String getName()
        {
            return this.name;
        }
        public void setNB_x(int val)
        {
            this.nbSpotInX = val;
        }
        public int getNBSpotX()
        {
            return this.nbSpotInX;
        }
        public void setNB_y(int val)
        {
            this.nbSpotInY = val;
        }
        public int getNBSpotY()
        {
            return this.nbSpotInY;
        }
        public void setP0(double x, double y, double z, double a, double b, double c)
        {
            p0.X = x;
            p0.Y = y;
            p0.Z = z;
            p0.A = a;
            p0.B = b;
            p0.C = c;
        }
        public NLX.Robot.Kuka.Controller.CartesianPosition getP0()
        {
            return this.p0;
        }
        public void setP1(double x, double y, double z, double a, double b, double c)
        {
            p1.X = x;
            p1.Y = y;
            p1.Z = z;
            p1.A = a;
            p1.B = b;
            p1.C = c;
        }
        public NLX.Robot.Kuka.Controller.CartesianPosition getP1()
        {
            return this.p1;
        }
        public void setP2(double x, double y, double z, double a, double b, double c)
        {
            p2.X = x;
            p2.Y = y;
            p2.Z = z;
            p2.A = a;
            p2.B = b;
            p2.C = c;
        }

        public Data_Stock getBestStockLocationToDrop()
        {
            Data_Stock dsBest = null;
            double bestDist = 0;
            for (int i = 0; i < stock.Count; i++)
            {
                for (int j = 0; j < stock.ElementAt(i).Count; j++)
                {
                    double dist = Math.Sqrt(Math.Pow(stock.ElementAt(i).ElementAt(j).getLocation().X, 2) + Math.Pow(stock.ElementAt(i).ElementAt(j).getLocation().Y, 2));

                    if (dist > bestDist && stock.ElementAt(i).ElementAt(j).isEmpty())
                    {
                        dsBest = stock.ElementAt(i).ElementAt(j);
                        bestDist = dist;
                    }

                }
            }
            return dsBest;
        }
        public Data_Stock getBestStockLocationToPick()
        {
            Data_Stock dsBest = null;
            double bestDist = 0;
            for (int i = 0; i < stock.Count; i++)
            {
                for (int j = 0; j < stock.ElementAt(i).Count; j++)
                {
                    double dist = Math.Sqrt(Math.Pow(stock.ElementAt(i).ElementAt(j).getLocation().X, 2) + Math.Pow(stock.ElementAt(i).ElementAt(j).getLocation().Y, 2));
                    if (dist < bestDist && !stock.ElementAt(i).ElementAt(j).isEmpty())
                    {
                        dsBest = stock.ElementAt(i).ElementAt(j);
                        bestDist = dist;
                    }
                }
            }
            return dsBest;
        }

        public NLX.Robot.Kuka.Controller.CartesianPosition getP2()
        {
            return this.p2;
        }
        public void setP3(double x, double y, double z, double a, double b, double c)
        {
            p3.X = x;
            p3.Y = y;
            p3.Z = z;
            p3.A = a;
            p3.B = b;
            p3.C = c;
        }
        public NLX.Robot.Kuka.Controller.CartesianPosition getP3()
        {
            return this.p3;
        }
        public String toString()
        {
            if(!monoPoint)
                return this.id + " : name>" + this.name + "  size> (" + this.nbSpotInX + ":" + this.nbSpotInY + ")";
            else
                return this.id + " : name>" + this.name + "  size> (1)";
        }

        /* MANIPULATION STOCK */
        public void load()
        {
            this.stock = new List<List<Data_Stock>>();
            if (monoPoint)
            {
                //TODO
                NLX.Robot.Kuka.Controller.CartesianPosition location = new NLX.Robot.Kuka.Controller.CartesianPosition();
                location.X = this.p1.X;
                location.Y = this.p1.Y;
                location.Z = this.p1.Z;
                location.A = this.p1.A;
                location.B = this.p1.B;
                location.C = this.p1.C;

                this.stock.Add(new List<Data_Stock>());
                this.stock.ElementAt(0).Add(new Data_Stock(location));

            }
            else
            {
                double dx = (p2.X - p1.X) / (nbSpotInX - 1);
                double dx2 = (p3.X - p1.X) / (nbSpotInX - 1);
                double dy = (p2.Y - p1.Y) / (nbSpotInY - 1);
                double dy2 = (p3.Y - p1.Y) / (nbSpotInY - 1);
                for (int i = 0; i < nbSpotInX; i++)
                {
                    List<Data_Stock> lstock = new List<Data_Stock>();
                    for (int j = 0; j < nbSpotInY; j++)
                    {
                        NLX.Robot.Kuka.Controller.CartesianPosition location = new NLX.Robot.Kuka.Controller.CartesianPosition();
                        location.X = this.p1.X + (i * dx) + (j * dx2);
                        location.Y = this.p1.Y + (i * dy) + (j * dy2);
                        location.Z = this.p1.Z;
                        location.A = this.p1.A;
                        location.B = this.p1.B;
                        location.C = this.p1.C;
                        lstock.Add(new Data_Stock(location));
                        Console.WriteLine("(" + i + ":" + j +")>" + location.X + ":" + location.Y);
                    }
                    this.stock.Add(lstock);
                    Console.WriteLine("Size added at (" + (this.stock .Count - 1) + "):" + this.stock.ElementAt(i).Count);
                }
            }
        }

        public void addElementAt(int i, int j)
        {
            this.stock.ElementAt(i).ElementAt(j).setEmpty(true);
        }
        public void removeElementAt(int i, int j)
        {
            this.stock.ElementAt(i).ElementAt(j).setEmpty(false);
        }
        public void getFirstFarEmptyStock()
        {
            //TODO
        }

        public Dictionary<String, Object> toDict()
        {
            Dictionary<String, Object> dict = new Dictionary<String, Object>();
            dict.Add("id", this.id);
            dict.Add("name", this.name);
            dict.Add("monoPoint", this.monoPoint);
            dict.Add("nbSpotX", this.nbSpotInX);
            dict.Add("nbSpotY", this.nbSpotInY);
            dict.Add("p0", Program.data.transformCartPointToDict(this.p0));
            dict.Add("p1", Program.data.transformCartPointToDict(this.p1));
            dict.Add("p2", Program.data.transformCartPointToDict(this.p2));
            dict.Add("p3", Program.data.transformCartPointToDict(this.p3));
            return dict;
        }
    }
}
