using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KukaTrajectory
{

    class Data_Trajectory
    {
        private List<Data_State> path = new List<Data_State>();
        private String name;
        private int id;
        private dynamic t;

        public Data_Trajectory(int id, List<Data_State> states, String name)
        {
            this.id = id;
            this.name = name;
            this.path = states;
        }

        public Data_Trajectory(dynamic t)
        {
            this.id = t.id;
            this.name = t.name;
            foreach(dynamic s in t.path)
            {
                this.path.Add(new Data_State(s));
            }
        }

        public String getName()
        {
            return this.name;
        }
        public List<Data_State> getPath()
        {
            return this.path;
        }
        public void addState(Data_State s)
        {
            this.path.Add(s);
        }
        public void removeState(Data_State s)
        {
            this.path.Remove(s);
        }
        public String toString()
        {
            return this.id + " : name>" + this.name + "  nbPts>" + this.path.Count;
        }

        public Dictionary<String, Object> toDict()
        {
            Dictionary<String, Object> dict = new Dictionary<String, Object>();
            dict.Add("id", this.id);
            dict.Add("name", this.name);
            List<Dictionary<String, Object>> pathDict = new List<Dictionary<string, object>>();
            foreach (Data_State s in this.path)
                pathDict.Add(s.toDict());
            dict.Add("path", pathDict);
            return dict;
        }
    }

}
