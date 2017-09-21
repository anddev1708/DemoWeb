using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace DemoWeb.Class
{
    public class CustomValidation
    {
    }


    public class SexValidation : ValidationAttribute, IClientValidatable
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToString(value) == "M" || Convert.ToString(value) == "F")
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule mvr = new ModelClientValidationRule();
            mvr.ErrorMessage = ErrorMessage;
            mvr.ValidationType = "sexvalidation";
            return new[] { mvr };
        }
    }

    public class SkillValidation : ValidationAttribute//, IClientValidatable
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<CheckBox> instance = value as List<CheckBox>;
            int count = instance == null ? 0 : (from p in instance
                                                where p.Checked == true
                                                select p).Count();
            if (count >= 3)
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }

        //public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        //{
        //    ModelClientValidationRule mvr = new ModelClientValidationRule();
        //    mvr.ErrorMessage = ErrorMessage;
        //    mvr.ValidationType = "skillvalidation";
        //    return new[] { mvr };
        //}
    }
    public sealed class ValidBirthDate : ValidationAttribute, IClientValidatable
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                DateTime _birthJoin = Convert.ToDateTime(value);
                DateTime minDate = Convert.ToDateTime("01-25-1970");
                DateTime maxDate = Convert.ToDateTime("01-25-2000");

                if (_birthJoin > minDate && _birthJoin < maxDate)
                    return ValidationResult.Success;
                else
                    return new ValidationResult(ErrorMessage);
            } catch(Exception e)
            {
                return new ValidationResult(e.Message);
            }
            
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule mvr = new ModelClientValidationRule();
            mvr.ErrorMessage = ErrorMessage;
            mvr.ValidationType = "validbirthdate";
            mvr.ValidationParameters.Add("min", "01-25-1970");
            mvr.ValidationParameters.Add("max", "01-25-2000");
            return new[] { mvr };
        }
    }

    public sealed class RequiredTerms : ValidationAttribute, IClientValidatable
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Convert.ToBoolean(value) == false)
                return new ValidationResult(ErrorMessage);
            else
                return ValidationResult.Success;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule mvr = new ModelClientValidationRule();
            mvr.ErrorMessage = ErrorMessage;
            mvr.ValidationType = "termsvalidation";
            return new[] { mvr };
        }
    }
}