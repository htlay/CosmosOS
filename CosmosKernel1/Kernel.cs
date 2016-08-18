using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.Globalization;
namespace FilesHandlers
{
    public class Kernel : Sys.Kernel
    {
        commands com = new commands();
        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully Ver 1.0");
        }

        protected override void Run()
        {
            Console.Write("root>");
            String name;
            List<String> filename = new List<String>();

            int count = 0;
            String comment;

            String input = Console.ReadLine();

            String[] Arr = input.Split(new char[] { ' ' }, 2);
            String arg = String.IsNullOrEmpty(Arr[1]) ? "" : Arr[1];
            filename.Add(Arr[1]);

            comment = Arr[0];
            switch (comment)
            {
                case "Echo":
                    com.getEcho(arg);
                    break;
                case "Set":
                    com.Set(arg);
                    break;
                case "Create":
                    com.Create(arg);
                    break;
                case "Open":
                    com.Open(arg);
                    break;
                case "Dir":
                    com.Dir(arg);
                    break;
                case "Add":
                    com.Add(arg);
                    break;
                case "Sub":
                    com.Sub(arg);
                    break;
                case "Mul":
                    com.Mul(arg);
                    break;
                case "Div":
                    com.Div(arg);
                    break;
                case "Run":
                    com.Run(arg);
                    break;
                case "RunAll":
                    com.RunMultiBat(arg);
                    break;
                default:
                    break;
            }

        }
        public class File
        {
            commands com = new commands();
            private String filename = "filename.txt";
            private String[] data = new String[10000000];
            private int count = 0;
            public File(String file)
            {
                filename = file;
            }
            public String getName()
            {
                return filename;
            }
            public String[] getData()
            {
                return data;
            }
            public void create()
            {
                String input = Console.ReadLine();
                while (input != "Save")
                {
                    data[count] = input;
                    input = Console.ReadLine();
                    count++;
                }
            }
            public void Open(String args)
            {
                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine(data[i]);
                }
                String input = Console.ReadLine();
                while (input != "Save")
                {
                    data[count] = input;
                    input = Console.ReadLine();
                    count++;
                }
            }
            public int getCount()
            {
                return count;

            }
            public void run(String args)
            {
                String lineData;
                for (int i = 0; i < count; i++)
                {
                    lineData = data[i];
                    String[] Arr = lineData.Split(new char[] { ' ' }, 2);
                    String arg = String.IsNullOrEmpty(Arr[1]) ? "" : Arr[1];
                    String comment = Arr[0];
                    switch (comment)
                    {
                        case "Echo":
                            com.getEcho(arg);
                            break;
                        case "Set":
                            com.Set(arg);
                            break;
                        case "Add":
                            com.Add(arg);
                            break;
                        case "Sub":
                            com.Sub(arg);
                            break;
                        case "Mul":
                            com.Mul(arg);
                            break;
                        case "Div":
                            com.Div(arg);
                            break;
                        default:
                            Console.WriteLine("This line content wrong input!!");
                            break;
                    }
                }
            }

            public static int CountNonSpaceChars(String value)
            {
                int count = 0;

                foreach (char c in value)
                {
                    if (!char.IsWhiteSpace(c))
                    {
                        count++;
                    }
                }
                return count;
            }
            public int getFileSize(String args)
            {
                String lineData;
                int size = 0;
                for (int i = 0; i < count; i++)
                {
                    lineData = data[i];
                    size += CountNonSpaceChars(lineData);
                }
                return size;
            }
        }
        public class commands
        {
            private Variable[] collection = new Variable[100];
            private int varCount = 0;

            private List<File> FileN = new List<File>();
            int countN = 0;

            public void Open(String args)
            {
                int i = 0;
                File fo = null;
                while (i < countN)
                {
                    if (args == FileN[i].getName())
                    {
                        fo = FileN[i];
                        break;
                    }
                    i++;
                }
                if (fo == null)
                {
                    Console.WriteLine("File No Found!");
                }
                else
                {
                    fo.Open(args);
                }
            }
            public void Div(String args)
            {
                try
                {
                    String[] Arr = args.Split(new char[] { ' ' }, 3);

                    bool x = false;
                    int y = 0;
                    int var1, var2;
                    //Console.WriteLine(varCount);

                    while (y < varCount)
                    {

                        if (collection[y].getName() == Arr[0])
                        {
                            x = true;
                            break;
                        }
                        y++;
                    }
                    if (x)
                    {
                        var1 = collection[y].getData();
                    }
                    else
                    {
                        var1 = Int32.Parse(Arr[0]);
                    }
                    x = false;
                    y = 0;
                    //Console.WriteLine(varCount);

                    while (y < varCount)
                    {
                        if (collection[y].getName() == Arr[1])
                        {
                            x = true;
                            break;
                        }
                        y++;
                    }
                    if (x)
                    {
                        var2 = collection[y].getData();
                    }
                    else
                    {
                        var2 = Int32.Parse(Arr[1]);
                    }
                    y = 0;
                    //Console.WriteLine(varCount);
                    while (y < varCount)
                    {
                        if (collection[y].getName() == Arr[2])
                        {
                            break;
                        }
                        y++;
                    }
                    // Console.WriteLine(varCount);
                    if (varCount != y)
                    {
                        collection[y].setUpdate(var1 + var2);
                    }
                    else
                    {
                        Variable poopy = new Variable(var1 / var2, Arr[2]);
                        collection[varCount] = poopy;
                        varCount++;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error!");
                }

            }
            public void Mul(String args)
            {
                try
                {
                    String[] Arr = args.Split(new char[] { ' ' }, 3);

                    bool x = false;
                    int y = 0;
                    int var1, var2;
                    //Console.WriteLine(varCount);

                    while (y < varCount)
                    {

                        if (collection[y].getName() == Arr[0])
                        {
                            x = true;
                            break;
                        }
                        y++;
                    }
                    if (x)
                    {
                        var1 = collection[y].getData();
                    }
                    else
                    {
                        var1 = Int32.Parse(Arr[0]);
                    }
                    x = false;
                    y = 0;
                    //Console.WriteLine(varCount);

                    while (y < varCount)
                    {
                        if (collection[y].getName() == Arr[1])
                        {
                            x = true;
                            break;
                        }
                        y++;
                    }
                    if (x)
                    {
                        var2 = collection[y].getData();
                    }
                    else
                    {
                        var2 = Int32.Parse(Arr[1]);
                    }
                    y = 0;
                    //Console.WriteLine(varCount);
                    while (y < varCount)
                    {
                        if (collection[y].getName() == Arr[2])
                        {
                            break;
                        }
                        y++;
                    }
                    //Console.WriteLine(varCount);
                    if (varCount != y)
                    {
                        collection[y].setUpdate(var1 + var2);
                    }
                    else
                    {
                        Variable poopy = new Variable(var1 * var2, Arr[2]);
                        collection[varCount] = poopy;
                        varCount++;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error!");
                }

            }
            public void Sub(String args)
            {
                try
                {
                    String[] Arr = args.Split(new char[] { ' ' }, 3);

                    bool x = false;
                    int y = 0;
                    int var1, var2;
                    //Console.WriteLine(varCount);

                    while (y < varCount)
                    {

                        if (collection[y].getName() == Arr[0])
                        {
                            x = true;
                            break;
                        }
                        y++;
                    }
                    if (x)
                    {
                        var1 = collection[y].getData();
                    }
                    else
                    {
                        var1 = Int32.Parse(Arr[0]);
                    }
                    x = false;
                    y = 0;
                    //Console.WriteLine(varCount);

                    while (y < varCount)
                    {
                        if (collection[y].getName() == Arr[1])
                        {
                            x = true;
                            break;
                        }
                        y++;
                    }
                    if (x)
                    {
                        var2 = collection[y].getData();
                    }
                    else
                    {
                        var2 = Int32.Parse(Arr[1]);
                    }
                    y = 0;
                    //Console.WriteLine(varCount);
                    while (y < varCount)
                    {
                        if (collection[y].getName() == Arr[2])
                        {
                            break;
                        }
                        y++;
                    }
                    //Console.WriteLine(varCount);
                    if (varCount != y)
                    {
                        collection[y].setUpdate(var1 + var2);
                    }
                    else
                    {
                        Variable poopy = new Variable(var1 - var2, Arr[2]);
                        collection[varCount] = poopy;
                        varCount++;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error!");
                }

            }
            public void Add(String args)
            {
                try
                {
                    String[] Arr = args.Split(new char[] { ' ' }, 3);

                    bool x = false;
                    int y = 0;
                    int var1, var2;
                    //Console.WriteLine(varCount);

                    while (y < varCount)
                    {

                        if (collection[y].getName() == Arr[0])
                        {
                            x = true;
                            break;
                        }
                        y++;
                    }
                    if (x)
                    {
                        var1 = collection[y].getData();
                    }
                    else
                    {
                        var1 = Int32.Parse(Arr[0]);
                    }
                    x = false;
                    y = 0;
                    //Console.WriteLine(varCount);

                    while (y < varCount)
                    {
                        if (collection[y].getName() == Arr[1])
                        {
                            x = true;
                            break;
                        }
                        y++;
                    }
                    if (x)
                    {
                        var2 = collection[y].getData();
                    }
                    else
                    {
                        var2 = Int32.Parse(Arr[1]);
                    }
                    y = 0;
                    //Console.WriteLine(varCount);
                    while (y < varCount)
                    {
                        if (collection[y].getName() == Arr[2])
                        {
                            break;
                        }
                        y++;
                    }
                    //Console.WriteLine(varCount);
                    if (varCount != y)
                    {
                        collection[y].setUpdate(var1 + var2);
                    }
                    else
                    {
                        Variable poopy = new Variable(var1 + var2, Arr[2]);
                        collection[varCount] = poopy;
                        varCount++;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error!");
                }
            }
            public void Dir(String args)
            {
                for (int i = 0; i < countN; i++)
                {
                    args = FileN[i].getName();
                    Console.WriteLine("filename: " + FileN[i].getName());
                    Console.WriteLine(getName(args) + "  " + getExt(args) + "  " + sizeofFile(args) + "Byte  " + Update());
                    Console.WriteLine("----------------------------------------");
                }
            }
            public String getName(String arg)
            {
                arg = arg.Substring(0, arg.LastIndexOf('.'));
                return arg;
                //Console.Write(arg + " ");
            }
            public String getExt(String arg)
            {
                arg = arg.Substring(arg.LastIndexOf('.') + 1);
                return arg;
                //Console.Write(arg + " ");
            }
            public string date;
            int year = 2016;
            string[] month = new string[12] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            int monthNumber = 0;
            int day = 1;

            public String Update()
            {
                AddOneDay();
                date = (day + "." + month[monthNumber] + " " + year);
                return date;
            }

            public void AddOneDay()
            {
                day++;

                if (monthNumber == 1 && day == 29)
                {
                    day = 1;
                    monthNumber++;
                }
                else if (day == 31 && (monthNumber == 3 || monthNumber == 5 || monthNumber == 8 || monthNumber == 10))
                {
                    day = 1;
                    monthNumber++;
                }
                else if (day == 32 && monthNumber == 11)
                {
                    year++;
                    day = 1;
                    monthNumber = 0;
                }
                else if (day == 32)
                {
                    day = 1;
                    monthNumber++;
                }
            }


            public void Create(String args)
            {
                File filename = new File(args);
                filename.create();
                FileN.Add(filename);
                countN++;
            }
            public int sizeofFile(String args)
            {
                int size = 0;
                int i = 0;
                File fo = null;
                while (i < countN)
                {
                    if (args == FileN[i].getName())
                    {
                        fo = FileN[i];
                        break;
                    }
                    i++;
                }
                if (fo == null)
                {
                    Console.WriteLine("File No Found!");
                    //break;
                }
                else
                {
                    size = fo.getFileSize(args);
                }
                return size;
            }
            public void Run(String args)
            {
                int i = 0;
                int k = 0;
                int countbatch = 0;
                Queue<String[]> fo = new Queue<String[]>();
                Queue<int> size = new Queue<int>();
                Queue<int> location = new Queue<int>();
                String[] temp;
                int tempCount;
                int locat;
                int p = 0;
                foreach (string ss in args.Split(new char[] { ' ' }))
                {
                    i = 0;
                    while (i < countN)
                    {
                        if (ss == FileN[i].getName())
                        {
                            fo.Enqueue(FileN[i].getData());
                            size.Enqueue(FileN[i].getCount());
                            location.Enqueue(0);
                            countbatch++;
                            break;
                        }
                        i++;

                    }
                }
                while (k < countbatch)
                {

                    temp = fo.Dequeue();
                    tempCount = size.Dequeue();
                    locat = location.Dequeue();


                    String[] command = temp[locat].Split(new char[] { ' ' }, 2);
                    switch (command[0])
                    {
                        case "Echo":
                            getEcho(command[1]);
                            break;
                        case "Set":
                            Set(command[1]); 
                            break;
                        case "Add":
                            Add(command[1]);
                            break;
                        case "Sub":
                            Sub(command[1]);
                            break;
                        case "Mul":
                            Mul(command[1]);
                            break;
                        case "Div":
                            Div(command[1]);
                            break;
                        case "Run":
                            Run(command[1]);
                            break;
                        default:
                            Console.WriteLine("This line content wrong input!!");
                            break;
                    }
                    locat++;
                    if (!(locat < tempCount))
                    {
                        k++;
                    }
                    else
                    {
                        fo.Enqueue(FileN[i].getData());
                        size.Enqueue(FileN[i].getCount());
                        location.Enqueue(locat);
                    }
                }
            }


            public void RunMultiBat(String args)
            {
                int i = 0;
                int k = 0;
                int countbatch = 0;
                Queue<String[]> fo = new Queue<String[]>();
                Queue<int> size = new Queue<int>();
                Queue<int> location = new Queue<int>();
                String[] temp;
                int tempCount;
                int locat;
                int p = 0;
                foreach (string ss in args.Split(new char[] { ' ' }))
                {
                    i = 0;
                    while (i < countN)
                    {
                        if (ss == FileN[i].getName())
                        {
                            fo.Enqueue(FileN[i].getData());
                            size.Enqueue(FileN[i].getCount());
                            location.Enqueue(0);
                            countbatch++;
                            break;
                        }
                        i++;

                    }
                }
                while (k < countbatch)
                {

                    temp = fo.Dequeue();
                    tempCount = size.Dequeue();
                    locat = location.Dequeue();
                    String[] command = temp[locat].Split(new char[] { ' ' }, 2);
                    switch (command[0])
                    {
                        case "Echo":
                            getEcho(command[1]);
                            break;
                        case "Set":
                            Set(command[1]);
                            break;
                        case "Add":
                            Add(command[1]);
                            break;
                        case "Sub":
                            Sub(command[1]);
                            break;
                        case "Mul":
                            Mul(command[1]);
                            break;
                        case "Div":
                            Div(command[1]);
                            break;
                        case "Run":
                            Run(command[1]);
                            break;
                        default:
                            Console.WriteLine("This line content wrong input!!");
                            break;
                    }
                    locat++;
                    if (!(locat < tempCount))
                    {
                        k++;
                    }
                    else
                    {
                        fo.Enqueue(FileN[i].getData());
                        size.Enqueue(FileN[i].getCount());
                        location.Enqueue(locat);
                    }
                }

            }

            public void getEcho(String args)
            {
                String v = args;
                int i = 0;
                while (i < varCount)
                {

                    if (collection[i].getName() == v)
                    {
                        v = "" + collection[i].getData();
                        break;
                    }
                    i++;
                }
                Console.WriteLine(args + " = " + v);
            }
            public void Set(String args)
            {
                string[] Values = args.Split(new Char[] { ' ' }, 2);

                Variable v = new Variable(Int32.Parse(Values[1]), Values[0]);
                collection[varCount] = v;
                varCount++;
            }
        }
        public class Variable
        {
            private int data;
            private String name;

            public Variable(int x, String y)
            {
                this.data = x;
                this.name = y;
            }
            public int getData()
            {
                return data;
            }
            public String getName()
            {
                return name;
            }
            public void setUpdate(int x)
            {
                this.data = x;
            }
        }

    }
}