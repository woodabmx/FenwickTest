using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FenwickTest
{
    class Program
    {
        // create a bool to be used for looping the menu
        public static bool isRunning = true;

        static void Main(string[] args)

        {
            // change the console windows title
            Console.Title = "\nFenwick Software Technical Task Created by Josh Wood\n";
            // write a welcome message to the console
            Console.WriteLine("\nWelcome to my Fenwick Software Technical Task, Created By Josh Wood.\n");
            // write an informative message to the console
            Console.WriteLine("\nto record stats type: record\n\nto view a summary of the stats type: summary\n\nfor an informative message on how to use the program type: help\n");

            // while loop created to ensure the console stays open after tasks
            while (isRunning == true)
            {
                Menu();
            }


        }

        static void Menu()
        {
            // input string used for executing tasks
            string Input = "";
            // read the users input
            Input = Console.ReadLine();

            if (Input == "summary")
            {
                // read the lines from stats.txt and add them to a list<string>
                List<string> summaryValues = File.ReadAllLines("stats.txt").ToList();
                // convert that list into a list<int> for purposes of calculating avg,min,max,count
                List<int> summaryInts = summaryValues.ConvertAll(s => Int32.Parse(s));

                // calculate the min,max,avg,count
                double avg = summaryInts.Average();
                int min = summaryInts.Min();
                int max = summaryInts.Max();
                int count = summaryInts.Count;

                // format the output to a text table
                Console.WriteLine("\n+--------------+------+\n\n| # of Entries | " + count + " |\n\n| Min. value   | " + min + " |\n\n| Max. value   | " + max + " |\n\n| Avg. value   | " + avg + " |\n\n+--------------+------+\n");


            }
            else if (Input == "record")
            {
                // informative message
                Console.WriteLine("\nplease input 5 numbers\n");

                // setup a list
                List<string> userInputList = new List<string>();

                // loop through the users input 5 times adding the input to our list
                for (int i = 0; i < 5; i++)
                {
                    string userInput = Console.ReadLine();
                    userInputList.Add(userInput);
                }

                // open the file stats.txt and for each item in our list write it into our stats.txt
                StreamWriter sw = new System.IO.StreamWriter("stats.txt");
                userInputList.ForEach(sw.WriteLine);
                sw.Close();
                // informative message
                Console.WriteLine("\nNumbers recorded into stats.txt!, type summary to view details or help for more info.\n");



            }
            else
            {
                // display the help message
                Console.WriteLine("\nHelp Menu\n\nto record stats type: stats record\n\nto view a summary of the stats type: summary\n\nfor an informative message on how to use the program type: help\n");


            }

        }
    }
}
