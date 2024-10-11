using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace InterviewAmazon.CommonFunction
{
    public class ExcelHelper
    {
        static ExcelHelper()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public static List<TestData> ReadExcelFile(string filePath)
        {
            var testDataList = new List<TestData>();

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var excelReader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = excelReader.AsDataSet();

                   
                    var dataTable = result.Tables[0];

                    for (int row = 1; row < dataTable.Rows.Count; row++) 
                    {
                        var email = dataTable.Rows[row][0].ToString();
                        var password = dataTable.Rows[row][1].ToString();
                        var recipientEmail = dataTable.Rows[row][2].ToString();
                        var amount = dataTable.Rows[row][3].ToString();

                        testDataList.Add(new TestData
                        {
                            Email = email,
                            Password = password,
                            RecipientEmail = recipientEmail,
                            Amount = amount
                        });
                    }
                }
            }

            return testDataList;
        }
    }

    public class TestData
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RecipientEmail { get; set; }
        public string Amount { get; set; }
    }
}
