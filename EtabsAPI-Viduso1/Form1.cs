using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EtabsAPI_Viduso1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //set the following flag to true to attach to an existing instance of the program 
            //otherwise a new instance of the program will be started 
            bool AttachToInstance;
            AttachToInstance = false;

            //set the following flag to true to manually specify the path to ETABS.exe
            //this allows for a connection to a version of ETABS other than the latest installation
            //otherwise the latest installed version of ETABS will be launched
            bool SpecifyPath;
            SpecifyPath = false;

            //if the above flag is set to true, specify the path to ETABS below
            string ProgramPath;
            ProgramPath = "C:\\Program Files\\Computers and Structures\\ETABS 18\\ETABS.exe";

            //full path to the model 
            //set it to an already existing folder 
            string ModelDirectory = "C:\\CSi_ETABS_API_Example";
            try
            {
                System.IO.Directory.CreateDirectory(ModelDirectory);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not create directory: " + ModelDirectory);
            }

            string ModelName = "ETABS_API_Example.edb";
            string ModelPath = ModelDirectory + System.IO.Path.DirectorySeparatorChar + ModelName;

            //dimension the ETABS Object as cOAPI type
            ETABSv17.cOAPI myETABSObject = null;

            //Use ret to check if functions return successfully (ret = 0) or fail (ret = nonzero) 
            int ret = 0;

            if (AttachToInstance)
            {
                //attach to a running instance of ETABS 
                try
                {
                    //get the active ETABS object
                    myETABSObject = (ETABSv17.cOAPI)System.Runtime.InteropServices.Marshal.GetActiveObject("CSI.ETABS.API.ETABSObject");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No running instance of the program found or failed to attach.");
                    return;
                }
            }
            else
            {
                //create API helper object
                ETABSv17.cHelper myHelper;
                try
                {
                    myHelper = new ETABSv17.Helper();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot create an instance of the Helper object");
                    return;
                }

                if (SpecifyPath)
                {
                    //'create an instance of the ETABS object from the specified path
                    try
                    {
                        //create ETABS object
                        myETABSObject = myHelper.CreateObject(ProgramPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cannot start a new instance of the program from " + ProgramPath);
                        return;
                    }
                }
                else
                {
                    //'create an instance of the ETABS object from the latest installed ETABS
                    try
                    {
                        //create ETABS object
                        myETABSObject = myHelper.CreateObjectProgID("CSI.ETABS.API.ETABSObject");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cannot start a new instance of the program.");
                        return;
                    }
                }
                //start ETABS application
                ret = myETABSObject.ApplicationStart();
            }

            //Get a reference to cSapModel to access all API classes and functions
            ETABSv17.cSapModel mySapModel = default(ETABSv17.cSapModel);
            mySapModel = myETABSObject.SapModel;

            //Initialize model
            ret = mySapModel.InitializeNewModel();

            //Create steel deck template model
            ret = mySapModel.File.NewSteelDeck(4, 12, 12, 4, 4, 24, 24);

            //Save model
            ret = mySapModel.File.Save(ModelPath);

            //Run analysis
            ret = mySapModel.Analyze.RunAnalysis();

            //Close ETABS
            myETABSObject.ApplicationExit(false);

            //Clean up variables
            mySapModel = null;
            myETABSObject = null;

            //Check ret value 
            if (ret == 0)
            {
                MessageBox.Show("API script completed successfully.");
            }
            else
            {
                MessageBox.Show("API script FAILED to complete.");
            }

        }
    }
}
