namespace GoodMarket.Models;

public class AttributeGroup: Auditable
{
    public int Id { get; set; }
    public string Code { get; set; }
    public int SortOrder { get; set; }
    public string Label { get; set; }
    public ICollection<Attribute> Attributes { get; set; }
}

public class Attribute : Auditable
{
    public int Id { get; set; }
    public int AttributeGroupId { get; set; }
    public int SortOrder { get; set; }
    public int MaxCharacters { get; set; }
    public string Label { get; set; }
    public string ValidationRegexp { get; set; }
    public bool WysiwygEnabled { get; set; }
    public decimal NumberMin { get; set; }
    public decimal NumberMax { get; set; }
    public bool DecimalAllowed { get; set; }
    public bool NegativeAllowed { get; set; }
    public DateTimeOffset MinDate { get; set; }
    public DateTimeOffset MaxDate { get; set; }
    public decimal MaxFileSize { get; set; }
    public string AllowedExtensions { get; set; }
    public bool IsRequired { get; set; }
    public bool IsUnique { get; set; }
    public string Placeholder { get; set; }
    public string Code { get; set; }
    public string Type { get; set; }
    public string BackendType { get; set; }
    public string Properties { get; set; }
    public AttributeGroup AttributeGroup { get; set; }
    public ICollection<AttributeOption> AttributeOptions { get; set; }
}

public class AttributeOption
{
    public int Id { get; set; }
    public string Label { get; set; }
    public string Code { get; set; }
    public int SortOrder { get; set; }
    public int AttributeId { get; set; }
    public Attribute Attribute { get; set; }
}

public class CategoryAttribute
{
    public int CategoryId { get; set; }
    public int AttributeId { get; set; }
    public Category Category { get; set; }
    public Attribute Attribute { get; set; }
}