using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TSGui.Extensions
{
    class TaskWriter : TextWriter
    {
        TextWriter _existingWriter;
        Action<string> _writetask;

        public TaskWriter(TextWriter existing, Action<string> writetask)
        {
            _existingWriter = existing;
            _writetask = writetask;
        }

        public override void WriteLine(string value)
        {
            _existingWriter.WriteLine(value);
            _writetask(value);
        }

        public override void Write(string format, object arg0) //For when terraria asks for input.
        {
            _existingWriter.Write(format, arg0);
            _writetask(string.Format(format, arg0));
        }

        public override void Write(string value) //Same as above
        {
            _existingWriter.Write(value);
            _writetask(value);
        }

        public override Encoding Encoding
        {
            get { throw new NotImplementedException(); }
        }
    }
}
