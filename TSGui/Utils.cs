using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using TShockAPI;

namespace TSGui
{
    public static class Utils
    {
        internal static void MainThreadInvoke(this Control control, Action func)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(func);
            }
            else
            {
                func();
            }
        }

        public static void Append(this RichTextBox rtb, string text)
        {
            Append(rtb, text, Convert.ToByte(TShock.Config.BroadcastRGB[0]), Convert.ToByte(TShock.Config.BroadcastRGB[1]), Convert.ToByte(TShock.Config.BroadcastRGB[2]));
        }

        public static void Append(this RichTextBox rtb, string text, int r, int g, int b)
        {
            Append(rtb, text, System.Drawing.Color.FromArgb(r, g, b));
        }

        public static void Append(this RichTextBox rtb, string text, System.Drawing.Color c)
        {
            rtb.SelectionColor = c;
            rtb.AppendText(text + "\r\n");
            rtb.ScrollToCaret();
        }  
    }

    public class InterceptingWriter : TextWriter
    {
        TextWriter _existingWriter;
        Action<string> _writetask;

        public InterceptingWriter(TextWriter existing, Action<string> writetask)
        {
            _existingWriter = existing;
            _writetask = writetask;
        }

        public override void WriteLine(string value)
        {
            _existingWriter.WriteLine(value);
            _writetask(value);
        }

        public override Encoding Encoding
        {
            get { throw new NotImplementedException(); }
        }
    }
}
