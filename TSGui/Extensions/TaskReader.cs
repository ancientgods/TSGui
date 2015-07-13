using System;
using System.IO;
using System.Threading;

namespace TSGui.Extensions
{
    public class TaskReader : TextReader
    {
        private AutoResetEvent _resetEvent = new AutoResetEvent(false);
        private TextReader _reader;
        private string _text;
        private Action<string> _action;

        public void SendText(string text)
        {
            _text = text;
            _resetEvent.Set();

            if (_action != null)
                _action(_text);
        }

        public TaskReader(TextReader textReader)
        {
            _reader = textReader;
        }

        public TaskReader(TextReader textReader, Action<string> action) : this(textReader)
        {
            _action = action;
        }

        public override string ReadLine()
        {
            _resetEvent.WaitOne();
            return _text;
        }
    }
}
