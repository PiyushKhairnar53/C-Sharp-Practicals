using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using ClosedXML.Excel;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace FileApplication
{
    internal class FileClass
    {

        string? filePath;
        string? fileExt;


        public void SelectFiles()
        {
            string directoryPath = @"D:\";
            DirectoryInfo place = new DirectoryInfo(directoryPath);
            FileInfo[] Files = place.GetFiles();

            string? wantToShowAgain;
            do
            {

                foreach (FileInfo i in Files)
                {
                    Console.WriteLine(@"File Name - D:\" + i.Name);
                }

                Console.WriteLine("Please Enter filename with directory or Drag and Drop a file to the console window : ");
                filePath = Console.ReadLine();

                if (filePath.StartsWith(directoryPath))
                {

                    fileExt = System.IO.Path.GetExtension(filePath);
                    Console.WriteLine(fileExt);

                    if (fileExt!.Equals(".txt"))
                    {
                        ShowFile();
                        UpdateTextFile();
                        ShowFile();
                    }

                    else if (fileExt.Equals(".png") || fileExt.Equals(".jpg") || fileExt.Equals(".jpeg"))
                    {

                        Console.WriteLine("You have choosed an image it cannot be updated...");

                    }
                    else if (fileExt!.Equals(".xlsx"))
                    {
                        Console.WriteLine("Excel file");

                        DataTable dt = GetExcelDataTable(filePath!);

                        foreach (DataColumn dataColumn in dt.Columns) 
                        {
                            Console.Write(dataColumn.ToString() + "\t ");

                        }

                        Console.WriteLine();    

                        foreach (DataRow dataRow in dt.Rows)
                        {
                            foreach (var item in dataRow.ItemArray)
                            {
                                Console.Write(item+"\t ");
                            }
                            Console.WriteLine();
                        }

                                            }
                    else 
                    {
                        Console.WriteLine("This file is not supported");
                    }
                    
                }
                else
                {
                    Console.WriteLine("You have eneterd wrong input..");
                }


                Console.WriteLine("\nDo you want to See files again(y/yes or n/no)");
                wantToShowAgain = Console.ReadLine().ToLower();
            } while (wantToShowAgain == "y" || wantToShowAgain == "yes");
        }


        public void UpdateTextFile()
        {
            string wantToAddNewLine;
            do
            {
                Console.WriteLine("Please enter a line to append : ");
                string? inputText = Console.ReadLine();

                using (StreamWriter streamWriter = File.AppendText(filePath!))
                {
                    streamWriter.WriteLine(inputText);
                }
                Console.WriteLine("Do want to add a new line (y/yes or n/no) : ");
                wantToAddNewLine = Console.ReadLine().ToLower();
            } while (wantToAddNewLine == "y" || wantToAddNewLine == "yes");

        }

        public void ShowFile()
        {

            using (TextReader textReader = File.OpenText(filePath!))
            {
                Console.WriteLine("\n" + textReader.ReadToEnd());
            }

        }

        public DataTable GetExcelDataTable(string filePath)
        {
            DataTable dt = new DataTable();
            using (XLWorkbook workBook = new XLWorkbook(filePath))
            {
                IXLWorksheet workSheet = workBook.Worksheet(1);
                bool firstRow = true;
                foreach (IXLRow row in workSheet.Rows())
                {
                    if (!row.IsEmpty())
                    {
                        if (firstRow)
                        {
                            foreach (IXLCell cell in row.Cells())
                            {
                                dt.Columns.Add(cell.Value.ToString());
                            }
                            firstRow = false;
                        }
                        else
                        {
                            dt.Rows.Add();
                            int i = 0;
                            foreach (IXLCell cell in row.Cells())
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = cell.Value.ToString();
                                i++;
                            }
                        }

                    }
                }
            }

            return dt;
        }

    }


}
