using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace CodeCampApp.Data.Logging
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class OutputWindow
    {
        #region Public

        [Conditional("DEBUG")]
        public static void DebugWriteDictionary<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            string typeLabel = null)
        {
            try
            {
                DebugWriteSubheader(
                    $"|{typeLabel ?? "Dictionary"}| = {dictionary.Count}");

                var keys = dictionary.Keys.ToArray();
                var values = dictionary.Values.ToArray();

                for (var index = 0; index < dictionary.Count; index++)
                {
                    var key = keys[index];
                    var value = values[index];
                    DebugWriteLine($"\t\t{index + 1,-3} : {key} => {value}");
                }
            }
            catch (Exception exception)
            {
                DebugWriteException(exception);
            }
        }

        [Conditional("DEBUG")]
        public static void DebugWriteError(string error)
        {
            try
            {
                DebugWriteSubheader("ERROR - {0}", error);
            }
            catch (Exception exception)
            {
                DebugWriteException(exception);
            }
        }

        [Conditional("DEBUG")]
        public static void DebugWriteException(Exception exception, bool showStackTrace = false)
        {
            try
            {
                var message = exception.InnerException?.Message ?? exception.Message;

                DebugWriteSubheader("{0} - {1}", exception.GetType().Name, message);

                // TODO Test this some more
                if (exception is AggregateException aggregateException)
                {
                    // Need?
                    foreach (DictionaryEntry entry in aggregateException.Data)
                        DebugWriteValue(entry.Key.ToString(), entry.Value, false);

                    foreach (var innerEx in aggregateException.InnerExceptions)
                    {
                        DebugWriteValue("Inner Exception", innerEx.Message ?? "");
                        DebugWriteExceptionDetails(innerEx, showStackTrace);
                    }
                }

                DebugWriteExceptionDetails(exception, showStackTrace);
            }
            catch (Exception backUpException)
            {
                Debug.WriteLine(backUpException);
            }
        }

        [Conditional("DEBUG")]
        public static void DebugWriteHeader(string header)
        {
            try
            {
                DebugWriteNewLine();
                DebugWriteLine("@@@ {0}", header);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }

        [Conditional("DEBUG")]
        public static void DebugWriteInformation(string message)
        {
            try
            {
                DebugWriteSubheader("INFORMATION - {0}", message);
            }
            catch (Exception exception)
            {
                DebugWriteException(exception);
            }
        }

        [Conditional("DEBUG")]
        public static void DebugWriteLine(string messageFormat,
            params object[] args)
        {
            try
            {
                if (messageFormat != null)
                    Debug.WriteLine(messageFormat, args);
            }
            catch (Exception exception)
            {
                DebugWriteException(exception);
            }
        }

        // Add ability to specify what to print from each element
        [Conditional("DEBUG")]
        public static void DebugWriteList<T>(IList<T> list,
            string typeLabel = null)
        {
            try
            {
                DebugWriteSubheader($"|{typeLabel ?? "List"}| = {list.Count}");

                for (var index = 0; index < list.Count; index++)
                {
                    var element = list[index];

                    DebugWriteLine($"\t\t{index,-3} : {element}");
                }
            }
            catch (Exception exception)
            {
                DebugWriteException(exception);
            }
        }

        public static void DebugWriteNewLine()
        {
            DebugWriteLine("");
        }

        [Conditional("DEBUG")]
        public static void DebugWriteSubheader(string messageFormat,
            params object[] args)
        {
            try
            {
                DebugWriteNewLine();
                DebugWriteLine("\t*** " + messageFormat, args);

            }
            catch (Exception exception)
            {
                DebugWriteException(exception);
            }
        }

        [Conditional("DEBUG")]
        public static void DebugWriteValue(string name, object value,
            bool newline = false)
        {
            try
            {
                const string valueFormat = "\t\t{0} = {1}";

                if (newline)
                    DebugWriteNewLine();

                DebugWriteLine(valueFormat, name, value);
            }
            catch (Exception exception)
            {
                DebugWriteException(exception);
            }
        }

        [Conditional("DEBUG")]
        public static void DebugWriteWarning(string warning)
        {
            try
            {
                DebugWriteSubheader("WARNING - {0}", warning);
            }
            catch (Exception exception)
            {
                DebugWriteException(exception);
            }
        }

        #endregion

        #region Interface

        #endregion

        #region Protected

        #endregion

        #region Internal

        #endregion

        #region Private

        private static void DebugWriteExceptionDetails(Exception ex, bool showStackTrace)
        {
            if (ex.TargetSite.DeclaringType != null)
                DebugWriteValue("DeclaringType", ex.TargetSite.DeclaringType?.FullName);
            else
                DebugWriteValue("Source", ex.Source);
            DebugWriteValue("TargetSite", ex.TargetSite);

            foreach (DictionaryEntry entry in ex.Data)
                DebugWriteValue(entry.Key.ToString(), entry.Value, false);

            // TODO Uncomment after turn Data project into NuGet
            //switch (ex)
            //{
            //    case ApiException apiException:
            //        var requestMessage = apiException.RequestMessage;

            //        Debug.WriteLine($"{requestMessage.Method} {requestMessage.RequestUri}");
            //        // TODO Print parameters if POST

            //        break;
            //}

            if (showStackTrace)
                DebugWriteValue("StackTrace", ex.StackTrace);

            Debug.WriteLine("");
        }

        #endregion

        #region Nested Types

        #endregion
    }}
