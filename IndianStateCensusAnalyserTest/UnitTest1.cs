using NUnit.Framework;
using System.Collections.Generic;
using IndianStateCensusAnalyserProject;
using IndianStateCensusAnalyserProject.DTO;
using static IndianStateCensusAnalyserProject.CensusAnalyser;

namespace IndianStateCensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"C:\Users\samee\source\repos\IndianCensusAnalyserDemo\Utilities\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\samee\source\repos\IndianCensusAnalyserDemo\Utilities\WrongIndiaStateCensusData.csv";
        static string delimiterIndianCensusFilePath = @"C:\Users\samee\source\repos\IndianCensusAnalyserDemo\Utilities\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\samee\source\repos\IndianCensusAnalyserDemo\Utilities\IndiaData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\samee\source\repos\IndianCensusAnalyserDemo\Utilities\IndiaStateCensusData.txt";
        static string indianStateCodeFilePath = @"C:\Users\samee\source\repos\IndianCensusAnalyserDemo\Utilities\IndiaStateCode.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\samee\source\repos\IndianCensusAnalyserDemo\Utilities\IndiaStateCode.txt";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\samee\source\repos\IndianCensusAnalyserDemo\Utilities\DelimiterIndiaStateCode.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\samee\source\repos\IndianCensusAnalyserDemo\Utilities\WrongIndiaStateCode.csv";
        IndianStateCensusAnalyserProject.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new IndianStateCensusAnalyserProject.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        [Test]
        public void GivenIncorrectDelimiterIndianStateCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusFilePath, wrongHeaderIndianCensusFilePath);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenIndianStateCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, wrongHeaderIndianCensusFilePath);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenIncorrectIndianStateCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, wrongHeaderIndianCensusFilePath);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        [Test]
        public void GivenCorrectIndianStateCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenIncorrectFile_WhenReaded_ShouldReturnCustomException()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFileType, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        [Test]
        public void GivenIncorrectFileType_WhenReaded_ShouldReturnCustomException()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFileType, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        [Test]
        public void GivenIncorrect_WhenReaded_ShouldReturnCustomException()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        [Test]
        public void GivenIncorrectFilePath_WhenReaded_ShouldReturnCustomException()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderStateCodeFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        [Test]
        public void GivenIncorrectStateCensusFilePath_WhenReaded_ShouldReturnCustomException()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusFilePath, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
    }
}