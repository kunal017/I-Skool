using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.dataModel
{
    class TodoItem
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string SchoolID { get; set; }
        public string gender { get; set; }
        public string dateofbirth { get; set; }
        public string username { get; set; }
        public string password { get; set; } 
        public string email { get; set; }
        public string phoneno { get; set; }
        public bool eng { get; set; }
        public int engp { get; set; }
        public bool hin { get; set; }
        public int hinp { get; set; }
        public bool math { get; set; }
        public int mathp { get; set; }
        public bool sci { get; set; }
        public int scip { get; set; }
        public bool ss { get; set; }
        public int ssp { get; set; }
        public bool cs { get; set; }
        public int csp { get; set; }
        public int attendance { get; set; }
        public string engc { get; set; }
        public string hinc { get; set; }
        public string mathc { get; set; }
        public string scic { get; set; }
        public string ssc { get; set; }
        public string csc { get; set; }
    }
    class TodoItem2
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string SchoolID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phoneno { get; set; }
        public string message { get; set; }
    }
    class TodoItem3
    {
        public string Name { get; set; }
        public string Course { get; set; }
        public string Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phoneno { get; set; }
    } 
    class TodoItem4
    {
        public string username { get; set; }
        public string password { get; set; }
        public string Id { get; set; }
        public string value { get; set; }
    }
}
