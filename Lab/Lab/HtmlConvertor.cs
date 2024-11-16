using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Lab
{
    public static class HtmlConvertor
    {
        static string templateFile = "DataTemplate.xml";
        static string closeFile = "</ScientificStaffSalaries>";

        static string chromeCommand = "cd C:\\Program Files\\Google\\Chrome\\Application \r\n chrome --allow-file-access-from-files file:///";

        public async static Task<string> Convert(List<StaffMember> members)
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string templatePath = Path.Combine(basePath, templateFile);

                if (!File.Exists(templatePath))
                {
                    throw new FileNotFoundException("Template file not found.", templatePath);
                }

                string templateContent = File.ReadAllText(templatePath);

                string result = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n<?xml-stylesheet href=\"tableTemplate.xslt\" type=\"text/xsl\" ?>\r\n\r\n<ScientificStaffSalaries>";
                foreach (var member in members)
                {
                    string populatedMember = templateContent
                        .Replace("{Name}", member.Name ?? "")
                        .Replace("{Department}", member.Department ?? "")
                        .Replace("{DepartmentSection}", member.DepartmentSection ?? "")
                        .Replace("{Position}", member.Position ?? "")
                        .Replace("{Salary}", member.Salary ?? "")
                        .Replace("{Duration}", member.Duration ?? "");

                    result += populatedMember + "\n";
                }

                result += closeFile;

                string outputFileName = "Output_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xml";
                string outputPath = Path.Combine(basePath, outputFileName);
                File.WriteAllText(outputPath, result);

                await Clipboard.SetTextAsync(chromeCommand + outputPath);
                Process.Start("cmd.exe");

                return outputPath;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Convert: {ex.Message}");
                return string.Empty;
            }
        }
    }
}
