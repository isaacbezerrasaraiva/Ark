// FwkFormatView.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, April 03

using System;
using System.Xml;
using System.Data;
using System.ComponentModel;
using System.Collections.Generic;

using Newtonsoft.Json;

using Lazy;

using Ark.Lib;

namespace Ark.Fwk
{
    public class FwkFormatView
    {
        #region Variables

        private String currentTable;
        private String currentField;
        private Dictionary<String, FwkFormatViewTable> viewTableList;

        #endregion Variables

        #region Constructors

        public FwkFormatView()
        {
            this.viewTableList = new Dictionary<String, FwkFormatViewTable>();
        }

        #endregion Constructors

        #region Methods

        public void SetTable(String name, Boolean required = true)
        {
            this.currentTable = name;
            this.currentField = null;

            if (this.viewTableList.ContainsKey(this.currentTable) == false)
                this.viewTableList.Add(this.currentTable, new FwkFormatViewTable());

            this.viewTableList[this.currentTable].Required = required;
        }

        public void SetField(String name, String origin = null)
        {
            this.currentField = name;

            if (this.viewTableList[this.currentTable].ViewFields.ContainsKey(this.currentField) == false)
                this.viewTableList[this.currentTable].ViewFields.Add(this.currentField, new FwkFormatViewField());

            this.viewTableList[this.currentTable].ViewFields[this.currentField].Attributes.Name = name;
            this.viewTableList[this.currentTable].ViewFields[this.currentField].Attributes.Origin = origin == null ? this.currentTable : origin;
        }

        public void SetFieldAttributes(Type type, String caption = null,
            FwkBooleanEnum visible = FwkBooleanEnum.True, FwkConstraintEnum constraint = FwkConstraintEnum.None)
        {
            this.viewTableList[this.currentTable].ViewFields[this.currentField].Attributes.Type = type;
            this.viewTableList[this.currentTable].ViewFields[this.currentField].Attributes.Caption = caption;
            this.viewTableList[this.currentTable].ViewFields[this.currentField].Attributes.Visible = visible;
            this.viewTableList[this.currentTable].ViewFields[this.currentField].Attributes.Constraint = constraint;
        }

        public void SetFieldValidation(FwkFormatViewFieldValidation recordFieldValidation)
        {
            this.viewTableList[this.currentTable].ViewFields[this.currentField].Validations.Add(recordFieldValidation);
        }

        public void SetFieldTransformation(FwkFormatViewFieldTransformation recordFieldTransformation)
        {
            this.viewTableList[this.currentTable].ViewFields[this.currentField].Transformations.Add(recordFieldTransformation);
        }

        #endregion Methods

        #region Properties

        public Dictionary<String, FwkFormatViewTable> ViewTableList
        {
            get { return this.viewTableList; }
            set { this.viewTableList = value; }
        }

        #endregion Properties
    }

    public class FwkFormatViewTable
    {
        #region Variables

        private Boolean required;
        private Dictionary<String, FwkFormatViewField> recordFieldList;

        #endregion Variables

        #region Constructors

        public FwkFormatViewTable()
        {
            this.required = true;
            this.recordFieldList = new Dictionary<String, FwkFormatViewField>();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public Boolean Required
        {
            get { return this.required; }
            set { this.required = value; }
        }

        public Dictionary<String, FwkFormatViewField> ViewFields
        {
            get { return this.recordFieldList; }
            set { this.recordFieldList = value; }
        }

        #endregion Properties
    }

    public class FwkFormatViewField
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatViewField()
        {
            this.Attributes = new FwkFormatViewFieldAttribute();
            this.Validations = new List<FwkFormatViewFieldValidation>();
            this.Transformations = new List<FwkFormatViewFieldTransformation>();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public FwkFormatViewFieldAttribute Attributes { get; set; }

        public List<FwkFormatViewFieldValidation> Validations { get; set; }

        public List<FwkFormatViewFieldTransformation> Transformations { get; set; }

        #endregion Properties
    }

    public class FwkFormatViewFieldAttribute
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatViewFieldAttribute()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        [JsonIgnore()]
        public Type Type { get; set; }

        [JsonProperty("Type")]
        public String TypeName { get { return Type == null ? null : Type.Name; } }

        public String Name { get; set; }

        public String Origin { get; set; }

        public String Caption { get; set; }

        [JsonIgnore()]
        public FwkBooleanEnum Visible { get; set; }

        [JsonProperty("Visible")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public String VisibleValue { get { return Enum.GetName(typeof(FwkBooleanEnum), Visible); } }

        [JsonIgnore()]
        public FwkConstraintEnum Constraint { get; set; }

        [JsonProperty("Constraint")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public String ConstraintName { get { return Enum.GetName(typeof(FwkConstraintEnum), Constraint); } }

        #endregion Properties
    }

    public class FwkFormatViewFieldValidation
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatViewFieldValidation()
        {
            this.Culture = LibGlobalization.Culture;
        }

        public FwkFormatViewFieldValidation(LibCulture culture)
        {
            this.Culture = culture;
        }

        #endregion Constructors

        #region Methods

        public virtual Boolean Validate(Object value, String objectName = null)
        {
            return true;
        }

        #endregion Methods

        #region Properties

        [JsonIgnore()]
        public LibCulture Culture { get; set; }

        [JsonIgnore()]
        public String Reason { get; set; }

        #endregion Properties
    }

    public class FwkFormatViewFieldValidationAllowedValues : FwkFormatViewFieldValidation
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatViewFieldValidationAllowedValues()
        {
        }

        public FwkFormatViewFieldValidationAllowedValues(LibCulture culture, Object[] allowedValues)
            : base(culture)
        {
            this.AllowedValues = allowedValues;
        }

        #endregion Constructors

        #region Methods

        public override Boolean Validate(Object value, String objectName = null)
        {
            if (value == null || value == DBNull.Value || LazyConvert.ToString(value, "NotEmpty") == String.Empty)
            {
                if (this.AllowedValues == null && this.AllowedValues.Length == 0)
                    return true;

                SetReason(objectName);

                return false;
            }
            else
            {
                if (this.AllowedValues != null && this.AllowedValues.Length > 0)
                {
                    foreach (Object allowedValue in this.AllowedValues)
                    {
                        // Case LazyConvert unable to cast the values to String, its means that this validation cannot be performed for this values types
                        if (LazyConvert.ToString(value, String.Empty) == LazyConvert.ToString(allowedValue, String.Empty))
                            return true;
                    }
                }

                SetReason(objectName);

                return false;
            }
        }

        private void SetReason(String objectName)
        {
            String allowedValuesString = String.Empty;

            if (this.AllowedValues != null)
            {
                for (int i = 0; i < this.AllowedValues.Length; i++)
                    allowedValuesString = LazyConvert.ToString(this.AllowedValues[i], String.Empty) + ", ";
                allowedValuesString = allowedValuesString.Remove(allowedValuesString.Length - 2, 2);
            }

            this.Reason = String.Format(LibGlobalization.GetTranslation(Properties.FwkResources.FwkExceptionViewFieldValidationAllowedValues, this.Culture), objectName, allowedValuesString);
        }

        #endregion Methods

        #region Properties

        public Object[] AllowedValues { get; set; }

        #endregion Properties
    }

    public class FwkFormatViewFieldTransformation
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatViewFieldTransformation()
        {
        }

        #endregion Constructors

        #region Methods

        public virtual Object Transform(Object value)
        {
            return value;
        }

        #endregion Methods

        #region Properties
        #endregion Properties
    }

    public class FwkFormatViewFieldTransformationTruncate : FwkFormatViewFieldTransformation
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatViewFieldTransformationTruncate()
        {
            this.Lenght = 0;
        }

        public FwkFormatViewFieldTransformationTruncate(Int32 lenght)
        {
            this.Lenght = lenght;
        }

        #endregion Constructors

        #region Methods

        public override Object Transform(Object value)
        {
            if (value != null && value != DBNull.Value)
            {
                if (value.GetType() == typeof(String))
                {
                    String valueString = LazyConvert.ToString(value);

                    if (valueString.Length > this.Lenght)
                        return valueString.Substring(0, this.Lenght);
                }
            }

            return value;
        }

        #endregion Methods

        #region Properties

        public Int32 Lenght { get; set; }

        #endregion Properties
    }
}
