#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Versioning;
using System.Windows.Markup;

#endregion

namespace RAB_Module04
{
    internal class App : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication app)
        {
            // 1. Create ribbon tab
            string tabName = "Andy's Custom Toolset";
            try
            {
                app.CreateRibbonTab(tabName);
            }
            catch (Exception)
            {
                Debug.Print("Tab already exists.");
            }

            // 2. Create ribbon panel 
            RibbonPanel panel = Utils.CreateRibbonPanel(app, tabName, "Revit Tools");

            // 3. Create button data instances
            PushButtonData btnData1 = Command1.GetButtonData();
            PushButtonData btnData2 = Command2.GetButtonData();
            PushButtonData btnData3 = Command3.GetButtonData();
            PushButtonData btnData4 = Command4.GetButtonData();
            PushButtonData btnData5 = Command5.GetButtonData();
            PushButtonData btnData6 = Command6.GetButtonData();
            PushButtonData btnData7 = Command7.GetButtonData();
            PushButtonData btnData8 = Command8.GetButtonData();
            PushButtonData btnData9 = Command9.GetButtonData();
            PushButtonData btnData10 = Command10.GetButtonData();

            // 4. Create buttons
            PushButton myButton1 = panel.AddItem(btnData1) as PushButton;
            PushButton myButton2 = panel.AddItem(btnData2) as PushButton;

            // 5. Create stacked row with 3, 4 & 5
            panel.AddStackedItems(btnData3, btnData4, btnData5);

            // 6. Create split button with 6 & 7
            SplitButtonData splitButtonData = new SplitButtonData("split1", "Split\rButtons");
            SplitButton splitButton = panel.AddItem(splitButtonData) as SplitButton;
            splitButton.AddPushButton(btnData6);
            splitButton.AddPushButton(btnData7);

            // 7. Create pulldown for 8, 9 & 10
            PulldownButtonData pulldownButtonData = new PulldownButtonData("pulldown1", "8, 9 & 10");
            pulldownButtonData.LargeImage = ButtonDataClass.BitmapToImageSource(Properties.Resources.B8910_32);
            pulldownButtonData.Image = ButtonDataClass.BitmapToImageSource(Properties.Resources.Red_16);

            PulldownButton pulldownButton = panel.AddItem(pulldownButtonData) as PulldownButton;
            pulldownButton.AddPushButton(btnData8);
            pulldownButton.AddPushButton(btnData9);
            pulldownButton.AddPushButton(btnData10);

            // NOTE:
            // To create a new tool, copy lines 35 and 39 and rename the variables to "btnData3" and "myButton3". 
            // Change the name of the tool in the arguments of line 

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }


    }
}
