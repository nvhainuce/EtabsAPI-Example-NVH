using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETABSv17;
namespace EtabsAPI_DocNL
{
    public class EtabsAPI_TietdienFrame  //thuộc tính đọc tiếp diện
    {
        private int _numberNames;
        private string _myName;
        private eFramePropType _propType;
        private double _t3;
        private double _t2;
        private double _tf;
        private double _tw;
        private double _t2b;
        private double _tfb;

        public int NumberNames
        {
            get 
            {
                return  _numberNames;
            }
            set
            {
                _numberNames = value;
            }
        }

        public string MyName
        {
            get
            {
                return _myName;
            }
            set
            {
                _myName = value;
            }

        }

        public eFramePropType ReFramePropType
        {
            get
            {
                return _propType;
            }
            set
            {
                _propType = value;
            }
        }

        public double T3
        {
            get
            {
                return _t3;
            }
            set
            {
                _t3 = value;
            }

        }

        public double T2
        {
            get
            {
                return _t2;
            }
            set
            {
                _t2 = value;
            }

        }

        public double Tf
        {
            get
            {
                return _tf;
            }
            set
            {
                _tf = value;
            }

        }

        public double TW
        {
            get
            {
                return _tw;
            }
            set
            {
                _tw = value;
            }

        }

        public double T2b
        {
            get
            {
                return _t2b;
            }
            set
            {
                _t2b = value;
            }

        }

        public double Tfb
        {
            get
            {
                return _tfb;
            }
            set
            {
                _tfb = value;
            }

        }

        

    }
}
