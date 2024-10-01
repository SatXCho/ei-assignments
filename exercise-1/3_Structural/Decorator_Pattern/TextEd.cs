using System;

public interface IText
{
    string GetText();
}

public class PlainText : IText
{
    private string text;

    public PlainText(string text)
    {
        this.text = text;
    }

    public string GetText()
    {
        return text;
    }
}

public abstract class TextDecorator : IText
{
    protected IText text;

    public TextDecorator(IText text)
    {
        this.text = text;
    }

    public virtual string GetText()
    {
        return text.GetText();
    }
}

public class BoldDecorator : TextDecorator
{
    public BoldDecorator(IText text) : base(text) { }

    public override string GetText()
    {
        return "<b>" + base.GetText() + "</b>";
    }
}

public class ItalicDecorator : TextDecorator
{
    public ItalicDecorator(IText text) : base(text) { }

    public override string GetText()
    {
        return "<i>" + base.GetText() + "</i>";
    }
}

public class UnderlineDecorator : TextDecorator
{
    public UnderlineDecorator(IText text) : base(text) { }

    public override string GetText()
    {
        return "<u>" + base.GetText() + "</u>";
    }
}

class Program
{
    static void Main()
    {
        IText plainText = new PlainText("Hello World");

        IText boldText = new BoldDecorator(plainText);
        Console.WriteLine(boldText.GetText());

        IText italicText = new ItalicDecorator(boldText);
        Console.WriteLine(italicText.GetText());

        IText underlineText = new UnderlineDecorator(italicText);
        Console.WriteLine(underlineText.GetText());
    }
}
