using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.ObjectModel;

namespace EtabsAPI_DocNL
{
    public class PhantuKhung
    {
        // field
        
        private string _name;  
        private string _uniquename;
        private double _outputCase;
        private double _stepType;
        private EtabsAPI_Frame _frame;
        private ObservableCollection<EtabsAPI_FrameForce> _frameforces; //danh sách nội lực theo mặt cắt
        private EtabsAPI_TietdienFrame _tietdienFrame;

        
        // property
        public ObservableCollection<EtabsAPI_FrameForce> FrameForces
        {
            get { return _frameforces; }
            set { _frameforces = value; }
        }
        public EtabsAPI_Frame Frame
        {
            get { return _frame; }
            set { _frame = value; }
        }
       

   
        public EtabsAPI_TietdienFrame TietdienFrame
        {
            get { return _tietdienFrame; }
            set { _tietdienFrame = value; }
        }

        public string Name  
        {
            get { return _name; }
            set { _name = value; }
        }
      
        
        public string Uniquename       //Số hiệu 
        {
            get { return _uniquename; }
            set { _uniquename = value; }
        }

        public double OutputCase       //ComBo lực
        {
            get { return _outputCase; }
            set { _outputCase = value; }
        }

        public double StepType
        {
            get { return _stepType; }
            set { _stepType = value; }
        }
        

        
        //Constructor - phương thức khởi tạo ban đầu
        public PhantuKhung(EtabsAPI_Frame EtabsAPI_Frame)
        {
            Frame = EtabsAPI_Frame;
            
            FrameForces = new ObservableCollection<EtabsAPI_FrameForce>();
          
            TietdienFrame = new EtabsAPI_TietdienFrame();
        }

        public PhantuKhung( )
        {
        }
            //method - hàm sử dụng 

            //Viết hàm ktra chịu lực 

            public void KiemTraChiuLuc()
        {
           

        }

    }
}
