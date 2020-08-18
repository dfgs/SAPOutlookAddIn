using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;
using System.IO;
using System.Text.RegularExpressions;

namespace SAPOutlookAddIn
{
    public partial class ThisAddIn
    {
        private Outlook.Inspectors inspectors;
        private Outlook.Application application;

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            inspectors = this.Application.Inspectors;
           // inspectors.NewInspector += new Microsoft.Office.Interop.Outlook.InspectorsEvents_NewInspectorEventHandler(Inspectors_NewInspector);

            application= this.Application;

            // Subscribe to the ItemSend event, that it's triggered when an email is sent
            application.ItemSend += ItemSend_BeforeSend;

			application.OptionsPagesAdd += Application_OptionsPagesAdd;
        }

		private void Application_OptionsPagesAdd(Outlook.PropertyPages Pages)
		{
            Pages.Add(new OptionsPropertyPage(),"Options du plugin SAP");
		}



        /*private void Inspectors_NewInspector(Microsoft.Office.Interop.Outlook.Inspector Inspector)
        {
            Outlook.MailItem mailItem = Inspector.CurrentItem as Outlook.MailItem;
            if (mailItem == null) return;
            
            if (mailItem.EntryID == null)
            {
                mailItem.Subject = "This text was added by using code";
                mailItem.Body = "This text was added by using code";
            }

        }*/

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Remarque : Outlook ne déclenche plus cet événement. Si du code
            //    doit s'exécuter à la fermeture d'Outlook (consultez https://go.microsoft.com/fwlink/?LinkId=506785)
        }

        private void ItemSend_BeforeSend(object item, ref bool cancel)
        {
            string ticketID;
            string filePath;
            string fileName;
            string subject;

            Regex regex;
            Match match;

            cancel = false;

            Outlook.MailItem mailItem = item as Outlook.MailItem;
            if (mailItem == null) return;

			#region build regex
			try
			{
                 regex = new Regex(global::SAPOutlookAddIn.Properties.Settings.Default.SubjectPattern);
            }
            catch (Exception ex)
            {
                return;
			}
			#endregion

			#region extract TicketID
			ticketID = null;
            match = regex.Match(mailItem.Subject);
            if (!match.Success) return;
             
            ticketID = match.Groups["TicketID"].Value;
			#endregion

			#region create destination folder
			filePath = Path.Combine(global::SAPOutlookAddIn.Properties.Settings.Default.SavePath, ticketID);
            try
            {
                Directory.CreateDirectory(filePath);
            }
            catch (Exception ex)
            {
                return;
			}
			#endregion

			#region remove invalid chars from subject
			subject = mailItem.Subject;
            foreach (char invalidChar in Path.GetInvalidFileNameChars())
			{
                subject=subject.Replace(invalidChar, ' ');
			}
			#endregion

			#region save email
			fileName = Path.Combine(filePath, $"{subject}.msg");
            try
            {
                mailItem.SaveAs(fileName);
            }
            catch(Exception ex)
			{
                return;
			}
			#endregion
		}


		#region Code généré par VSTO

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
