// =============================================================================
// NAME: Jarl Ramos
// ASGT: N/A
// ORGN: N/A
// FILE: AccessionLog.cs
// DATE: 2 March 2023
// =============================================================================
// Description:
// This class represents a log containing accessioned patient data.

using System;
using System.IO;
using System.Collections.Generic;

namespace Accession
{
    public class AccessionLog
    {
        private List<AccessionData> aLog = new List<AccessionData>();

        // adds data to the accession log
        public void AddToLog(AccessionData ad)
        {
            aLog.Add(ad);
        }

        // searches the log for an accession ID and prints the corresponding
        // data if the ID is found
        public void SearchLog(string id)
        {
            bool isFound = false;

            // if the accession log is empty
            if (aLog.Count == 0)
            {
                Console.WriteLine("There are no entries in the accession log.");
            }
            else
            {
                // searches the log
                foreach (AccessionData i in aLog)
                {
                    if (i.GetID() == id)
                    {
                        Console.WriteLine("********************");
                        Console.WriteLine("Patient Demographics");
                        Console.WriteLine("********************");
                        Console.WriteLine("Accession ID: {0}", i.GetID());
                        Console.WriteLine("First Name: {0}", i.GetFN());
                        Console.WriteLine("Last Name: {0}", i.GetLN());
                        Console.WriteLine("Client Code: {0}", i.GetCC());
                        Console.WriteLine("Date of Birth: {0}", i.GetDOB());
                        Console.WriteLine("Sample Type: {0}",
                                          i.GetSampleType());
                        Console.WriteLine("Gender: {0}", i.GetGender());
                        i.PrintMeds();
                        isFound = true;
                    }
                }

                // if the ID isn't found
                if (!isFound)
                {
                    Console.WriteLine("The ID was not found in the log.");
                }
            }
        }

        // prints accession log
        public void PrintLog()
        {
            if (aLog.Count == 0)
            {
                Console.WriteLine("There are no entries in the accession log.");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("*************");
                Console.WriteLine("Accession Log");
                Console.WriteLine("*************");
                Console.WriteLine("");

                Console.WriteLine(
                      "ID         Sample Type "
                    + "Client Code  First Name   Last Name    DOB        "
                    + "Gender\n"
                    + "---------- ----------- ------------ ------------ "
                    + "------------ ---------- ------");
                foreach (AccessionData i in aLog)
                {
                    Console.WriteLine(
                        "{0, -10} {1, -11} {2, -12} {3, -12} {4, -12} " +
                        "{5, 10} {6, -6}", i.GetID(), i.GetSampleType(),
                        i.GetCC(), i.GetFN(), i.GetLN(), i.GetDOB(),
                        i.GetGender());
                }
            }  
        }

        // writes the accession log in a file named "accession_log.txt"
        public void OutputLog()
        {
            if (aLog.Count != 0)
            {
                string fileName = "accession_log.txt";
                try
                {
                    using (StreamWriter w = new StreamWriter(fileName))
                    {
                        w.WriteLine("");
                        w.WriteLine("*************");
                        w.WriteLine("Accession Log");
                        w.WriteLine("*************");
                        w.WriteLine("");

                        w.WriteLine(
                              "ID         Sample Type "
                            + "Client Code  First Name   Last Name    DOB"
                            + "        "
                            + "Gender\n"
                            + "---------- ----------- ------------ "
                            + "------------ "
                            + "------------ ---------- ------");
                        foreach (AccessionData i in aLog)
                        {
                            w.WriteLine(
                                "{0, -10} {1, -11} {2, -12} {3, -12} " +
                                "{4, -12} " +
                                "{5, 10} " +
                                "{6, -6}", i.GetID(), i.GetSampleType(),
                                i.GetCC(), i.GetFN(), i.GetLN(), i.GetDOB(),
                                i.GetGender());
                        }
                    }
                }
                catch (Exception exp)
                {
                    Console.Write(exp.Message);
                }

            }
            
        }
    }
}
