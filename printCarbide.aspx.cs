using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
namespace CarbideWebApp
{
    public partial class printCarbide : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            HiddenField2.Value = Session["companyID"] as String;
            Label4.Text = HiddenField2.Value;
            if (!IsPostBack)
            {
                HiddenField1.Value = Session["PTNo"] as String;
                try
                {
                    OleDbConnection conn = new OleDbConnection(connectionString);
                    OleDbCommand cmd = conn.CreateCommand();
                    conn.Open();
                    cmd = new OleDbCommand("SELECT [Ofertas (líneas)].NumOrd, [Ordenes de fabricación].PinOrd, [Ordenes de fabricación].Datos, [Ordenes de fabricación].EntOrd, [Ofertas (líneas)].NumOfe, [Artículos de clientes (piezas)].CodPie, [Ofertas (líneas)].TotPie, [Artículos de clientes (piezas)].DiaExt, [Artículos de clientes (piezas)].Longit, [Artículos de clientes (piezas)].DiaInt, [Artículos de clientes (piezas)].CalPie, [Ofertas (cabeceras)].NumOfe, [Ofertas (cabeceras)].FecOfe" +
                                     " FROM   " +
                                     "(([Ofertas (líneas)] INNER JOIN ([Artículos de clientes (piezas)] INNER JOIN [Ordenes de fabricación] ON [Ordenes de fabricación].ArtOrd = [Artículos de clientes (piezas)].CodArt) ON [Ordenes de fabricación].NumOrd = [Ofertas (líneas)].NumOrd) INNER JOIN [Ofertas (cabeceras)] ON [Ofertas (líneas)].NumOfe = [Ofertas (cabeceras)].NumOfe)" +
                                     " " +
                                     " WHERE (([Ofertas (líneas)].NumOfe = " + HiddenField1.Value + ") AND [Ofertas (líneas)].CodPie LIKE [Artículos de clientes (piezas)].CodPie)", conn);
                    OleDbDataAdapter oldA = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    DataRow dataRow = null;
                    oldA.Fill(dt);
                    dt.Columns.Add("Vendor");
                    dt.TableName = "vendor";
                    dt.AcceptChanges();
                    ViewState["vendor"] = dt;
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    DateTime TodayDate = DateTime.Today;
                    string t = TodayDate.ToString("dd-MMM-yyyy");
                    offerDateTxtbox.Text = t;
                    offerInqTxtbox.Text = dt.Rows[0][11].ToString();
                    deliveryDateTxtbox.Text = TodayDate.AddDays(2).ToString("dd-MMM-yyyy");
                }
                catch (Exception lk)
                {
                    Response.Write(lk);
                }
            }
            try
            {
                OleDbConnection conn = new OleDbConnection(connectionString);
                OleDbCommand cmd = conn.CreateCommand();
                cmd = new OleDbCommand("select CodPro,NomPro from [Proveedores]", conn);
                conn.Open();
                OleDbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DropDownList1.Items.Add(reader["CodPro"] + " " + reader["NomPro"]);
                }
                conn.Close();
            }
            catch (Exception aa)
            {
                Response.Write(aa);
            }
        }
        protected void print_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "0")
            {
                DropDownList1.BackColor = Color.Red;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('select item first')", true);
                print.Visible = true;
            }
            else
            {
                DropDownList1.BackColor = Color.Transparent;
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(string), "print", "window.print();", true);
            }
        }
        
        protected void Export_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "0")
            {
                DropDownList1.BackColor = Color.Red;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('select item first')", true);
            }
            else
            {
                Response.Redirect("~/ExportExcel.aspx");
            }
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue != "0")
            {
                DropDownList1.BackColor = Color.Transparent;
                DataTable dataTable = (DataTable)ViewState["vendor"];
                int i = 0;
                foreach (DataRow dr in dataTable.Rows)
                {
                    dataTable.Rows[i][13] = DropDownList1.SelectedItem;
                    i++;
                }
                i = 0;
                GridView1.DataSource = dataTable;
                GridView1.DataBind();            
            }

            if (GridView1.Rows.Count > 0)
            {
                List<int> SortedUidList = new List<int>();
                DataTable sortedTable = new DataTable();

                sortedTable.Columns.Add("PinOrd");
                sortedTable.Columns.Add("NumOrd");
                sortedTable.Columns.Add("CodPie");
                sortedTable.Columns.Add("DiaExt");
                sortedTable.Columns.Add("Longit");
                sortedTable.Columns.Add("DiaInt");
                sortedTable.Columns.Add("CalPie");
                sortedTable.Columns.Add("TotPie");
                sortedTable.Columns.Add("Datos");
                sortedTable.Columns.Add("EntOrd");
                sortedTable.Columns.Add("Vendor");

                foreach (GridViewRow row in GridView1.Rows)
                {
                    int uid = Convert.ToInt32(row.Cells[1].Text);
                    SortedUidList.Add(uid);
                }

                SortedUidList.Sort();

                for (int k = 0; k < GridView1.Rows.Count; k++)
                {
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        if (SortedUidList[k] == Convert.ToInt32(GridView1.Rows[i].Cells[1].Text))
                        {
                            sortedTable.Rows.Add(GridView1.Rows[i].Cells[0].Text, GridView1.Rows[i].Cells[1].Text, GridView1.Rows[i].Cells[2].Text, GridView1.Rows[i].Cells[3].Text, GridView1.Rows[i].Cells[4].Text, GridView1.Rows[i].Cells[5].Text, GridView1.Rows[i].Cells[6].Text, GridView1.Rows[i].Cells[7].Text, GridView1.Rows[i].Cells[8].Text, GridView1.Rows[i].Cells[9].Text, GridView1.Rows[i].Cells[10].Text);
                        }
                    }
                }

                GridView1.DataSource = sortedTable;
                GridView1.DataBind();
                Session["SortedDataTable"] = sortedTable;
            }
			
        }
        protected void placeOrderBtn_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/carbideOrder.aspx");
        }
    }
}