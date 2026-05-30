using System;
using PipelineCore.Domain.Enums;

namespace PipelineCore.Domain;

public class ValidationResult
{
    public ValidationStatus ValidationStatus { get; set; }
    public string ValidationMessage { get; set; }

    public ValidationResult(ValidationStatus validationStatus, string validationMessage = "")
    {
        ValidationStatus = validationStatus;
        ValidationMessage = validationMessage;
    }
}
