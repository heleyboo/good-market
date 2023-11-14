namespace GoodMarket.Models;

public class Form
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<FormField> Fields { get; set; }
    public Category Category { get; set; }
}

public enum FormFieldType
{
    Files,
    Text,
    Date,
    Time,
    Password,
    Email,
    Phone,
    SelectOptions
}

public class Option
{
    public int Id { get; set; }
    public string Value { get; set; }
}

public class FormField
{
    public string Label { get; set; }
    public FormFieldType Type { get; set; }
    public bool IsRequired { get; set; }
    public List<Option> Options { get; set; }
}