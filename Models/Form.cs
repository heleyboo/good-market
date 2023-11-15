namespace GoodMarket.Models;

public class Form
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    
    // Navigation property to represent the relationship
    public ICollection<FormField> FormFields { get; set; }
}

public enum FormFieldType
{
    Text,
    Date,
    Time,
    Checkbox,
    Radio,
    Password,
    Email,
    Phone,
    SingleSelect,
    MultiSelect,
    Address,
}
public class FormField
{
    public int Id { get; set; }
    public string? Label { get; set; }
    public FormFieldType Type { get; set; }
    public string Name { get; set; }
    public bool IsRequired { get; set; }
    public bool IsHidden { get; set; }
    public bool IsDisabled { get; set; }
    public string? Value { get; set; }
    public int SortOrder { get; set; }
    public string? Placeholder { get; set; }
    public string? ApiUrl { get; set; }
    
    // New property for the foreign key
    public int FormId { get; set; }

    // Navigation property to represent the relationship
    public Form Form { get; set; }
}