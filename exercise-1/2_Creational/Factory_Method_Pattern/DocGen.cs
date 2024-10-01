using System;

// Product Interface
public interface IDocument
{
    void Generate();
}

// Concrete Product: Word Document
public class WordDocument : IDocument
{
    public void Generate()
    {
        Console.WriteLine("Generating Word Document...");
    }
}

// Concrete Product: PDF Document
public class PDFDocument : IDocument
{
    public void Generate()
    {
        Console.WriteLine("Generating PDF Document...");
    }
}

// Concrete Product: HTML Document
public class HTMLDocument : IDocument
{
    public void Generate()
    {
        Console.WriteLine("Generating HTML Document...");
    }
}

// Creator (Factory) Class
public abstract class DocumentFactory
{
    public abstract IDocument CreateDocument();
}

// Concrete Factory: WordDocumentFactory
public class WordDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new WordDocument();
    }
}

// Concrete Factory: PDFDocumentFactory
public class PDFDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new PDFDocument();
    }
}

// Concrete Factory: HTMLDocumentFactory
public class HTMLDocumentFactory : DocumentFactory
{
    public override IDocument CreateDocument()
    {
        return new HTMLDocument();
    }
}

class Program
{
    static void Main()
    {
        // Create Word Document
        DocumentFactory wordFactory = new WordDocumentFactory();
        IDocument wordDoc = wordFactory.CreateDocument();
        wordDoc.Generate();

        // Create PDF Document
        DocumentFactory pdfFactory = new PDFDocumentFactory();
        IDocument pdfDoc = pdfFactory.CreateDocument();
        pdfDoc.Generate();

        // Create HTML Document
        DocumentFactory htmlFactory = new HTMLDocumentFactory();
        IDocument htmlDoc = htmlFactory.CreateDocument();
        htmlDoc.Generate();
    }
}
