using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KukaTrajectory
{
    class Data
    {
        private List<Data_Trajectory> trajectories = new List<Data_Trajectory>();
        private List<Data_Area> areas = new List<Data_Area>();
        private List<Data_Scenario> scenarios = new List<Data_Scenario>();

        public Data()
        {
            load();
        }

        public List<Data_Trajectory> getTrajectories()
        {
            return this.trajectories;
        }
        public void addTrajectory(Data_Trajectory trajectory)
        {
            this.trajectories.Add(trajectory);
        }
        public void removeTrajectory(Data_Trajectory trajectory)
        {
            this.trajectories.Remove(trajectory);
        }
        public void removeTrajectoryID(int id)
        {
            this.trajectories.RemoveAt(id);
        }
        public List<Data_Scenario> getSecnarios()
        {
            return this.scenarios;
        }
        public void addScenario(Data_Scenario scenario)
        {
            this.scenarios.Add(scenario);
        }

        public List<Data_Area> getAreas()
        {
            return this.areas;
        }
        public void addAreas(Data_Area area)
        {
            this.areas.Add(area);
            area.load();
        }
        public void removeAreas(Data_Area area)
        {
            this.areas.Remove(area);
        }
        public void removeAreasID(int id)
        {
            this.areas.RemoveAt(id);
        }

        /* SAVE FILE */
        public void save()
        {
            String data = Newtonsoft.Json.JsonConvert.SerializeObject(dataToDict());
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\Data.dtb"))
            {
                    outputFile.WriteLine(data);
            }
        }
        public void load()
        {
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(mydocpath + @"\Data.dtb"))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line = streamReader.ReadLine();
                if (line != null)
                {
                    var dict = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(line);
                    dictToData(dict);
                }
            }
        }

        public void dictToData(dynamic dict)
        {
            foreach (dynamic a in dict.areas)
            {
                this.addAreas(new Data_Area(a));
            }
            foreach (dynamic t in dict.trajectories)
            {
                this.addTrajectory(new Data_Trajectory(t));
            }
            
            foreach (dynamic s in dict.scenarios)
            {
                this.addScenario(new Data_Scenario(s));
            }
        }

        public List<Data_State> getTrajectoryByName(String name)
        {
            foreach(Data_Trajectory t in this.trajectories)
                if (t.getName().Equals(name))
                    return t.getPath();
            return null;
        }

        public Dictionary<String,Object> dataToDict()
        {
            Dictionary<String, Object> dataDict = new Dictionary<String, Object>();
            List<Dictionary<String, Object>> areaListDict = new List<Dictionary<String, Object>>();
            foreach (Data_Area a in this.areas)
                areaListDict.Add(a.toDict());
            dataDict.Add("areas", areaListDict);
            List<Dictionary<String, Object>> trajectoryListDict = new List<Dictionary<String, Object>>();
            foreach (Data_Trajectory t in this.trajectories)
                trajectoryListDict.Add(t.toDict());
            dataDict.Add("trajectories", trajectoryListDict);
            List<Dictionary<String, Object>> scenarioListDict = new List<Dictionary<String, Object>>();
            foreach (Data_Scenario s in this.scenarios)
                scenarioListDict.Add(s.toDict());
            dataDict.Add("scenarios", scenarioListDict);

            return dataDict;
        }

        public Dictionary<String, Double> transformCartPointToDict(NLX.Robot.Kuka.Controller.CartesianPosition location)
        {
            Dictionary<String, Double> pDict = new Dictionary<String, Double>();
            pDict.Add("X", location.X);
            pDict.Add("Y", location.Y);
            pDict.Add("Z", location.Z);
            pDict.Add("A", location.A);
            pDict.Add("B", location.B);
            pDict.Add("C", location.C);
            return pDict;
        }

        public Data_Area getAreaByName(string areaName)
        {
            foreach (Data_Area d in this.areas)
                if (d.getName().Equals(areaName))
                    return d;
            return null;
        }

        public Data_Scenario getScenario(string scenaName)
        {
            foreach (Data_Scenario d in this.scenarios)
                if (d.getname().Equals(scenaName))
                    return d;
            return null;
        }

    }





}
