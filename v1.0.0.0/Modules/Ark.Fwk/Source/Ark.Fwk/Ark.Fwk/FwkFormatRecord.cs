// FwkFormatRecord.cs
//
// This file is integrated part of Ark project
// Licensed under "Gnu General Public License Version 3"
//
// Created by Isaac Bezerra Saraiva
// Created on 2021, January 28

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
    public class FwkFormatRecord
    {
        #region Variables

        private String currentTable;
        private String currentField;
        private Dictionary<String, FwkFormatRecordTable> recordTableList;

        #endregion Variables

        #region Constructors

        public FwkFormatRecord()
        {
            this.recordTableList = new Dictionary<String, FwkFormatRecordTable>();
        }

        #endregion Constructors

        #region Methods

        public void SetTable(String name, Boolean required = true)
        {
            this.currentTable = name;
            this.currentField = null;

            if (this.recordTableList.ContainsKey(this.currentTable) == false)
                this.recordTableList.Add(this.currentTable, new FwkFormatRecordTable());

            this.recordTableList[this.currentTable].Required = required;
        }

        public void SetField(String name, String origin = null)
        {
            this.currentField = name;

            if (this.recordTableList[this.currentTable].RecordFields.ContainsKey(this.currentField) == false)
                this.recordTableList[this.currentTable].RecordFields.Add(this.currentField, new FwkFormatRecordField());

            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.Name = name;
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.Origin = origin == null ? this.currentTable : origin;
        }

        public void SetFieldAttributes(Type type, String caption = null,
            FwkBooleanEnum nullable = FwkBooleanEnum.True, FwkBooleanEnum editable = FwkBooleanEnum.True,
            FwkBooleanEnum visible = FwkBooleanEnum.True, FwkConstraintEnum constraint = FwkConstraintEnum.None,
            String[] uniqueKeys = null, Object defaultValue = null, Boolean skipValidations = false)
        {
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.Type = type;
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.Caption = caption;
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.Nullable = nullable;
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.Editable = editable;
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.Visible = visible;
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.Constraint = constraint;
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.UniqueKeys = uniqueKeys;
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.DefaultValue = defaultValue;
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Attributes.SkipValidations = skipValidations;
        }

        public void SetFieldValidation(FwkFormatRecordFieldValidation recordFieldValidation)
        {
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Validations.Add(recordFieldValidation);
        }

        public void SetFieldTransformation(FwkFormatRecordFieldTransformation recordFieldTransformation)
        {
            this.recordTableList[this.currentTable].RecordFields[this.currentField].Transformations.Add(recordFieldTransformation);
        }

        #endregion Methods

        #region Properties

        public Dictionary<String, FwkFormatRecordTable> RecordTableList
        {
            get { return this.recordTableList; }
            set { this.recordTableList = value; }
        }

        #endregion Properties
    }

    public class FwkFormatRecordTable
    {
        #region Variables

        private Boolean required;
        private Dictionary<String, FwkFormatRecordField> recordFieldList;

        #endregion Variables

        #region Constructors

        public FwkFormatRecordTable()
        {
            this.required = true;
            this.recordFieldList = new Dictionary<String, FwkFormatRecordField>();
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

        public Dictionary<String, FwkFormatRecordField> RecordFields
        {
            get { return this.recordFieldList; }
            set { this.recordFieldList = value; }
        }

        #endregion Properties
    }

    public class FwkFormatRecordField
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatRecordField()
        {
            this.Attributes = new FwkFormatRecordFieldAttribute();
            this.Validations = new List<FwkFormatRecordFieldValidation>();
            this.Transformations = new List<FwkFormatRecordFieldTransformation>();
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        public FwkFormatRecordFieldAttribute Attributes { get; set; }

        public List<FwkFormatRecordFieldValidation> Validations { get; set; }

        public List<FwkFormatRecordFieldTransformation> Transformations { get; set; }

        #endregion Properties
    }

    public class FwkFormatRecordFieldAttribute
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatRecordFieldAttribute()
        {
        }

        #endregion Constructors

        #region Methods
        #endregion Methods

        #region Properties

        [JsonIgnore()]
        public Type Type { get; set; }

        [JsonProperty("Type")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public String TypeName { get { return Type == null ? null : Type.Name; } }

        public String Name { get; set; }

        public String Origin { get; set; }

        public String Caption { get; set; }

        [JsonIgnore()]
        public FwkBooleanEnum Nullable { get; set; }

        [JsonProperty("Nullable")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Boolean NullableValue { get { return Nullable == FwkBooleanEnum.True ? true : false; } }

        [JsonIgnore()]
        public FwkBooleanEnum Editable { get; set; }

        [JsonProperty("Editable")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Boolean EditableValue { get { return Editable == FwkBooleanEnum.True ? true : false; } }

        [JsonIgnore()]
        public FwkBooleanEnum Visible { get; set; }

        [JsonProperty("Visible")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public Boolean VisibleValue { get { return Visible == FwkBooleanEnum.True ? true : false; } }

        [JsonIgnore()]
        public FwkConstraintEnum Constraint { get; set; }

        [JsonProperty("Constraint")]
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        public String ConstraintName { get { return Enum.GetName(typeof(FwkConstraintEnum), Constraint); } }

        public String[] UniqueKeys { get; set; }

        public Object DefaultValue { get; set; }

        public Boolean SkipValidations { get; set; }

        #endregion Properties
    }

    public class FwkFormatRecordFieldValidation
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatRecordFieldValidation()
        {
            this.Culture = LibGlobalization.Culture;
        }

        public FwkFormatRecordFieldValidation(LibCulture culture)
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

    public class FwkFormatRecordFieldValidationAllowedValues : FwkFormatRecordFieldValidation
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatRecordFieldValidationAllowedValues()
        {
        }

        public FwkFormatRecordFieldValidationAllowedValues(LibCulture culture, Object[] allowedValues)
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

            this.Reason = String.Format(LibGlobalization.GetTranslation(Properties.FwkResources.FwkExceptionRecordFieldValidationAllowedValues, this.Culture), objectName, allowedValuesString);
        }

        #endregion Methods

        #region Properties

        public Object[] AllowedValues { get; set; }

        #endregion Properties
    }

    public class FwkFormatRecordFieldTransformation
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatRecordFieldTransformation()
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

    public class FwkFormatRecordFieldTransformationTruncate : FwkFormatRecordFieldTransformation
    {
        #region Variables
        #endregion Variables

        #region Constructors

        public FwkFormatRecordFieldTransformationTruncate()
        {
            this.Lenght = 0;
        }

        public FwkFormatRecordFieldTransformationTruncate(Int32 lenght)
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
