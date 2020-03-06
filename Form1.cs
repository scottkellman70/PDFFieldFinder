using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PDFFieldFinder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>  
        /// List all of the form fields into a textbox.  The  
        /// form fields identified can be used to map each of the  
        /// fields in a PDF.  
        /// </summary>  
        private void ListFieldNames()
        {
            DialogResult result = this.openFileDialog1.ShowDialog();

            if (result == DialogResult.OK && this.openFileDialog1.CheckFileExists == true)
            {
                string pdfTemplate = this.openFileDialog1.FileName;

                // title the form  
                this.Text += " - " + pdfTemplate;

                // create a new PDF reader based on the PDF template document  
                PdfReader pdfReader = new PdfReader(pdfTemplate);

                // create and populate a string builder with each of the field names available in the subject PDF  
                StringBuilder sb = new StringBuilder();

                foreach (KeyValuePair<string, AcroFields.Item> de in pdfReader.AcroFields.Fields)
                {
                    sb.Append(de.Key.ToString() + Environment.NewLine);
                }

                // Write the string builder's content to the form's textbox  
                textBox1.Text = sb.ToString();
                textBox1.SelectionStart = 0;
            }

        }
        private void ButtonGetFields_Click(object sender, EventArgs e)
        {
            ListFieldNames();
        }
    }
}
