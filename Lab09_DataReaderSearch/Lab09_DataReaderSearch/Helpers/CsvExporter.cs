using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lab09_DataReaderSearch.Helpers
{
    public static class CsvExporter
    {
        public static void ExportToCsv(DataGridView dgv, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, new UTF8Encoding(true)))
            {
                List<string> headers = new List<string>();
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (col.Visible)
                    {
                        string headerText = col.HeaderText.Replace("\"", "\"\"");
                        headers.Add($"\"{headerText}\"");
                    }
                }
                sw.WriteLine(string.Join(",", headers));

                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.IsNewRow) continue;

                    List<string> cells = new List<string>();
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        if (col.Visible)
                        {
                            var val = row.Cells[col.Index].Value;
                            string cellText = (val == null || val == DBNull.Value) ? "" : val.ToString();
                            cellText = cellText.Replace("\"", "\"\"");
                            cells.Add($"\"{cellText}\"");
                        }
                    }
                    sw.WriteLine(string.Join(",", cells));
                }
            }
        }
    }
}