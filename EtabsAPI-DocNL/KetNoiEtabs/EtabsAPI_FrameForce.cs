using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtabsAPI_DocNL
{
    public class EtabsAPI_FrameForce
    {

        //field
        //public ObservableCollection<ThongsoDauvao> _dsluc;  //đọc nội lực
        private string _name;
        private int _numberResults;
        private string _obj;
        private double _objSta;
        private string _elm;
        private double _elmSta;
        private string _loadCase;
        private string _stepType;
        private double _stepNum;
        private double _p;
        private double _v2;
        private double _v3;
        private double _t;
        private double _m2;
        private double _m3;


        // thuộc tính
        //public ObservableCollection<ThongsoDauvao> DSluc
        //{
        //    get { return _dsluc; }
        //    set { _dsluc = DSluc; }
        //}
        public string Name  // 
        {
            get { return _name; }
            set { _name = value; }
        }
        public int NumberResults // 
        {
            get { return _numberResults; }
            set { _numberResults = value; }
        }
        public string Obj // 
        {
            get { return _obj; }
            set { _obj = value; }
        }
        public double ObjSta // 
        {
            get { return _objSta; }
            set { _objSta = value; }
        }
        public string Elm // 
        {
            get { return _elm; }
            set { _elm = value; }
        }
        public double ElmSta // 
        {
            get { return _elmSta; }
            set { _elmSta = value; }
        }
        public string LoadCase // 
        {
            get { return _loadCase; }
            set { _loadCase = value; }
        }
        public string StepType // 
        {
            get { return _stepType; }
            set { _stepType = value; }
        }
        public double StepNum // 
        {
            get { return _stepNum; }
            set { _stepNum = value; }
        }
        public double P // 
        {
            get { return _p; }
            set { _p = value; }
        }
        public double V2 // 
        {
            get { return _v2; }
            set { _v2 = value; }
        }
        public double V3 // 
        {
            get { return _v3; }
            set { _v3 = value; }
        }
        public double T // 
        {
            get { return _t; }
            set { _t = value; }
        }
        public double M2// 
        {
            get { return _m2; }
            set { _m2 = value; }
        }
        public double M3 // 
        {
            get { return _m3; }
            set { _m3 = value; }
        }


        // phương thức
        public EtabsAPI_FrameForce(string _name)
        {
            Name = _name;
        }

        public EtabsAPI_FrameForce()
        {
            
        }
    }
}
