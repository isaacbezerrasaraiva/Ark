// LibException.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 16

using System;
using System.IO;
using System.Xml;
using System.Data;
using System.Collections.Generic;

using Lazy;

namespace Ark.Lib
{
    public class LibException : Exception
    {
        #region Variables

        private String caption;
        private Object[] formatValues;

        #endregion Variables

        #region Constructors

        public LibException()
        {
        }

        public LibException(String message)
            : base(message)
        {
        }

        public LibException(String message, Object[] formatValues)
            : base(message)
        {
            this.formatValues = formatValues;
        }

        public LibException(String message, Object[] formatValues, String caption)
            : base(message)
        {
            this.formatValues = formatValues;
            this.caption = caption;
        }

        public LibException(String message, String caption)
            : base(message)
        {
            this.caption = caption;
        }

        public LibException(String message, Exception innerException)
            : base(message, innerException)
        {
        }

        public LibException(String message, Exception innerException, Object[] formatValues)
            : base(message, innerException)
        {
            this.formatValues = formatValues;
        }

        public LibException(String message, Exception innerException, Object[] formatValues, String caption)
            : base(message, innerException)
        {
            this.formatValues = formatValues;
            this.caption = caption;
        }

        public LibException(String message, Exception innerException, String caption)
            : base(message, innerException)
        {
            this.caption = caption;
        }

        #endregion Constructors

        #region Methods

        public static String GetExceptionCaption(Exception exception)
        {
            return GetExceptionCaption(exception, LibGlobalization.Culture);
        }

        public static String GetExceptionCaption(Exception exception, LibCulture culture)
        {
            if (exception != null && exception is LibException && culture != null)
            {
                LibException libException = (LibException)exception;
                return LibGlobalization.GetTranslation(libException.Caption, culture);
            }

            return String.Empty;
        }

        public static String GetExceptionMessage(Exception exception)
        {
            return GetExceptionMessage(exception, LibGlobalization.Culture);
        }

        public static String GetExceptionMessage(Exception exception, LibCulture culture)
        {
            if (exception != null)
            {
                if (exception is LibException && culture != null)
                {
                    LibException libException = (LibException)exception;

                    if (libException.FormatValues != null && libException.FormatValues.Length > 0)
                    {
                        try { return String.Format(LibGlobalization.GetTranslation(libException.Message, culture), libException.FormatValues); }
                        catch { return LibGlobalization.GetTranslation(libException.Message, culture); }
                    }

                    return LibGlobalization.GetTranslation(libException.Message, culture);
                }

                return exception.GetBaseException().Message;
            }

            return String.Empty;
        }

        #endregion Methods

        #region Properties

        public String Caption
        {
            get { return this.caption; }
        }

        public Object[] FormatValues
        {
            get { return this.formatValues; }
        }

        #endregion Properties
    }
}
