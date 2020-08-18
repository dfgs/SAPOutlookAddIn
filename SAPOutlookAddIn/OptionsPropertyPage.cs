using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Text.RegularExpressions;

namespace SAPOutlookAddIn
{
	[ComVisible(true)]
	public partial class OptionsPropertyPage : UserControl, Outlook.PropertyPage
	{
        
        bool isDirty = false;
        bool Outlook.PropertyPage.Dirty
        {
            get => isDirty;
        }

        /*const int captionDispID = -518;
        [DispId(captionDispID)]
        public string PageCaption
        {
            get
            {
                return "Chad Syteline Outlook Add-in";
            }
        }*/



        private Outlook.PropertyPageSite propertyPageSite = null;



        public OptionsPropertyPage()
        {
            InitializeComponent();
        }
        
        
        void Outlook.PropertyPage.GetPageInfo(ref string helpFile, ref int helpContext)
        {
        }
        
        
        private Outlook.PropertyPageSite GetPropertyPageSite()
        {
            Type myType = typeof(System.Object);
            string assembly = Regex.Replace(myType.Assembly.CodeBase, "mscorlib.dll", "System.Windows.Forms.dll");
            assembly = System.Text.RegularExpressions.Regex.Replace(assembly, "file:///", "");
            assembly = System.Reflection.AssemblyName.GetAssemblyName(assembly).FullName;
            Type unmanaged = Type.GetType(System.Reflection.Assembly.CreateQualifiedName(assembly, "System.Windows.Forms.UnsafeNativeMethods"));
            Type oleObj = unmanaged.GetNestedType("IOleObject");
            System.Reflection.MethodInfo mi = oleObj.GetMethod("GetClientSite");
            object myppSite = mi.Invoke(this, null);
            return (Outlook.PropertyPageSite)myppSite;
        }
        private void OptionsPropertyPage_Load(object sender, EventArgs e)
        {
            propertyPageSite = GetPropertyPageSite();
            textBoxPath.Text = global::SAPOutlookAddIn.Properties.Settings.Default.SavePath;
            textBoxPattern.Text= global::SAPOutlookAddIn.Properties.Settings.Default.SubjectPattern;
        }
        void Outlook.PropertyPage.Apply()
        {
            global::SAPOutlookAddIn.Properties.Settings.Default.SavePath = textBoxPath.Text;
            global::SAPOutlookAddIn.Properties.Settings.Default.SubjectPattern= textBoxPattern.Text;
            global::SAPOutlookAddIn.Properties.Settings.Default.Save();
        }
        private void textBoxPath_TextChanged(object sender, EventArgs e)
		{
            isDirty = true;
            propertyPageSite.OnStatusChange();

        }

        private void textBoxPattern_TextChanged(object sender, EventArgs e)
		{
            isDirty = true;
            propertyPageSite.OnStatusChange();

        }
    }
}
