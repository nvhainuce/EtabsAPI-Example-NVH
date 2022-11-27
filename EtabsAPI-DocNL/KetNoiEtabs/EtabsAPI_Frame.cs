using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace EtabsAPI_DocNL
{
    public class EtabsAPI_Frame
    {
        private int _numberNames;
        private string _label;
        private string _myName;
        private string _propName;
        private string _storyName;
        private string _pointName1;
        private string _pointName2;
        private double _point1X;
        private double _point1Y;
        private double _point1Z;
        private double _point2X;
        private double _point2Y;
        private double _point2Z;
        private double _angle;
        private double _offset1X;
        private double _offset2X;
        private double _offset1Y;
        private double _offset2Y;
        private double _offset1Z;
        private double _offset2Z;
        private int _cardinalPoint;
        private double _length;
     

     
        public int NumberNames
        {
            get
            {
                return _numberNames;
            }
            set
            {
                _numberNames = value;
            }
        }

        public string Label
        {
            get { return _label; }
            set { _label = value; }

        }


        public string MyName
        {
            get { return _myName; }
            set { _myName = value; }

        }

        public string StoryName
        {
            get { return _storyName; }
            set { _storyName = value; }
        }

        public string PropName
        {
            get { return _propName; }
            set { _propName = value; }
        }

        public string PointName1
        {
            get { return _pointName1; }
            set { _pointName1 = value; }
        }

        public string PointName2
        {
            get { return _pointName2; }
            set { _pointName2 = value; }
        }

        public double Point1X
        {
            get { return _point1X; }
            set { _point1X = value; }
        }

        public double Point1Y
        {
            get { return _point1Y; }
            set { _point1Y = value; }
        }

        public double Point1Z
        {
            get { return _point1Z; }
            set { _point1Z = value; }
        }


        public double Point2X
        {
            get { return _point2X; }
            set { _point2X = value; }
        }

        public double Point2Y
        {
            get { return _point2Y; }
            set { _point2Y = value; }
        }

        public double Point2Z
        {
            get { return _point2Z; }
            set { _point2Z = value; }
        }

        public double Angle
        {
            get { return _angle; }
            set { _angle = value; }
        }


        public double Offset1X
        {
            get { return _offset1X; }
            set { _offset1X = value; }
        }


        public double Offset2X
        {
            get { return _offset2X; }
            set { _offset2X = value; }
        }

        public double Offset1Y
        {
            get { return _offset1Y; }
            set { _offset1Y = value; }
        }

        public double Offset2Y
        {
            get { return _offset2Y; }
            set { _offset2Y = value; }
        }

        public double Offset1Z
        {
            get { return _offset1Z; }
            set { _offset1Z = value; }
        }


        public double Offset2Z
        {
            get { return _offset2Z; }
            set { _offset2Z = value; }
        }

        public int CardinalPoint
        {
            get { return _cardinalPoint; }
            set { _cardinalPoint = value; }
        }

        public double Length
        {
            get { return _length; }
            set { _length = value; }
        }

        public void TinhLengthPhantu()
        {
            Length = Math.Sqrt(Math.Pow((Point2X - Point1X), 2) + Math.Pow((Point2Y - Point1Y), 2) + Math.Pow((Point2Z - Point1Z), 2));
        }

    }
}
