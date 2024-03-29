﻿using System;

namespace DelegatesExample
{
    public class Program
    {
        public delegate void SMS(string sms);

        static void Main(string[] args)
        {
            Delegate myDelegate = new Delegate();
            string text = "Hello Habibor";
            myDelegate.ProcessText(text, myDelegate.PrintingMethod);


            //for second delegates
            //SMS logics = PrintingSMS; //same as SMS logics = new SMS(PrintingSMS);
            //SMS logics = myDelegate.PrintingMethod; // myDelegate.PrintingMethod this method signature same as SMS delegates that so we can put this method in SMS delegate
            
            SMS logics = new SMS(PrintingSMS);
            SMS logics2 = new SMS(PrintingSMS2);
            SMS logics3 = logics + logics2;  // Two function pass add by + operator
            string sms = "This is my text from c# batch";
            ProcesSMS(sms, logics3);
        }

        public static void PrintingSMS(string sms)
        {
            Console.WriteLine($"--{sms}--");
        }
        public static void PrintingSMS2(string sms)
        {
            Console.WriteLine($"***{sms}***");
        }

        public static void ProcesSMS(string sms, SMS sendSms)
        {
            if (!string.IsNullOrWhiteSpace(sms))
            {
                sendSms.Invoke(sms);
            }
        }
    }
}
