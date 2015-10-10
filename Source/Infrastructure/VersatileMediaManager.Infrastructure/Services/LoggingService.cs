﻿using Microsoft.Practices.EnterpriseLibrary.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using VersatileMediaManager.Infrastructure.Contracts.Interfaces;

namespace VersatileMediaManager.Infrastructure.Services
{
    public class LoggingService : ILoggingService
    {
        private LogWriter Writer = null;

        /// <summary>
        /// CTOR
        /// </summary>
        public LoggingService()
        {
            LogWriterFactory logWriterFactory = new LogWriterFactory();
            this.Writer = logWriterFactory.Create();
        }

        private IDictionary<string, object> GetExtendedProperties(string callerMemberName, string sourceFilePath, int sourceLineNumber)
        {
            IDictionary<string, object> extProps = new Dictionary<string, object>();

            extProps.Add("Caller-Member name", callerMemberName);
            extProps.Add("Source-File path", sourceFilePath);
            extProps.Add("Source-Line number", sourceLineNumber);

            return extProps;
        }

        /// <overloads>
        /// Write a new log entry to the default category.
        /// </overloads>
        /// <summary>
        /// Write a new log entry to the default category.
        /// </summary>
        /// <example>The following example demonstrates use of the Write method with
        /// one required parameter, message.
        /// <code>Logger.Write("My message body");</code></example>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        public void Write(object message, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            IDictionary<string, object> extProps = this.GetExtendedProperties(callerMemberName, sourceFilePath, sourceLineNumber);

            Writer.Write(message, extProps);
        }

        /// <summary>
        /// Write a new log entry to a specific category.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="category">Category name used to route the log entry to a one or more trace listeners.</param>
        public void Write(object message, string category, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            IDictionary<string, object> extProps = this.GetExtendedProperties(callerMemberName, sourceFilePath, sourceLineNumber);

            Writer.Write(message, category, extProps);
        }

        /// <summary>
        /// Write a new log entry with a specific category and priority.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="category">Category name used to route the log entry to a one or more trace listeners.</param>
        /// <param name="priority">Only messages must be above the minimum priority are processed.</param>
        public void Write(object message, string category, int priority, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            IDictionary<string, object> extProps = this.GetExtendedProperties(callerMemberName, sourceFilePath, sourceLineNumber);

            Writer.Write(message, category, priority, extProps);
        }

        /// <summary>
        /// Write a new log entry with a specific category, priority and event id.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="category">Category name used to route the log entry to a one or more trace listeners.</param>
        /// <param name="priority">Only messages must be above the minimum priority are processed.</param>
        /// <param name="eventId">Event number or identifier.</param>
        public void Write(object message, string category, int priority, int eventId, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            IDictionary<string, object> extProps = this.GetExtendedProperties(callerMemberName, sourceFilePath, sourceLineNumber);

            Writer.Write(message, category, priority, eventId, TraceEventType.Information, string.Empty, extProps);
        }

        /// <summary>
        /// Write a new log entry with a specific category, priority, event id and severity.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="category">Category name used to route the log entry to a one or more trace listeners.</param>
        /// <param name="priority">Only messages must be above the minimum priority are processed.</param>
        /// <param name="eventId">Event number or identifier.</param>
        /// <param name="severity">Log entry severity as a <see cref="TraceEventType"/> enumeration. (Unspecified, Information, Warning or Error).</param>
        public void Write(object message, string category, int priority, int eventId, TraceEventType severity, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            IDictionary<string, object> extProps = this.GetExtendedProperties(callerMemberName, sourceFilePath, sourceLineNumber);

            Writer.Write(message, category, priority, eventId, severity, string.Empty, extProps);
        }

        /// <summary>
        /// Write a new log entry with a specific category, priority, event id, severity
        /// and title.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="category">Category name used to route the log entry to a one or more trace listeners.</param>
        /// <param name="priority">Only messages must be above the minimum priority are processed.</param>
        /// <param name="eventId">Event number or identifier.</param>
        /// <param name="severity">Log message severity as a <see cref="TraceEventType"/> enumeration. (Unspecified, Information, Warning or Error).</param>
        /// <param name="title">Additional description of the log entry message</param>
        public void Write(object message, string category, int priority, int eventId, TraceEventType severity, string title, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            IDictionary<string, object> extProps = this.GetExtendedProperties(callerMemberName, sourceFilePath, sourceLineNumber);

            Writer.Write(message, category, priority, eventId, severity, title, extProps);
        }

        /// <summary>
        /// Write a new log entry and a dictionary of extended properties.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="properties">Dictionary of key/value pairs to log.</param>
        public void Write(object message, IDictionary<string, object> properties, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            IDictionary<string, object> extProps = this.GetExtendedProperties(callerMemberName, sourceFilePath, sourceLineNumber);

            foreach (var p in properties)
            {
                extProps.Add(p);
            }

            Writer.Write(message, extProps);
        }

        /// <summary>
        /// Write a new log entry to a specific category with a dictionary
        /// of extended properties.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="category">Category name used to route the log entry to a one or more trace listeners.</param>
        /// <param name="properties">Dictionary of key/value pairs to log.</param>
        public void Write(object message, string category, IDictionary<string, object> properties, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            IDictionary<string, object> extProps = this.GetExtendedProperties(callerMemberName, sourceFilePath, sourceLineNumber);

            foreach (var p in properties)
            {
                extProps.Add(p);
            }

            Writer.Write(message, category, extProps);
        }

        /// <summary>
        /// Write a new log entry to with a specific category, priority and a dictionary
        /// of extended properties.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="category">Category name used to route the log entry to a one or more trace listeners.</param>
        /// <param name="priority">Only messages must be above the minimum priority are processed.</param>
        /// <param name="properties">Dictionary of key/value pairs to log.</param>
        public void Write(object message, string category, int priority, IDictionary<string, object> properties, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            IDictionary<string, object> extProps = this.GetExtendedProperties(callerMemberName, sourceFilePath, sourceLineNumber);

            foreach (var p in properties)
            {
                extProps.Add(p);
            }

            Writer.Write(message, category, priority, extProps);
        }

        /// <summary>
        /// Write a new log entry with a specific category, priority, event Id, severity
        /// title and dictionary of extended properties.
        /// </summary>
        /// <example>The following example demonstrates use of the Write method with
        /// a full set of parameters.
        /// <code></code></example>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="category">Category name used to route the log entry to a one or more trace listeners.</param>
        /// <param name="priority">Only messages must be above the minimum priority are processed.</param>
        /// <param name="eventId">Event number or identifier.</param>
        /// <param name="severity">Log message severity as a <see cref="TraceEventType"/> enumeration. (Unspecified, Information, Warning or Error).</param>
        /// <param name="title">Additional description of the log entry message.</param>
        /// <param name="properties">Dictionary of key/value pairs to log.</param>
        public void Write(object message, string category, int priority, int eventId, TraceEventType severity, string title, IDictionary<string, object> properties, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            IDictionary<string, object> extProps = this.GetExtendedProperties(callerMemberName, sourceFilePath, sourceLineNumber);

            foreach (var p in properties)
            {
                extProps.Add(p);
            }

            Writer.Write(message, category, priority, eventId, severity, title, extProps);
        }

        /// <summary>
        /// Write a new log entry to a specific collection of categories.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="categories">Category names used to route the log entry to a one or more trace listeners.</param>
        public void Write(object message, ICollection<string> categories, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            IDictionary<string, object> extProps = this.GetExtendedProperties(callerMemberName, sourceFilePath, sourceLineNumber);

            Writer.Write(message, categories, extProps);
        }

        /// <summary>
        /// Write a new log entry with a specific collection of categories and priority.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="categories">Category names used to route the log entry to a one or more trace listeners.</param>
        /// <param name="priority">Only messages must be above the minimum priority are processed.</param>
        public void Write(object message, ICollection<string> categories, int priority, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            IDictionary<string, object> extProps = this.GetExtendedProperties(callerMemberName, sourceFilePath, sourceLineNumber);

            Writer.Write(message, categories, priority, extProps);
        }

        /// <summary>
        /// Write a new log entry with a specific collection of categories, priority and event id.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="categories">Category names used to route the log entry to a one or more trace listeners.</param>
        /// <param name="priority">Only messages must be above the minimum priority are processed.</param>
        /// <param name="eventId">Event number or identifier.</param>
        public void Write(object message, ICollection<string> categories, int priority, int eventId, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            IDictionary<string, object> extProps = this.GetExtendedProperties(callerMemberName, sourceFilePath, sourceLineNumber);

            Writer.Write(message, categories, priority, eventId, TraceEventType.Information, string.Empty, extProps);
        }

        /// <summary>
        /// Write a new log entry with a specific collection of categories, priority, event id and severity.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="categories">Category names used to route the log entry to a one or more trace listeners.</param>
        /// <param name="priority">Only messages must be above the minimum priority are processed.</param>
        /// <param name="eventId">Event number or identifier.</param>
        /// <param name="severity">Log entry severity as a <see cref="TraceEventType"/> enumeration. (Unspecified, Information, Warning or Error).</param>
        public void Write(object message, ICollection<string> categories, int priority, int eventId, TraceEventType severity, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            IDictionary<string, object> extProps = this.GetExtendedProperties(callerMemberName, sourceFilePath, sourceLineNumber);

            Writer.Write(message, categories, priority, eventId, severity, string.Empty, extProps);
        }

        /// <summary>
        /// Write a new log entry with a specific collection of categories, priority, event id, severity
        /// and title.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="categories">Category names used to route the log entry to a one or more trace listeners.</param>
        /// <param name="priority">Only messages must be above the minimum priority are processed.</param>
        /// <param name="eventId">Event number or identifier.</param>
        /// <param name="severity">Log message severity as a <see cref="TraceEventType"/> enumeration. (Unspecified, Information, Warning or Error).</param>
        /// <param name="title">Additional description of the log entry message</param>
        public void Write(object message, ICollection<string> categories, int priority, int eventId, TraceEventType severity, string title, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            IDictionary<string, object> extProps = this.GetExtendedProperties(callerMemberName, sourceFilePath, sourceLineNumber);

            Writer.Write(message, categories, priority, eventId, severity, title, extProps);
        }

        /// <summary>
        /// Write a new log entry to a specific collection of categories with a dictionary of extended properties.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="categories">Category names used to route the log entry to a one or more trace listeners.</param>
        /// <param name="properties">Dictionary of key/value pairs to log.</param>
        public void Write(object message, ICollection<string> categories, IDictionary<string, object> properties, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            IDictionary<string, object> extProps = this.GetExtendedProperties(callerMemberName, sourceFilePath, sourceLineNumber);

            foreach (var p in properties)
            {
                extProps.Add(p);
            }

            Writer.Write(message, categories, extProps);
        }

        /// <summary>
        /// Write a new log entry to with a specific collection of categories, priority and a dictionary
        /// of extended properties.
        /// </summary>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="categories">Category names used to route the log entry to a one or more trace listeners.</param>
        /// <param name="priority">Only messages must be above the minimum priority are processed.</param>
        /// <param name="properties">Dictionary of key/value pairs to log.</param>
        public void Write(object message, ICollection<string> categories, int priority, IDictionary<string, object> properties, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            IDictionary<string, object> extProps = this.GetExtendedProperties(callerMemberName, sourceFilePath, sourceLineNumber);

            foreach (var p in properties)
            {
                extProps.Add(p);
            }

            Writer.Write(message, categories, priority, extProps);
        }

        /// <summary>
        /// Write a new log entry with a specific category, priority, event Id, severity
        /// title and dictionary of extended properties.
        /// </summary>
        /// <example>The following example demonstrates use of the Write method with
        /// a full set of parameters.
        /// <code></code></example>
        /// <param name="message">Message body to log.  Value from ToString() method from message object.</param>
        /// <param name="categories">Category names used to route the log entry to a one or more trace listeners.</param>
        /// <param name="priority">Only messages must be above the minimum priority are processed.</param>
        /// <param name="eventId">Event number or identifier.</param>
        /// <param name="severity">Log message severity as a <see cref="TraceEventType"/> enumeration. (Unspecified, Information, Warning or Error).</param>
        /// <param name="title">Additional description of the log entry message.</param>
        /// <param name="properties">Dictionary of key/value pairs to log.</param>
        public void Write(object message, ICollection<string> categories, int priority, int eventId, TraceEventType severity, string title, IDictionary<string, object> properties, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            IDictionary<string, object> extProps = this.GetExtendedProperties(callerMemberName, sourceFilePath, sourceLineNumber);

            foreach (var p in properties)
            {
                extProps.Add(p);
            }

            Writer.Write(message, categories, priority, eventId, severity, title, extProps);
        }
    }
}