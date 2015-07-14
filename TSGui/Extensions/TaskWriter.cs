/*
TSGui, a Graphical User Interface that replaces the TShock Console
Copyright (C) 2015 Ancientgods & magnusi
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/


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
