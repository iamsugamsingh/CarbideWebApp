using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;

namespace CarbideWebApp
{
    public partial class carbideOrder : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        int num; string da;
        private int inquiryNo;
        OleDbDataReader reader;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime TodayDate = DateTime.Today;
                string dt = TodayDate.ToString("dd-MMM-yyyy");
                TextBox1.Text = dt;
                //TextBox5.Text = TodayDate.AddDays(2).ToString("yyyy-MM-dd");
                //TextBox4.Text = TodayDate.ToString("dd-MMM-yyyy");
                try
                {
                    OleDbConnection conn = new OleDbConnection(connectionString);
                    //OleDbConnection conn = new OleDbConnection(connectionString);
                    OleDbCommand cmd = conn.CreateCommand();
                    conn.Open();
                    cmd = new OleDbCommand("SELECT DISTINCTROW NumPed FROM [Pedidos a proveedor (cabeceras)] ORDER BY [Pedidos a proveedor (cabeceras)].NumPed DESC", conn);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader.FieldCount > 0)
                        {
                            TextBox2.Text = (Convert.ToInt32(reader["NumPed"]) + 1).ToString();    //order text box.....
                        }
                    }
                    conn.Close();
                }
                catch (Exception kk)
                {
                    Response.Write(kk);
                }

                try
                {
                    OleDbConnection conn = new OleDbConnection(connectionString);
                    //OleDbConnection conn = new OleDbConnection(connectionString);
                    OleDbCommand cmd = conn.CreateCommand();
                    conn.Open();
                    cmd = new OleDbCommand("select  distinct [Ofertas (cabeceras)].NumOfe, [Ofertas (cabeceras)].FecOfe from [Ofertas (líneas)] inner join[Ofertas (cabeceras)] on [Ofertas (líneas)].numofe =[Ofertas (cabeceras)].numofe ORDER BY[Ofertas (cabeceras)].numofe DESC, FecOfe; ", conn);

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        num = Convert.ToInt32(reader["NumOfe"]);
                        da = reader["FecOfe"].ToString();
                        DropDownList1.Items.Add(reader["NumOfe"] + " " + Convert.ToDateTime(reader["FecOfe"]).ToString("dd-MM-yyyy"));
                    }
                }
                catch (Exception kk)
                {
                    Response.Write(kk);
                }
                try
                {
                    //OleDbConnection conn = new OleDbConnection(connectionString);
                    OleDbConnection conn = new OleDbConnection(connectionString);
                    OleDbCommand cmd = conn.CreateCommand();
                    conn.Open();
                    cmd = new OleDbCommand("select CodPro, NomPro from[Proveedores] ORDER BY[Proveedores].CodPro ASC, NomPro ASC;", conn);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DropDownList2.Items.Add(reader["CodPro"] + "  " + reader["NomPro"]);
                    }
                    conn.Close();
                }
                catch (Exception aa)
                {
                    Response.Write(aa);
                }

                //DataTable table = new DataTable();
                //DataRow row;
                //table.TableName = "order";
                //table.Columns.Add(new DataColumn("uid", typeof(string)));
                //table.Columns.Add(new DataColumn("element", typeof(string)));
                //table.Columns.Add(new DataColumn("qty", typeof(Int32)));
                //table.Columns.Add(new DataColumn("Drawing Number", typeof(string)));
                //table.Columns.Add(new DataColumn("price", typeof(Double)));
                //table.Columns.Add(new DataColumn("importe", typeof(string)));
                //table.Columns.Add(new DataColumn("del. date", typeof(string)));
                //row = table.NewRow();
                //table.Rows.Add(row);

                //ViewState["ord"] = table;
                //GridView1.DataSource = table;
                //GridView1.DataBind();

            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownList2.SelectedValue == "0")
            {
                //DropDownList2.BackColor = Color.Red;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('select item first')", true);
            }
            else
            {
                DropDownList2.BackColor = Color.Transparent;
                string k = DropDownList2.SelectedItem.Text;
                string k2 = RemoveDigits(k);
                TextBox3.Text = k2;
                if (DropDownList2.SelectedItem.Text == "--select--")
                    TextBox3.Text = "";
            }
        }

        public static string RemoveDigits(string key)
        {
            return Regex.Replace(key, @"\d", "");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownList1.SelectedValue == "0")
            {
                //DropDownList1.BackColor = Color.Red;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('select a no. first')", true);
            }
            else
            {
                DropDownList1.BackColor = Color.Transparent;
                inquiryNo = Convert.ToInt32(DropDownList1.SelectedValue.ToString().Substring(0, DropDownList1.SelectedValue.ToString().LastIndexOf(" ")));
                HiddenField5.Value = Convert.ToString(inquiryNo);

                try
                {
                    //OleDbConnection conn = new OleDbConnection(connectionString);
                    OleDbConnection conn = new OleDbConnection(connectionString);
                    OleDbCommand cmd = conn.CreateCommand();
                    conn.Open();
                    cmd = new OleDbCommand("SELECT NumOrd FROM [Ofertas (líneas)] where NumOfe = " + HiddenField5.Value + " ", conn);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        HiddenField2.Value = reader["NumOrd"].ToString();
                    }
                }
                catch (Exception kk)
                {
                    Response.Write(kk);
                }
                try
                {
                    //OleDbConnection conn = new OleDbConnection(connectionString);
                    OleDbConnection conn = new OleDbConnection(connectionString);
                    OleDbCommand cmd = conn.CreateCommand();
                    conn.Open();
                    cmd = new OleDbCommand("SELECT ArtOrd FROM [Ordenes de fabricación] where numord= " + Convert.ToInt32(HiddenField2.Value) + " ", conn);
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        HiddenField3.Value = reader["ArtOrd"].ToString();
                    }
                    conn.Close();
                }
                catch (Exception kk)
                {
                    Response.Write(kk);
                }
                try
                {
                    OleDbConnection conn = new OleDbConnection(connectionString);
                    OleDbCommand cmd = conn.CreateCommand();
                    //cmd = new OleDbCommand("SELECT DISTINCT [Ofertas (líneas)].NumOrd, [Ofertas (líneas)].CodPie, [Ofertas (líneas)].TotPie,  [Ordenes de fabricación].ArtOrd FROM [Ofertas (líneas)] , [Ordenes de fabricación]  WHERE numofe = " + inquiryNo + " AND ArtOrd = '" + HiddenField3.Value + "'; ", conn);

                    cmd = new OleDbCommand("SELECT [Ofertas (líneas)].NumOrd, [Ofertas (líneas)].CodPie, [Ofertas (líneas)].TotPie, [Ordenes de fabricación].ArtOrd from [Ordenes de fabricación] inner join [Ofertas (líneas)] on [Ofertas (líneas)].NumOrd = [Ordenes de fabricación].NumOrd where numofe= " + inquiryNo + " AND ArtOrd = '" + HiddenField3.Value + "'; ", conn);

                    OleDbDataAdapter oldA = new OleDbDataAdapter(cmd);
                    DataTable tab = new DataTable();
                    oldA.Fill(tab);
                    GridView1.DataSource = tab;
                    GridView1.DataBind();
                }
                catch (Exception kk)
                {
                    Response.Write(kk);
                }
            }
        }


        protected void Button6_Click(object sender, EventArgs e)            //Save Button coding
        {
            if (DropDownList1.SelectedValue == "0" && DropDownList2.SelectedValue == "0")
            {
                //DropDownList1.BackColor = Color.Red;
                //DropDownList2.BackColor = Color.Red;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('select item first')", true);
            }
            else if (DropDownList1.SelectedValue == "0")
            {
                //DropDownList1.BackColor = Color.Red;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('select item first')", true);
            }
            else if (DropDownList2.SelectedValue == "0")
            {
                //DropDownList2.BackColor = Color.Red;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('select item first')", true);
            }
            else if (TextBox4.Text == "")
            {
                //TextBox4.BackColor = Color.Red;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please enter Delivery Date')", true);
            }
            else
            {
                //DropDownList1.BackColor = Color.Transparent;
                //TextBox4.BackColor = Color.Transparent;

                DateTime TodayDate = DateTime.Today;
                string t = TodayDate.ToString("dd-MMM-yyyy");
                
                try
                {
                    OleDbConnection conn = new OleDbConnection(connectionString);
                    OleDbCommand cmd = new OleDbCommand("SELECT Top 1 NumPed FROM [Pedidos a proveedor (cabeceras)] Order By NumPed DESC", conn);
                    conn.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        HiddenField4.Value = (Convert.ToInt32(reader["NumPed"]) + 1).ToString();
                        TextBox2.Text = HiddenField4.Value;
                        Session["orderNo"] = HiddenField4.Value;
                    }
                    conn.Close();
                }
                catch (Exception kk)
                {
                    Response.Write(kk);
                }
                int vend = Convert.ToInt32(DropDownList2.SelectedValue.ToString().Substring(0, DropDownList2.SelectedValue.ToString().IndexOf(" ")));

                try
                {
                    //OleDbConnection conn = new OleDbConnection(connectionString);
                    OleDbConnection conn = new OleDbConnection(connectionString);
                    OleDbCommand cmd = conn.CreateCommand();
                    conn.Open();
                    cmd = new OleDbCommand("INSERT INTO [Pedidos a proveedor (cabeceras)] (NumPed, FecPed, NumOfe, ProPed) values ('" + HiddenField4.Value + "','" + t + "','" + HiddenField5.Value + "','" + vend + "')", conn);

                    cmd.ExecuteNonQuery();

                    OleDbCommand com = new OleDbCommand("Update [Parámetros] SET ValPar=" + HiddenField4.Value + " Where CodPar = 'Último pedido (metal duro)'", conn);
                    com.ExecuteNonQuery();
                    
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }

                try
                {
                    OleDbConnection conn = new OleDbConnection(connectionString);
                    //OleDbConnection conn = new OleDbConnection(connectionString);
                    OleDbCommand cmd = conn.CreateCommand();
                    conn.Open();
                    cmd = new OleDbCommand("UPDATE [Ofertas (cabeceras)] SET Numped = " + HiddenField4.Value + " WHERE numofe = " + HiddenField5.Value + ";", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception aq)
                {
                    Response.Write(aq);
                }

                //string input = TextBox4.Text;
                //DateTime dt=Convert.ToDateTime(TextBox4.Text);
                //if (DateTime.TryParseExact(input, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt))
                //{

                //}
                

                try
                {
                    int i = 0, j = 1;

                    foreach (GridViewRow row in GridView1.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            OleDbConnection conn = new OleDbConnection(connectionString);
                            //OleDbConnection conn = new OleDbConnection(connectionString);
                            OleDbCommand cmd = conn.CreateCommand();
                            conn.Open();
                            cmd = new OleDbCommand("INSERT INTO [Pedidos a proveedor (líneas)] (NumPed, NumOrd, CodPie, PiePed, PlaPie) values (?,?,?,?,?) ", conn);
                            cmd.Parameters.Add("@NumPed", OleDbType.Integer).Value = HiddenField4.Value;
                            cmd.Parameters.Add("@NumOrd", OleDbType.Integer).Value = GridView1.Rows[i].Cells[0].Text;
                            cmd.Parameters.Add("@CodPie", OleDbType.VarChar).Value = GridView1.Rows[i].Cells[1].Text;
                            cmd.Parameters.Add("@PiePed", OleDbType.Integer).Value = GridView1.Rows[i].Cells[2].Text;
                            cmd.Parameters.Add("@PlaPie", OleDbType.Date).Value = TextBox4.Text;
                            int insertrow=cmd.ExecuteNonQuery();


                            //if (insertrow > 0)
                            //{
                            //    OleDbCommand command = new OleDbCommand("INSERT INTO [] () VALUES ()", conn);
                            //    command.Parameters.Add();
                            //}
                            conn.Close();
                        }
                        i++;
                    }
                    i = 0;
                }
                catch (Exception lk)
                {
                    Response.Write(lk);
                }


                try
                {
                    OleDbConnection conn = new OleDbConnection(connectionString);
                    //OleDbConnection conn = new OleDbConnection(connectionString);
                    OleDbCommand cmd = conn.CreateCommand();
                    conn.Open();
                    cmd = new OleDbCommand("DELETE FROM [Ofertas (líneas)] WHERE NumOfe = " + HiddenField5.Value + " ", conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    conn.Close();
                }
                catch (Exception ask)
                {
                    Response.Write(ask);
                }


            }
            Response.Write("<script language='javascript'>window.alert('Ordered Successfully.');</script>");
            //Response.Write("<script language='javascript'>window.alert('Ordered Successfully.');window.location='carbideReceive.aspx';</script>");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue == "0" && DropDownList2.SelectedValue == "0")
            {
                //DropDownList1.BackColor = Color.Red;
                //DropDownList2.BackColor = Color.Red;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('select item first')", true);
            }
            else if (DropDownList1.SelectedValue == "0")
            {
                //DropDownList1.BackColor = Color.Red;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('select item first')", true);
            }
            else if (DropDownList2.SelectedValue == "0")
            {
                //DropDownList2.BackColor = Color.Red;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('select item first')", true);
            }
            else
            {
                DropDownList1.BackColor = Color.Transparent;
                ScriptManager.RegisterClientScriptBlock(this.Page, typeof(string), "print", "window.print();", true);
            }
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (TextBox4.Text == "")
            {
                //TextBox4.BackColor = Color.Red;
            }
            else
            {
                TextBox4.BackColor = Color.Transparent;
            }
        }
    }
}