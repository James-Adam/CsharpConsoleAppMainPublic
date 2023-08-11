using System.Xml.Serialization;

namespace CsharpConsoleAppMain.CsharpProgramming.ConsumingData;
/* The XmlRootAttribute allows you to set an alternate name
(PurchaseOrder) of the XML element, the element namespace; by
default, the XmlSerializer uses the class name. The attribute
also allows you to set the XML namespace for the element.  Lastly,
the attribute sets the IsNullable property, which specifies whether
the xsi:null attribute appears if the class instance is set to
a null reference. */

[Serializable]
[XmlRootAttribute("PurchaseOrder", Namespace = "http://www.cpandl.com",
    IsNullable = false)]
public class PurchaseOrder
{
    public string? OrderDate;
    /* The XmlArrayAttribute changes the XML element name
     from the default of "OrderedItems" to "Items". */

    [XmlArrayAttribute("Items")] public OrderedItem[]? OrderedItems;
    public decimal ShipCost;
    public Address? ShipTo;

    public decimal SubTotal;
    public decimal TotalCost;
}

[Serializable]
public class Address
{
    /* Setting the IsNullable property to false instructs the
       XmlSerializer that the XML attribute will not appear if
       the City field is set to a null reference. */

    [XmlElementAttribute(IsNullable = false)]
    public string? City;

    public string? Line1;
    /* The XmlAttribute instructs the XmlSerializer to serialize the Name
       field as an XML attribute instead of an XML element (the default
       behavior). */

    [XmlAttribute] public string? Name;

    public string? State;
    public string? Zip;
}

[Serializable]
public class OrderedItem
{
    public string? Description;
    public string? ItemName;
    public decimal LineTotal;
    public int Quantity;
    public decimal UnitPrice;

    /* Calculate is a custom method that calculates the price per item,
       and stores the value in a field. */

    public void Calculate()
    {
        LineTotal = UnitPrice * Quantity;
    }
}