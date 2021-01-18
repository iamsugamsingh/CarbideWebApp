using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Drawing;
using System.Text;

namespace CarbideWebApp
{
    public partial class ExportExcel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = null;
            if (Session["SortedDataTable"] != null)
            {
                dt = Session["SortedDataTable"] as DataTable;
            }

            DataTable sortedTable = new DataTable();

            sortedTable.Columns.Add("PT");
            sortedTable.Columns.Add("UID");
            sortedTable.Columns.Add("Part");
            sortedTable.Columns.Add("OD");
            sortedTable.Columns.Add("Length");
            sortedTable.Columns.Add("ID");
            sortedTable.Columns.Add("Grade");
            sortedTable.Columns.Add("Qty");
            sortedTable.Columns.Add("Remarks");
            sortedTable.Columns.Add("Delivery Date");
            sortedTable.Columns.Add("Vendor");

            foreach(DataRow row in dt.Rows)
            {
                sortedTable.Rows.Add(row["PinOrd"].ToString(), row["NumOrd"].ToString(), row["CodPie"].ToString(), row["DiaExt"].ToString(), row["Longit"].ToString(), row["DiaInt"].ToString(), row["CalPie"].ToString(), row["TotPie"].ToString(), row["Datos"].ToString(), row["EntOrd"].ToString(), row["Vendor"].ToString());
            }

            string csv = string.Empty;

            foreach (DataColumn column in sortedTable.Columns)
            {
                //Add the Header row for CSV file.
                csv += column.ColumnName + ',';
            }

            //Add new line.
            csv += "\r\n";

            foreach (DataRow row in sortedTable.Rows)
            {
                foreach (DataColumn column in sortedTable.Columns)
                {
                    //Add the Data rows.
                    csv += row[column.ColumnName].ToString().Replace("&nbsp;", " ") + ',';
                }

                //Add new line.
                csv += "\r\n";
            }

            //Download the CSV file.
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Carbide Inquiry ( " + DateTime.Today.ToString("dd/MM/yy") + " ).csv");
            Response.Charset = "";
            Response.ContentType = "application/text";
            Response.Output.Write(csv);
            Response.Flush();
            Response.End();
            }
        }
    }