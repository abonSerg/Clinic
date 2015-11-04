using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraLayout;

namespace Medicine.Clinic.Client.UI
{
    static class FormBuilder
    {
        public static string SaveFormSettings(this LayoutControl layoutControl, string address) 
        {
            try
            {
                var file = File.Open(address, FileMode.OpenOrCreate, FileAccess.Write);
                var writer = new StreamWriter(file);
                writer.WriteLine(GetLayoutXml(layoutControl));
                writer.Close();
                file.Close();
                return string.Empty;
            }
            catch (Exception) 
            {
                return "Error Form-setting saving!";
            }
        }


        public static string LoadFormSettings(this LayoutControl layoutControl, string address)
        {
            try
            {
                StreamReader streamReader = new StreamReader(address);
                string xmlString = streamReader.ReadToEnd();
                streamReader.Close();
                layoutControl.SetLayoutXml(xmlString);
                return string.Empty;
            }
            catch (Exception) 
            {
                return "Form-customizing will be saved after first closing of entry!";
            }
            
        }

        public static bool IsFormUnique(Main mainView, FormEnum formType) 
        {
            var uniqueForm = mainView.MdiChildren.SingleOrDefault(x => x.Name == formType.ToString());
            if (uniqueForm != null)
            {
                uniqueForm.Focus();
                return true;
            }
            else 
            {
                return false;
            }
        }


        private static string GetLayoutXml(LayoutControl layoutControl)
        {
            string xml;

            using (var stream = new MemoryStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    layoutControl.SaveLayoutToStream(stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    xml = reader.ReadToEnd();
                }
            }

            return xml;
        }

        private static void SetLayoutXml(this LayoutControl layoutControl, string xml)
        {
            using (var stream = new MemoryStream())
            {
                using (var writer = new StreamWriter(stream))
                {
                    layoutControl.BeginInit();
                    layoutControl.BeginUpdate();
                    try
                    {
                        writer.Write(xml);
                        writer.Flush();
                        stream.Seek(0, SeekOrigin.Begin);

                        layoutControl.RestoreLayoutFromStream(stream);
                    }
                    finally
                    {
                        layoutControl.EndUpdate();
                        layoutControl.EndInit();
                    }
                }
            }
        }
    }
}
