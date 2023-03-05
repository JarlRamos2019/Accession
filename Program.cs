// =============================================================================
// NAME: Jarl Ramos
// ASGT: N/A
// ORGN: N/A
// FILE: Program.cs
// DATE: 2 March 2023
// =============================================================================
// Description:
// This program is used for entering and exploring patient data collected from
// urine and oral fluid samples. Information collected includes name,
// DOB, gender, sample type, accession ID, client code, and medications.
// The user can view the accession log as well as search for any entries in the
// log. When the program is finished, an output file with all the accession data
// is created. This program is meant to emulate more well-known laboratory
// information management systems such as STARLIMS.

using System;
using System.Collections.Generic;

namespace Accession
{
    class Program
    { 
        static void Main(string[] args)
        {
            // holds all accession data
            AccessionLog log = new AccessionLog();
            char userInput;
            char input3;
            string input4;
            char input5;
            char input6;
            char input7;
            string searchID;
            string medName;
            // a is accession ID, b is first name, c is last name, and d is
            // client code
            string a, b, c, d;
            // f is birth day, g is birth month, h is birth year
            int f, g, h;
            // m represents input for sample type (urine/oral fluid)
            // n represents input for gender (male/female)
            char m, n;
            SampleType p;
            Gender q;
      
            while (true)
            {
                // main menu interface------------------------------------------
                Console.WriteLine("*************************");
                Console.WriteLine("********Main Menu********");
                Console.WriteLine("*************************");
                Console.WriteLine("(k) Enter New Accession");
                Console.WriteLine("(p) View Accession Log");
                Console.WriteLine("(i) Search For Accession");
                Console.WriteLine("(q) Quit");
                Console.WriteLine("*************************");
                Console.WriteLine("*************************");
                Console.WriteLine("*************************");
                userInput = Convert.ToChar(Console.ReadLine());

                // quit the program and output the accession log file
                if (userInput == 'q')
                {
                    Console.WriteLine("Generating accession log...");
                    log.OutputLog();
                    Console.WriteLine("Accession log created.");
                    Console.WriteLine("Exiting program...");
                    break;
                }
                else if (userInput == 'p')
                {
                    // accession log interface----------------------------------
                    log.PrintLog();

                    Console.WriteLine("");
                    Console.WriteLine("Press any key to return to main menu:");
                    input4 = Console.ReadLine();
                    if (input4 == "")
                    {
                        ;
                    }

                }
                else if (userInput == 'i')
                {
                    // search interface-----------------------------------------
                    do
                    {
                        Console.WriteLine("Enter an accession ID: ");
                        searchID = Console.ReadLine();
                        // patient info will also be printed
                        log.SearchLog(searchID);

                        Console.WriteLine("Press 'q' to quit. Otherwise, " +
                            "press any other key to continue searching: ");
                        input3 = Convert.ToChar(Console.ReadLine());

                    } while (input3 != 'q');
                }
                else
                {
                    // new accession interface----------------------------------
                    do
                    {
                        // r is the patient's medication list
                        List<string> r = new List<string>();

                        // enter accession data
                        Console.WriteLine("Enter the accession ID: ");
                        a = Console.ReadLine();
                        Console.WriteLine("Enter the first name: ");
                        b = Console.ReadLine();
                        Console.WriteLine("Enter the last name: ");
                        c = Console.ReadLine();
                        Console.WriteLine("Enter the client code: ");
                        d = Console.ReadLine();
                        Console.WriteLine("Enter the birth month:");
                        f = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the birth day: ");
                        g = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the birth year: ");
                        h = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter 'u' for urine or " +
                            "'o' for oral fluid: ");
                        m = Convert.ToChar(Console.ReadLine());

                        // translates user input to enum data
                        if (m == 'u')
                        {
                            p = SampleType.Urine;
                        }
                        else
                        {
                            p = SampleType.OralFluid;
                        }

                        Console.WriteLine("Enter 'm' for male or 'f' for " +
                            "female: ");
                        n = Convert.ToChar(Console.ReadLine());

                        // translates user input to enum data
                        if (n == 'm')
                        {
                            q = Gender.Male;
                        }
                        else
                        {
                            q = Gender.Female;
                        }

                        // enter medications
                        Console.WriteLine("Any medications to add? (y/n):");
                        input6 = Convert.ToChar(Console.ReadLine());

                        if (input6 == 'y')
                        {
                            // medication interface-----------------------------
                            do
                            {
                                Console.WriteLine("Enter medication: ");
                                medName = Console.ReadLine();
                                r.Add(medName);
                                Console.WriteLine("{0} added.", medName);
                                Console.WriteLine("Press 'q' to finish adding" +
                                    " medications, otherwise press any other" +
                                    " key to continue: ");
                                input7 = Convert.ToChar(Console.ReadLine());
                            }
                            while (input7 != 'q');
                        }

                        Console.WriteLine("Adding accession data to log...");
                        // AccessionData object holding all user input
                        AccessionData ad = new AccessionData(a, b, c, d, f, g,
                            h, p, q, r);
                        // add data to the accession log
                        log.AddToLog(ad);

                        Console.WriteLine("Accession data successfully added.");
                        Console.WriteLine("Press 'q' to quit. Otherwise," +
                            " press any other key to enter another" +
                            " accession: ");
                        input5 = Convert.ToChar(Console.ReadLine());
                    } while (input5 != 'q'); 
                }
            }
        }
    }
}
