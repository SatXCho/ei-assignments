using System;

// Strategy Interface
public interface ICompressionStrategy
{
    void Compress(string file);
}

// Concrete Strategy: ZIP Compression
public class ZipCompression : ICompressionStrategy
{
    public void Compress(string file)
    {
        Console.WriteLine($"Compressing {file} using ZIP compression.");
    }
}

// Concrete Strategy: RAR Compression
public class RarCompression : ICompressionStrategy
{
    public void Compress(string file)
    {
        Console.WriteLine($"Compressing {file} using RAR compression.");
    }
}

// Concrete Strategy: GZIP Compression
public class GzipCompression : ICompressionStrategy
{
    public void Compress(string file)
    {
        Console.WriteLine($"Compressing {file} using GZIP compression.");
    }
}

// Context: Compression Tool
public class CompressionTool
{
    private ICompressionStrategy compressionStrategy;

    public void SetCompressionStrategy(ICompressionStrategy strategy)
    {
        compressionStrategy = strategy;
    }

    public void CompressFile(string file)
    {
        compressionStrategy.Compress(file);
    }
}

class Program
{
    static void Main()
    {
        CompressionTool tool = new CompressionTool();

        // ZIP
        tool.SetCompressionStrategy(new ZipCompression());
        tool.CompressFile("myfile.txt");

        // RAR
        tool.SetCompressionStrategy(new RarCompression());
        tool.CompressFile("myfile.txt");

        // GZIP
        tool.SetCompressionStrategy(new GzipCompression());
        tool.CompressFile("myfile.txt");
    }
}
