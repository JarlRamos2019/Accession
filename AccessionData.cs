// =============================================================================
// NAME: Jarl Ramos
// ASGT: N/A
// ORGN: N/A
// FILE: AccessionData.cs
// DATE: 2 March 2023
// =============================================================================
// Description:
// This class represents patient information collected from a test requisition
// and demographics sheet that were sent with a urine or oral fluid sample from
// the patient. The accession ID, patient's first name, last name, client code,
// date of birth, sample type, gender, and medications are contained in this
// class.

using System;
using System.Collections.Generic;
namespace Accession
{
    public class AccessionData
    {
        private string accessionID;
        private string firstName;
        private string lastName;
        private string clientCode;
        private int birthMonth;
        private int birthDay;
        private int birthYear;
        private SampleType type;
        private Gender gender;
        private List<string> meds = new List<string>();

        // instantiates object using the given patient data
        public AccessionData(string id, string fn, string ln, string cc, int bm,
                             int bd, int by, SampleType t, Gender g,
                             List<string> md)
        {
            accessionID = id;
            firstName   = fn;
            lastName    = ln;
            clientCode  = cc;
            birthMonth  = bm;
            birthDay    = bd;
            birthYear   = by;
            type        = t;
            gender      = g;
            meds        = md;
        }

        // gets accession ID
        public string GetID()
        {
            return accessionID;
        }

        // gets first name
        public string GetFN()
        {
            return firstName;
        }

        // gets last name
        public string GetLN()
        {
            return lastName;
        }

        // gets client code
        public string GetCC()
        {
            return clientCode;
        }

        // gets birth month
        public int GetBM()
        {
            return birthMonth;
        }

        // gets birth day
        public int GetBD()
        {
            return birthDay;
        }

        // gets birth year
        public int GetBY()
        {
            return birthYear;
        }

        // gets full date of birth
        public string GetDOB()
        {
            return birthMonth.ToString() + "/" + birthDay.ToString() + "/"
                   + birthYear.ToString();
        }

        // returns string containing the sample type according to enum data
        public string GetSampleType()
        {
            string typeStr;

            if (type == SampleType.Urine)
            {
                typeStr = "Urine";
            }
            else
            {
                typeStr = "Oral Fluid";
            }

            return typeStr;
            
        }

        // returns string containing the gender according to enum data
        public string GetGender()
        {
            string genStr;

            if (gender == Gender.Male)
            {
                genStr = "Male";
            }
            else
            {
                genStr = "Female";
            }

            return genStr;
        }

        // prints list of medications associated with the accession
        public void PrintMeds()
        {
            if (meds.Count == 0)
            {
                Console.WriteLine("No Medications");
            }
            else
            {
                Console.WriteLine("***************");
                Console.WriteLine("Medication List");
                Console.WriteLine("***************");

                foreach (string x in meds)
                {
                    Console.WriteLine("{0}", x);
                }
            }    
        }
    }
}

public enum SampleType
{
    Urine,
    OralFluid
}

public enum Gender
{
    Male,
    Female
}