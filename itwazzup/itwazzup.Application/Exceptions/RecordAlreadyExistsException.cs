using System;

namespace itwazzup.Application.Exceptions {
    public class RecordAlreadyExistsException : Exception {
        public RecordAlreadyExistsException (string message) : base (message) { }
    }
}