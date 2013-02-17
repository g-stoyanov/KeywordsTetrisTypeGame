using System;
using System.Threading;

class KeywordsTetrisTypeGame
{
    public struct Object
    {
        public bool isBonusWord;
        public bool isKeyWord;
        public int x;
        public int y;
        public string word;
        public ConsoleColor color;
    }
    static void Draw(int x, int y, ConsoleColor color, string str) // with this method draw in console
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(str);
        Console.ForegroundColor = ConsoleColor.White;
    }
    static void Main()
    {
        string[] keyWords = 
            { "abstract", "event", "new", "struct", "as", "explicit", "null", "switch", "base", "extern", "object", "this",
              "bool", "false", "operator", "throw", "break", "finally", "out", "true", "byte", "fixed", "override", "try",
              "case", "float", "params", "typeof", "catch", "for", "private", "uint", "char", "foreach", "protected", "ulong",
              "checked", "goto", "public", "unchecked", "class", "if", "readonly", "unsafe", "const", "implicit", "ref",
              "ushort", "continue", "in", "return", "using", "decimal", "int", "sbyte", "virtual", "default", "interface",
              "sealed", "volatile", "delegate", "internal", "short", "void", "do", "is", "sizeof", "while", "double", "lock",
              "stackalloc", "else", "long", "static", "enum", "namespace", "string", };
        string[] normalWords = 
            { "analyse", "analysis", "analyst", "analytic", "analytical", "analytically", "analyze", "approach", "approachable",
              "area", "assess", "assessable", "assessment", "assume", "assumed", "assuming", "assumption", "authoritative",
              "authoritatively", "authority", "availability", "available", "beneficial", "beneficiary", "benefit", "blinker",
              "concept", "conception", "conceptual", "conceptualize", "conceptually", "consist", "consistency", "consistent",
              "consistently", "constituency", "constituent", "constitute", "constitution", "constitutional", "constitutionally",
              "constitutive", "context", "contextual", "contextualization", "contextualize", "contextually", "contract",
              "contractor", "create", "creation", "creative", "creatively", "creativity", "creator", "data", "definable",
              "define", "definition", "derivation", "derivative", "derive", "disestablish", "disestablishment", "dissimilar",
              "dissimilarity", "distribute", "distribution", "distributional", "distributive", "distributor", "economic",
              "economical", "economically", "economics", "economist", "economy", "environment", "environmental", "environmentalism",
              "environmentalist", "environmentally", "establish", "established", "establishment", "estimate", "estimation",
              "evidence", "evident", "evidential", "evidently", "export", "exporter", "factor", "finance", "financial",
              "financially", "financier", "finance", "formula", "formulate", "formulation", "period", "function", "functional",
              "functionally", "ID", "identifiable", "identification", "identify", "identity", "illegal", "illegality", "illegally",
              "income", "inconsistency", "inconsistent", "inconsistently", "indicate", "indication", "indicative", "indicator",
              "indiscreet", "indiscreetly", "individual", "individualism", "individualist", "individualistic", "individuality",
              "individually", "insignificance", "insignificant", "insignificantly", "interpret", "interpretable", "interpretation",
              "interpretative", "interpretive", "invariable", "invariably", "involve", "involved", "involvement", "isolating",
              "issue", "issuer", "labor", "labour", "legal", "legality", "legally", "legislate", "legislation", "legislative",
              "legislator", "legislature", "major", "majority", "method", "methodical", "methodically", "methodological",
              "methodologically", "methodology", "misinterpret", "misinterpretation", "occur", "occurrence", "overestimate",
              "overestimation", "percentage", "period", "periodic", "periodical", "periodically", "policy", "principle",
              "principled", "procedural", "procedure", "proceed", "proceeding", "proceeds", "process", "processing", "reassess",
              "reassessment", "recreate", "recreation", "redefine", "redefinition", "redistribute", "redistribution",
              "redistributive", "reformulate", "reformulation", "reinterpret", "reinterpretation", "reoccur", "require",
              "requirement", "research", "researcher", "research", "respond", "respondent", "response", "responsive",
              "responsively", "responsiveness", "restructure", "restructuring", "role", "section", "sector", "significance",
              "significant", "significantly", "signify", "similar", "similarity", "similarly", "source", "specific", "specifically",
              "specification", "specificity", "specifics", "structural", "structurally", "structure", "theoretical",
              "theoretically", "theoretician", "theorist", "theory", "turn", "signal", "unapproachable", "unavailability",
              "unavailable", "unconstitutional", "unconstitutionally", "undefined", "underestimate", "underestimate", "uneconomic",
              "uneconomical", "unidentifiable", "uninvolved", "unprincipled", "unresponsive", "unstructured", "variability",
              "variable", "variably", "variance", "variant", "variation", "varied", "vary",};
        string[] bonusWords = {"Telerik", "svetlin", "nikolay", "pavel", "georgi", "doncho", "nakov", "kostov", "kolev", "georgiev", "minkov"};
        ConsoleColor[] color = { ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Magenta, ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.Gray, ConsoleColor.White };
        Object word = new Object();
        Random randomNumber = new Random();
        bool createNewWord = true;
        byte checkCycle = 0;
        int score = 0;
        int lives = 5;
        Console.WindowWidth = 80;
        Console.BufferWidth = 200;
        Console.WindowHeight = 40;
        Console.BufferHeight = 50;
        while (true)
        {
            if (createNewWord)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("\u2502" + new string(' ', 62) + "\u250c" + new string('\u2500', 12) + "\u2510");
                for (int i = 0; i < 34; i++)
                {
                    Console.WriteLine("\u2502" + new string(' ', 62) + "\u2502" + new string(' ', 12) + "\u2502");
                }
                Console.WriteLine("\u251c" + new string('\u2500', 20) + "\u253c" + new string('\u2500', 20) + "\u253c" + new string('\u2500', 20) + "\u2524" + new string(' ', 12) + "\u2502");
                Console.WriteLine("\u2502" + "      Key Word      " + "\u2502" + "     Normal Word    " + "\u2502" + "     Bonus Word     " + "\u2502" + new string(' ', 12) + "\u2502");
                Console.WriteLine("\u2514" + new string('\u2500', 20) + "\u2534" + new string('\u2500', 20) + "\u2534" + new string('\u2500', 20) + "\u2534" + new string('\u2500', 12) + "\u2518");
                Console.SetCursorPosition(64, 15);
                Console.WriteLine("Lives: " + lives);
                Console.SetCursorPosition(64, 17);
                Console.WriteLine("Score: " + score);
            }
            if (createNewWord)
            {
                word = new Object();
                int chance = randomNumber.Next(0, 101);
                if (chance < 5 && chance >= 0)
                {
                    word.word = bonusWords[randomNumber.Next(0, bonusWords.Length)];
                    word.isBonusWord = true;
                }
                else if (chance < 51 && chance >= 5)
                {
                    word.word = keyWords[randomNumber.Next(0, keyWords.Length)];
                    word.isKeyWord = true;
                }
                else
                {
                    word.word = normalWords[randomNumber.Next(0, normalWords.Length)];
                }
                word.y = 0;
                word.x = 30 - (word.word.Length / 2);
                createNewWord = false;
            }
            Draw(word.x, word.y, ConsoleColor.Black, word.word);
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true); 
                if (pressedKey.Key == ConsoleKey.LeftArrow)        
                {
                    if (word.x > 1)
                    {
                        word.x--;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)
                {
                    if (word.x < 62 - word.word.Length)
                    {
                        word.x++;
                    }
                }
                else if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    word.y = 35;
                    checkCycle = 0;
                }
            }
            if (checkCycle == 4)
            {
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(false);
                }
                word.y++;
                checkCycle = 0;
            }
            Draw(word.x, word.y, color[randomNumber.Next(0, color.Length)], word.word);
            checkCycle++;
            Thread.Sleep(150 - score);
            if (word.y == 35)
            {
                if (word.isKeyWord)
                {
                    if (word.x > 1 && word.x + word.word.Length < 21)
                    {
                        score++;
                    }
                    else
                    {
                        lives--; ;
                    }
                }
                else if (word.isBonusWord)
                {
                    if (word.x > 43 && word.x + word.word.Length < 63)
                    {
                        score += 10;
                        lives++;
                    }
                    else
                    {
                        lives -= 2;
                    }
                }
                else
                {
                    if (word.x > 22 && word.x + word.word.Length < 42)
                    {
                        score++;
                    }
                    else
                    {
                        lives--;
                    }
                }
                createNewWord = true;
                Draw(word.x, word.y, ConsoleColor.Black, word.word);
            }
            if (lives <= 0)
            {
                Console.Clear();
                Console.WriteLine("GAME OVER");
                Console.WriteLine();
                Console.WriteLine("Your score is: " + score);
                Console.WriteLine();
                Console.Write("Please press N to begin new game or E to exit:");
                while (true)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.N)
                    {
                        Main();
                    }
                    else if (pressedKey.Key == ConsoleKey.E)
                    {
                        break;
                    }
                }
                break;
            }
        }
    }
}