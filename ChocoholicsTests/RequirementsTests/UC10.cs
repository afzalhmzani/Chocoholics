using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chocoholics.Business;
using System.Collections.Generic;

namespace Chocoholics.RequirementsTests
{
    [TestClass]
    public class UC10
    {
        [TestMethod]
        public void TC24_VerifyEftRecordCreatedAndSaved()
        {
            string path = @"C:\temp\providercharges.txt";
            //need to call SumTotalWeeklyCharges to add provider charges
            ChocAnSystem chocAnSystem = new ChocAnSystem();
            List<EFT> weeklyCharges = chocAnSystem.ProviderChargesForWeek();
            chocAnSystem.SaveProviderChargesForWeek(weeklyCharges, path);

            System.Diagnostics.Process.Start(path);
        }

        [TestMethod]
        public void TC25_VerifyErrorLogWhenChargesLessThanOrEqualToZero()
        {
            string path = @"C:\temp\providercharges.txt";
            ChocAnSystem chocAnSystem = new ChocAnSystem();

            // start with new one.
            Utilities.ErrorLogger.DeleteLog();
            Assert.IsFalse(System.IO.File.Exists(Utilities.ErrorLogger.LogPath));

            // fake list
            List<EFT> weeklyCharges = new List<EFT>();
            weeklyCharges.Add(new EFT("Fake provider", 111111111, 0.00M));
            weeklyCharges.Add(new EFT("Fake provider1", 222222222, -10.00M));
            chocAnSystem.SaveProviderChargesForWeek(weeklyCharges, path);

            Assert.IsTrue(System.IO.File.Exists(Utilities.ErrorLogger.LogPath));
            Assert.IsTrue(System.IO.File.ReadAllLines(Utilities.ErrorLogger.LogPath).Length == 2);

            // only the header line should be in this file.
            Assert.IsTrue(System.IO.File.ReadAllLines(path).Length == 1);            
        }
    }
}
