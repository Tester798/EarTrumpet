﻿using System;
using System.Diagnostics;

namespace EarTrumpet.Diagnosis
{
    class ErrorReporter
    {
        private static ErrorReporter s_instance;
        private readonly CircularBufferTraceListener _listener;
        private readonly AppSettings _settings;

        public ErrorReporter(AppSettings settings)
        {
            Debug.Assert(s_instance == null);
            s_instance = this;

            _listener = new CircularBufferTraceListener();
            _settings = settings;
            Trace.Listeners.Clear();
            Trace.Listeners.Add(_listener);
        }

        public void DisplayDiagnosticData()
        {
            LocalDataExporter.DumpAndShowData(_listener.GetLogText());
        }

        public static void LogWarning(Exception ex) => s_instance.LogWarningInstance(ex);
        private void LogWarningInstance(Exception ex)
        {
            Trace.WriteLine($"## Warning Notify ##: {ex}");
        }
    }
}
