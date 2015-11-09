using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KukaTrajectory
{
    class Data_Scenario
    {
        private List<Dictionary<String, Object>> actions = new List<Dictionary<string, object>>();
        private String name;
        private int id;

        public Data_Scenario(dynamic s)
        {
            Console.WriteLine(s.actions);
            this.id = s.id;
            this.name = s.name;
            foreach (dynamic act in s.actions)
            {
                Dictionary<String, Object> action = new Dictionary<string, object>();
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
                this.actions.Add(action);
            }
        }

        public Data_Scenario()
        {

        }

        public void addAction(Dictionary<String, Object> action)
        {
            this.actions.Add(action);
        }
        public List<Dictionary<String, Object>> getActions()
        {
            return this.actions;
        }
        public int getId()
        {
            return this.id;
        }
        public void setID(int id)
        {
            this.id = id;
        }
        public String getname()
        {
            return this.name;
        }
        public void setName(String name)
        {
            this.name = name;
        }

        public Dictionary<String, Object> toDict()
        {
            Dictionary<String, Object> dict = new Dictionary<String, Object>();
            dict.Add("id", this.id);
            dict.Add("name", this.name);
            dict.Add("actions", this.actions);
            return dict;
        }

        internal void setActions(List<Dictionary<string, object>> actions)
        {
            this.actions = actions;
        }
    }
    
}
