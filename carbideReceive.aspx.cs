using System;
using System.Data;
using System.Data.OleDb;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace CarbideWebApp
{
    public partial class recieveOrder : System.Web.UI.Page
    {
        DataTable dt;
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                try
                {
                    deliveryDateTxtBox.Text = DateTime.Today.ToString("dd-MMM-yyyy");

                    OleDbConnection conn = new OleDbConnection(connectionString);
                    OleDbCommand cmd = conn.CreateCommand();
                    conn.Open();
                    cmd = new OleDbCommand("SELECT DISTINCTROW NumPed FROM [Pedidos a proveedor (cabeceras)] ORDER BY [Pedidos a proveedor (cabeceras)].NumPed DESC", conn);
                    OleDbDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            orderNumDropDownList.Items.Add(Convert.ToInt32(reader["NumPed"]).ToString());
                        }
                    }
                    conn.Close();
                }
                catch (Exception kk)
                {
                    Response.Write(kk);
                }
            }
        }

        protected void orderNumDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(connectionString);
                OleDbCommand cmd = conn.CreateCommand();
                conn.Open();
                cmd = new OleDbCommand("SELECT FecPed,NumOfe,ProPed FROM [Pedidos a proveedor (cabeceras)] where NumPed= " + orderNumDropDownList.SelectedValue, conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    orderDateTxtBox.Text = Convert.ToDateTime(reader["FecPed"]).ToString("dd-MMM-yyyy");
                    enqRefTxtBox.Text = Convert.ToInt32(reader["NumOfe"]).ToString();
                    vendorTxtBox.Text = Convert.ToInt32(reader["ProPed"]).ToString();
                }
                conn.Close();
            }
            catch (Exception lk)
            {
                Response.Write(lk);
            }

            try
            {
                OleDbConnection conn = new OleDbConnection(connectionString);
                OleDbCommand cmd = conn.CreateCommand();
                conn.Open();
                cmd = new OleDbCommand("SELECT NomPro FROM [Proveedores] where CodPro=" + vendorTxtBox.Text + " ", conn);
                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    vendorNameTxtBox.Text = reader["NomPro"].ToString();
                }
                conn.Close();
            }
            catch (Exception ass)
            {
                Response.Write(ass);
            }

            dt = new DataTable();

            try
            {
                OleDbConnection conn = new OleDbConnection(connectionString);
                OleDbCommand cmd = conn.CreateCommand();
                conn.Open();
                /*cmd = new OleDbCommand("SELECT [Pedidos a proveedor (líneas)].NumOrd, CodPie, NumFas, PlaPie, PiePed, AuxCtd, ArtOrd,  (PiePed-AuxCtd)as [Quantity Pending] from [Pedidos a proveedor (líneas)] Inner JOIN [Ordenes de fabricación] on [Pedidos a proveedor (líneas)].NumOrd=  [Ordenes de fabricación].NumOrd Where NumPed= " + orderNumDropDownList.SelectedValue + " ", conn);*/

                cmd = new OleDbCommand("SELECT [Pedidos a proveedor (líneas)].NumOrd, CodPie, NumFas, PlaPie, PiePed, PieRec, ArtOrd,  (PiePed-PieRec)as [Quantity Pending] from [Pedidos a proveedor (líneas)] Inner JOIN [Ordenes de fabricación] on [Pedidos a proveedor (líneas)].NumOrd=  [Ordenes de fabricación].NumOrd Where NumPed= " + orderNumDropDownList.SelectedValue + " ", conn);

                OleDbDataAdapter oldA = new OleDbDataAdapter(cmd);
                oldA.Fill(dt);
                
                GridView1.DataSource = dt;
                GridView1.DataBind();

                ViewState["ordrec"] = dt;
                conn.Close();
            }
            catch (Exception kj)
            {
                Response.Write(kj);
            }
        }

        protected void quantityReceivedTxtBox_TextChanged(object sender, EventArgs e)
        {
            TextBox quantityReceivedTextBox = sender as TextBox;
            GridViewRow rows = quantityReceivedTextBox.NamingContainer as GridViewRow;
            int rowIndex = rows.RowIndex;

            GridViewRow row = GridView1.Rows[rowIndex];
            Label orderQuantityLbl = (Label)row.FindControl("orderQuantityLbl");
            Label quantitypendingLbl = (Label)row.FindControl("quantitypendingLbl");

            quantitypendingLbl.Text = (Convert.ToInt32(orderQuantityLbl.Text) - Convert.ToInt32(quantityReceivedTextBox.Text)).ToString();

            if (trackArrowKeyDown.Value == "Down")
            {
                rowIndex++;
                if (GridView1.Rows.Count > rowIndex)
                {
                    row = GridView1.Rows[rowIndex];
                    TextBox nextQuantityReceivedTextBox = (TextBox)row.FindControl("quantityReceivedTxtBox");
                    nextQuantityReceivedTextBox.Focus();
                }
            }

            if (trackArrowKeyDown.Value == "Up")
            {
                rowIndex--;
                if (GridView1.Rows.Count > rowIndex)
                {
                    row = GridView1.Rows[rowIndex];
                    TextBox nextQuantityReceivedTextBox = (TextBox)row.FindControl("quantityReceivedTxtBox");
                    nextQuantityReceivedTextBox.Focus();
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
        }

        protected void saveBtn_Click(object sender, EventArgs e)            //Save button coding
        {
            DataTable dataTable = (DataTable)ViewState["ordrec"];
            int count = dataTable.Rows.Count;

            for (int temp = 0; temp < count; temp++)
            {
                Label uidLbl = (Label)GridView1.Rows[temp].FindControl("uidLbl");
                Label elementLbl = (Label)GridView1.Rows[temp].FindControl("elementLbl");
                Label stepLbl = (Label)GridView1.Rows[temp].FindControl("stepLbl");
                Label articleLbl = (Label)GridView1.Rows[temp].FindControl("articleLbl");
                Label deliverydateLbl = (Label)GridView1.Rows[temp].FindControl("deliverydateLbl");
                Label orderQuantityLbl = (Label)GridView1.Rows[temp].FindControl("orderQuantityLbl");
                TextBox quantityReceivedTxtBox = (TextBox)GridView1.Rows[temp].FindControl("quantityReceivedTxtBox");
                Label quantitypendingLbl = (Label)GridView1.Rows[temp].FindControl("quantitypendingLbl");


                //TextBox tx2 = (TextBox)GridView1.Rows[temp].Cells[7].FindControl("quantityReceivedTxtBox");
                //string qty3 = quantityReceivedTxtBox.Text;
                int qty = 0;

                if (Convert.ToInt32(quantityReceivedTxtBox.Text)>=0)
                {
                    int AuxCtd1;

                    OleDbConnection conn1 = new OleDbConnection(connectionString);
                    OleDbCommand cmd1 = conn1.CreateCommand();
                    conn1.Open();
                    cmd1 = new OleDbCommand("select AuxCtd FROM [Pedidos a proveedor (líneas)] WHERE NumOrd = ? AND  CodPie=? ", conn1);
                    cmd1.Parameters.Add("@uid", OleDbType.VarChar).Value = uidLbl.Text;
                    cmd1.Parameters.Add("@element", OleDbType.VarChar).Value = elementLbl.Text;
                    OleDbDataReader reader1 = cmd1.ExecuteReader();
                    if (reader1.Read())
                    {
                        string onejval = reader1.GetValue(reader1.GetOrdinal("AuxCtd")).ToString();
                        if (onejval == "")
                        {
                            AuxCtd1 = 0;
                        }
                        else
                        {
                            AuxCtd1 = Convert.ToInt32(reader1.GetValue(reader1.GetOrdinal("AuxCtd")));
                        }
                        conn1.Close();


                        if (AuxCtd1 == 0)
                        {
                            try
                            {
                                OleDbConnection conn = new OleDbConnection(connectionString);
                                OleDbCommand cmd = conn.CreateCommand();
                                conn.Open();
                                cmd = new OleDbCommand("UPDATE [Pedidos a proveedor (líneas)] SET AuxCtd=" + qty + " WHERE NumOrd = ? AND  CodPie=? ", conn);
                                cmd.Parameters.Add("@uid", OleDbType.VarChar).Value = uidLbl.Text;
                                cmd.Parameters.Add("@element", OleDbType.VarChar).Value = elementLbl.Text;
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                            catch (Exception lk) 
                            {
                                Response.Write(lk);
                            }
                        }
                        else if (AuxCtd1 != 0)
                        {
                            try
                            {
                                int t = AuxCtd1 + Convert.ToInt32(qty);

                                OleDbConnection conn = new OleDbConnection(connectionString);
                                OleDbCommand cmd = conn.CreateCommand();
                                conn.Open();
                                cmd = new OleDbCommand("UPDATE [Pedidos a proveedor (líneas)] SET AuxCtd=" + Convert.ToString(t) + " WHERE NumOrd = ? AND  CodPie=? ", conn);
                                cmd.Parameters.Add("@uid", OleDbType.VarChar).Value = uidLbl.Text;
                                cmd.Parameters.Add("@element", OleDbType.VarChar).Value = elementLbl.Text;
                                cmd.ExecuteNonQuery();
                                conn.Close();
                            }
                            catch (Exception lk) 
                            {
                                Response.Write(lk);
                            }
                        }

                        try
                        {
                            OleDbConnection conn2 = new OleDbConnection(connectionString);
                            OleDbCommand cmd2 = conn2.CreateCommand();
                            conn2.Open();
                            cmd2 = new OleDbCommand("INSERT INTO [Ordenes de fabricación (historia/exterior)]  (NumOrd,CodPie,FecAlbExt,CanPie,CodProExt,OrderDate) VALUES (?,?,?,?,?,?)", conn2);
                            cmd2.Parameters.Add("@NumOrd", OleDbType.Integer).Value = Convert.ToInt32(uidLbl.Text);
                            cmd2.Parameters.Add("@CodPie", OleDbType.VarChar).Value = elementLbl.Text;
                            cmd2.Parameters.Add("@FecAlbExt", OleDbType.Date).Value = deliverydateLbl.Text;
                            cmd2.Parameters.Add("@CanPie", OleDbType.Integer).Value = Convert.ToInt32(quantityReceivedTxtBox.Text);
                            cmd2.Parameters.Add("@CodProExt", OleDbType.Integer).Value = Convert.ToInt32(vendorTxtBox.Text);
                            cmd2.Parameters.Add("@OrderDate",OleDbType.Date).Value=orderDateTxtBox.Text;
                            cmd2.ExecuteNonQuery();
                            conn2.Close();

                        }
                        catch (Exception lk)
                        {
                            Response.Write(lk);
                        }

                        try
                        { 
                            OleDbConnection conn = new OleDbConnection(connectionString);
                            OleDbCommand cmd = conn.CreateCommand();
                            conn.Open();
                            cmd = new OleDbCommand("UPDATE [Pedidos a proveedor (líneas)] SET PieRec=" + Convert.ToString(quantityReceivedTxtBox.Text) + " WHERE NumOrd = ? AND  CodPie=? ", conn);
                            cmd.Parameters.Add("@uid", OleDbType.VarChar).Value = uidLbl.Text;
                            cmd.Parameters.Add("@element", OleDbType.VarChar).Value = elementLbl.Text;
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        catch(Exception ex)
                        {
                            Response.Write(ex);
                        }


                        try
                        {
                            int AuxCtd = 0, PiePed = 0;

                            OleDbConnection conn2 = new OleDbConnection(connectionString);
                            OleDbCommand cmd2 = conn2.CreateCommand();
                            conn2.Open();
                            cmd2 = new OleDbCommand("select PiePed,AuxCtd FROM [Pedidos a proveedor (líneas)] WHERE NumOrd = ? AND  CodPie=? ", conn2);
                            cmd2.Parameters.Add("@uid", OleDbType.VarChar).Value = Convert.ToInt32(uidLbl.Text);
                            cmd2.Parameters.Add("@element", OleDbType.VarChar).Value = elementLbl.Text;
                            OleDbDataReader reader2 = cmd2.ExecuteReader();
                            if (reader2.Read())
                            {
                                AuxCtd = Convert.ToInt32(reader2.GetValue(reader2.GetOrdinal("AuxCtd")));
                                PiePed = Convert.ToInt32(reader2.GetValue(reader2.GetOrdinal("PiePed")));
                            }

                            if (AuxCtd - PiePed >= 0)
                            {
                                try
                                {
                                    OleDbConnection conn = new OleDbConnection(connectionString);
                                    OleDbCommand cmd = conn.CreateCommand();
                                    conn.Open();
                                    cmd = new OleDbCommand("DELETE FROM [Pedidos a proveedor (líneas)] WHERE NumOrd =? AND  CodPie=? ", conn);
                                    cmd.Parameters.Add("@uid", OleDbType.VarChar).Value = Convert.ToInt32(uidLbl.Text);
                                    cmd.Parameters.Add("@element", OleDbType.VarChar).Value = elementLbl.Text;
                                    cmd.ExecuteNonQuery();
                                    conn.Close();
                                }
                                catch (Exception ask)
                                {
                                    Response.Write(ask);
                                }
                            }
                            conn2.Close();
                        }
                        catch (Exception a1) 
                        {
                            Response.Write(a1);
                        }
                    }
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Order Received.')", true);
            }
            orderNumDropDownList_SelectedIndexChanged(null, null);
        }
    }
}