using System.Text;

namespace AngularBackEnd.Formatters
{
    public class CsvFormatterOptions
    {
        public bool UseSingleLineHeaderInCsv { get; set; } = true;

        public string CsvDelimiter { get; set; } = ";";

        public Encoding Encoding { get; set; } = Encoding.UTF8;

        public bool IncludeExcelDelimiterHeader { get; set; } = false;
    }
}
