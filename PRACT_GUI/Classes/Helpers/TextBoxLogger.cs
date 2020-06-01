using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace PRACT.Classes.Helpers
{
    public class TextBoxLogger
    {
        private TextBox Textbox {get;set;}
        public TextBoxLogger(TextBox Textbox)
        {
            this.Textbox = Textbox;
        }
        public void Log(string Message)
        {
            try
            {
                Textbox.Invoke((Action)delegate
                {
                    Textbox.AppendText($"{ DateTime.Now } - { Message }\r\n");
                });
            }
            catch(System.InvalidOperationException ie)
            {
                // Nothing to do, happens when the main window is closed
            }
        }

        public void ClearLog()
        {
            Textbox.Invoke((Action)delegate
            {
                Textbox.Clear();
            });
        }
    }
}
