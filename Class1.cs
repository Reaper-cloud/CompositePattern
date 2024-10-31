using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
public interface IDocumentComponent
{
    void Add(IDocumentComponent component);
    void Remove(IDocumentComponent component);
    void Display(int indent, IList<string> output);
}
public class Document
{
    private List<IDocumentComponent> _sections = new List<IDocumentComponent>();

    public void AddSection(IDocumentComponent section)
    {
        _sections.Add(section);
    }

    public void RemoveSection(IDocumentComponent section)
    {
        _sections.Remove(section);
    }

    public IList<string> Display()
    {
        List<string> output = new List<string>();
        foreach (var section in _sections)
        {
            section.Display(0, output);
        }
        return output;
    }
}
public class Paragraph : IDocumentComponent
{
    private string _text;

    public Paragraph(string text)
    {
        _text = text;
    }

    public void Add(IDocumentComponent component)
    {
        throw new NotSupportedException("Cannot add to a paragraph.");
    }

    public void Remove(IDocumentComponent component)
    {
        throw new NotSupportedException("Cannot remove from a paragraph.");
    }

    public void Display(int indent, IList<string> output)
    {
        output.Add(new string(' ', indent) + _text);
    }
}
public class Section : IDocumentComponent
{
    private string _title;
    private List<IDocumentComponent> _components = new List<IDocumentComponent>();

    public Section(string title)
    {
        _title = title;
    }

    public void Add(IDocumentComponent component)
    {
        _components.Add(component);
    }

    public void Remove(IDocumentComponent component)
    {
        _components.Remove(component);
    }

    public void Display(int indent, IList<string> output)
    {
        output.Add(new string(' ', indent) + _title);
        foreach (var component in _components)
        {
            component.Display(indent + 2, output);
        }
    }
}