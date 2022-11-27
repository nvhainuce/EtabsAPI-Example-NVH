using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETABSv17;

namespace EtabsAPI_DocNL
{
    public static class EtabsAPI_Ctrinhcon
    {
        public static void DocETABSAPI_GetallFrame()
        {
            string trangthai = "";
            cSapModel SapModel;
            cOAPI EtabsObject;

            //danh sách biến của getallframe
            int ret = -1;
            int NumberNames = 0;
            string[] MyName = { };

            string[] PropName = { };

            string[] StoryName = { };

            string[] PointName1 = { };

            string[] PointName2 = { };

            double[] Point1X = { };

            double[] Point1Y = { };

            double[] Point1Z = { };

            double[] Point2X = { };

            double[] Point2Y = { };

            double[] Point2Z = { };

            double[] Angle = { };

            double[] Offset1X = { };

            double[] Offset2X = { };

            double[] Offset1Y = { };

            double[] Offset2Y = { };

            double[] Offset1Z = { };

            double[] Offset2Z = { };

            int[] CardinalPoint = { };

            string csys = "Global";

            //danh sách biến của GetLableNameList
            int NumberNames2 = 0;
            string[] MyName2 = { };
            string[] MyLabel2 = { };
            string[] MyStory2 = { };

            //Khởi tạo Etabs Object
            //EtabsObject = CreateObject("CSI.ETABS.API.ETABSObject");
            EtabsObject = null;

            // TƯơng tác với Etabs
            try
            {
                //Lấy Etabs Object đang hoạt động
                EtabsObject = (ETABSv17.cOAPI)System.Runtime.InteropServices.Marshal.GetActiveObject("CSI.ETABS.API.ETABSObject");
                //mô hinh Sapmodel
                SapModel = EtabsObject.SapModel;

                //Đặt đơn vị cho mô hình
                SapModel.SetPresentUnits(eUnits.kN_m_C);

                //GetAllFrames - lấy toàn bộ thông tin phần tử Thanh
                ret = SapModel.FrameObj.GetAllFrames(ref NumberNames, ref MyName, ref PropName, ref StoryName, ref PointName1, ref PointName2, ref Point1X, ref Point1Y, ref Point1Z, ref Point2X, ref Point2Y, ref Point2Z,
                                                     ref Angle, ref Offset1X, ref Offset2X, ref Offset1Y, ref Offset2Y, ref Offset1Z, ref Offset2Z, ref CardinalPoint);

                ret = SapModel.FrameObj.GetLabelNameList(ref NumberNames2, ref MyName2, ref MyLabel2, ref MyStory2);


                //Đưa thông tin tin vừa đọc vào đối tượng Etabs_Frame
                for (int i = 0; i < (NumberNames - 1); i++)
                {
                    //1.lấy từng thông tin của đối tượng  Frame một trong Etabs API
                    //khởi tạo đối tượng _frame
                    EtabsAPI_Frame _frame = new EtabsAPI_Frame();
                    //gán giá trị thuộc tính vào trong đối tượng frame
                    _frame.MyName = MyName[i];
                    _frame.Label = MyLabel2[i];
                    _frame.PropName = PropName[i];
                    _frame.StoryName = StoryName[i];
                    _frame.PointName1 = PointName1[i];
                    _frame.PointName2 = PointName2[i];
                    _frame.Point1X = Point1X[i];
                    _frame.Point1Y = Point1Y[i];
                    _frame.Point1Z = Point1Z[i];
                    _frame.Point2X = Point2X[i];
                    _frame.Point2Y = Point2Y[i];
                    _frame.Point2Z = Point2Z[i];
                    _frame.Angle = Angle[i];
                    _frame.Offset1X = Offset1X[i];
                    _frame.Offset2X = Offset2X[i];
                    _frame.Offset1Y = Offset1Y[i];
                    _frame.Offset2Y = Offset2Y[i];
                    _frame.Offset1Z = Offset1Z[i];
                    _frame.Offset2Z = Offset2Z[i];
                    _frame.CardinalPoint = CardinalPoint[i];
                    _frame.TinhLengthPhantu();

                    PhantuKhung _khung = new PhantuKhung(_frame);
                    //4.Lưu đối tượng Frame ở trên vào Danh sách đối tượng EtabsAPI_Frames
                    Class_BienToanCuc.DanhsachPhantuKhung.Add(_khung);
                }
                
               

               

                trangthai =("Lấy thông tin phần tử thanh thành công");
            }
            catch (Exception ex)
            {
                trangthai=("Không tìm thấy chương trình Etabs nào đang hoạt động.");
                return;
            }
        }

        public static void DocETABSAPI_FrameForce()
        {
            cSapModel SapModel;
            cOAPI EtabsObject;
            int ret = -1;
            int NumberResults = 0;
            string[] Obj = { };
            double[] ObjSta = { };
            string[] Elm = { };
            double[] ElmSta = { };
            string[] LoadCase = { };
            string[] StepType = { };
            double[] StepNum = { };
            double[] P = { };
            double[] V2 = { };
            double[] V3 = { };
            double[] T = { };
            double[] M2 = { };
            double[] M3 = { };
            // create ETABS object - Tạo đối tượng
            EtabsObject = (ETABSv17.cOAPI)System.Runtime.InteropServices.Marshal.GetActiveObject("CSI.ETABS.API.ETABSObject");

            SapModel = EtabsObject.SapModel;

            //Đặt đơn vị cho mô hình
            SapModel.SetPresentUnits(eUnits.kN_m_C);

            // deselect all cases and combos - Bỏ chọn tất cả các Cases và Combos
            ret = SapModel.Results.Setup.DeselectAllCasesAndCombosForOutput();

            // set case selected for output - Đặt trường hợp được chọn cho đầu ra
            ret = SapModel.Results.Setup.SetCaseSelectedForOutput("HT+TT");

            SapModel.Results.Setup.SetComboSelectedForOutput("BAO");

            // get frame forces - Lấy lực từ khung 
            foreach (PhantuKhung _khung in Class_BienToanCuc.DanhsachPhantuKhung)
            {
                //lấy nội lực với combo "BAO" tại tất cả các mặt cắt của dầm có _dam.Frame.MyName
                ret = SapModel.Results.FrameForce(_khung.Frame.MyName, eItemTypeElm.ObjectElm, ref NumberResults, ref Obj, ref ObjSta, ref Elm, ref ElmSta, ref LoadCase, ref StepType, ref StepNum,
                    ref P, ref V2, ref V3, ref T, ref M2, ref M3);
                //lưu nội lực từ etabs vào _frameforce

                for (int i = 0; i <= (NumberResults - 1); i++)
                {

                    if (StepType[i] != "Single Value")
                    {
                        EtabsAPI_FrameForce _frameforce = new EtabsAPI_FrameForce();
                        //1.lấy từng thông tin nội lực trong Etabs API

                        _frameforce.Obj = Obj[i];
                        _frameforce.ObjSta = ObjSta[i];
                        _frameforce.Elm = Elm[i];
                        _frameforce.ElmSta = ElmSta[i];
                        _frameforce.LoadCase = LoadCase[i];
                        _frameforce.StepType = StepType[i];
                        _frameforce.StepNum = StepNum[i];
                        _frameforce.P = P[i];
                        _frameforce.V2 = V2[i];
                        _frameforce.V3 = V3[i];
                        _frameforce.T = T[i];
                        _frameforce.M2 = M2[i];
                        _frameforce.M3 = M3[i];

                        //add frameforce vào _dam
                        _khung.FrameForces.Add(_frameforce);
                    }

                }
            }

            // close ETABS - Đóng Etabs
            //   EtabsObject.ApplicationExit(false);

            // clean up variables - Dọn dẹp 
            SapModel = null;
            EtabsObject = null;
        }

        public static void DocEtabsAPI_PropFrame()
        {
            cSapModel SapModel;
            cOAPI EtabsObject;
            int ret = -1;
            int NumberNames = 0;

            string[] MyName = { };

            eFramePropType[] PropType = null;

            double[] T3 = { };

            double[] T2 = { };

            double[] Tf = { };

            double[] TW = { };

            double[] T2b = { };

            double[] Tfb = { };

            // create ETABS object - Tạo đối tượng
            EtabsObject = (ETABSv17.cOAPI)System.Runtime.InteropServices.Marshal.GetActiveObject("CSI.ETABS.API.ETABSObject");

            SapModel = EtabsObject.SapModel;

            //Đặt đơn vị cho mô hình
            SapModel.SetPresentUnits(eUnits.kN_m_C);

            ret = SapModel.PropFrame.GetAllFrameProperties( ref NumberNames, ref MyName, ref PropType, ref T3, ref T2, ref Tf, ref TW, ref T2b, ref Tfb);

            //ret = SapModel.PropFrame.GetAllFrameProperties(ref NumberNames, ref MyName, ref PropType, ref T3, ref T2, ref Tf, ref TW, ref T2b, ref Tfb);

            foreach (PhantuKhung _khung in Class_BienToanCuc.DanhsachPhantuKhung)
            {

                for (int i = 0; i <= (NumberNames - 1); i++)
                {
                    if (MyName[i] == _khung.Frame.PropName)
                    {
                        EtabsAPI_TietdienFrame _propFrame = new EtabsAPI_TietdienFrame();
                        //1.lấy từng thông tin nội lực trong Etabs API
                        _propFrame.MyName = MyName[i];
                        _propFrame.ReFramePropType = PropType[i];
                        _propFrame.T3 = T3[i];
                        _propFrame.T2 = T2[i];
                        _propFrame.Tf = Tf[i];
                        _propFrame.TW = TW[i];
                        _propFrame.T2b = T2b[i];
                        _propFrame.Tfb = Tfb[i];

                        //add 1 tiết diện
                        _khung.TietdienFrame = _propFrame;
                    }
                }   
            }
        }     
    }
}