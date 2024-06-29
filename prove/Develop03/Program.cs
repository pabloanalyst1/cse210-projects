using System;
using System.Collections.Generic;

public class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int EndVerse { get; private set; }

    // Constructor para un solo versículo
    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = verse;
    }

    // Constructor para un rango de versículos
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    // Método para obtener el texto de la referencia
    public string GetDisplayText()
    {
        if (StartVerse == EndVerse)
            return $"{Book} {Chapter}:{StartVerse}";
        else
            return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
    }
}

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Método para ocultar la palabra
    public void Hide()
    {
        _isHidden = true;
    }

    // Método para mostrar la palabra
    public void Show()
    {
        _isHidden = false;
    }

    // Método para obtener el texto de la palabra
    public string GetDisplayText()
    {
        return _isHidden ? "_____" : _text;
    }

    // Propiedad para verificar si la palabra está oculta
    public bool IsHidden
    {
        get { return _isHidden; }
    }
}

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (string word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    // Método para ocultar palabras aleatorias
    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = Math.Min(3, _words.Count);
        for (int i = 0; i < wordsToHide; i++)
        {
            _words[random.Next(_words.Count)].Hide();
        }
    }

    // Método para obtener el texto de la escritura
    public string GetDisplayText()
    {
        string scriptureText = _reference.GetDisplayText() + " - ";
        foreach (Word word in _words)
        {
            scriptureText += word.GetDisplayText() + " ";
        }
        return scriptureText.Trim();
    }

    // Propiedad para verificar si todas las palabras están ocultas
    public bool AllWordsHidden
    {
        get
        {
            foreach (Word word in _words)
            {
                if (!word.IsHidden)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");

        // Crear una referencia y escritura de ejemplo
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords();

            if (scripture.AllWordsHidden)
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine();
                Console.WriteLine("All words are hidden. Program will exit now.");
                break;
            }
        }
    }
}
