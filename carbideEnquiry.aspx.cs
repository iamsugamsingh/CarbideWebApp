using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Drawing;

namespace CarbideWebApp
{
    public partial class index : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
        public string location;
        CheckBox chck;
        protected void Page_Load(object sender, EventArgs e)
        {
            location = Request.QueryString["location"].ToString();
            if (!Page.IsPostBack) 
            {
                SetInitialRow();
                GridViewRow row = GridView1.Rows[GridView1.Rows.Count - 1];
                TextBox uIdTextBox = (TextBox)row.FindControl("TextBox1");
                uIdTextBox.Focus();
                //totalRowsCount.Text = GridView1.Rows.Count.ToString();
            }
            
        }
        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("UID", typeof(string)));
            dt.Columns.Add(new DataColumn("CustomerID", typeof(string)));
            dt.Columns.Add(new DataColumn("Description", typeof(string)));
            dt.Columns.Add(new DataColumn("Element", typeof(string)));
            dt.Columns.Add(new DataColumn("Multiplier", typeof(string)));
            dt.Columns.Add(new DataColumn("OrderQuantity", typeof(string)));
            dt.Columns.Add(new DataColumn("Total", typeof(string)));
            dt.Columns.Add(new DataColumn("QuantityToOrder", typeof(string)));
            dt.Columns.Add(new DataColumn("Grade", typeof(string)));
            dt.Columns.Add(new DataColumn("Model", typeof(string)));
            dt.Columns.Add(new DataColumn("OuterDiameter", typeof(string)));
            dt.Columns.Add(new DataColumn("Length", typeof(string)));
            dt.Columns.Add(new DataColumn("InternalDiaMeter", typeof(string)));
            dt.Columns.Add(new DataColumn("ArticleNumber", typeof(string)));

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["UID"] = string.Empty;
            dr["CustomerID"] = string.Empty;
            dr["Description"] = string.Empty;
            dr["Element"] = string.Empty;
            dr["Multiplier"] = string.Empty;
            dr["OrderQuantity"] = string.Empty;
            dr["Total"] = string.Empty;
            dr["QuantityToOrder"] = string.Empty;
            dr["Grade"] = string.Empty;
            dr["Model"] = string.Empty;
            dr["OuterDiameter"] = string.Empty;
            dr["Length"] = string.Empty;
            dr["InternalDiaMeter"] = string.Empty;
            dr["ArticleNumber"] = string.Empty;

            dt.Rows.Add(dr);
            ViewState["CurrentTable"] = dt;
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }
        private void AddNewRowToGrid()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)GridView1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        TextBox box4 = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("TextBox4");
                        TextBox box5 = (TextBox)GridView1.Rows[rowIndex].Cells[5].FindControl("TextBox5");
                        TextBox box6 = (TextBox)GridView1.Rows[rowIndex].Cells[6].FindControl("TextBox6");
                        TextBox box7 = (TextBox)GridView1.Rows[rowIndex].Cells[7].FindControl("TextBox7");
                        TextBox box8 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("TextBox8");
                        TextBox box9 = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("TextBox9");
                        TextBox box10 = (TextBox)GridView1.Rows[rowIndex].Cells[10].FindControl("TextBox10");
                        TextBox box11 = (TextBox)GridView1.Rows[rowIndex].Cells[11].FindControl("TextBox11");
                        TextBox box12 = (TextBox)GridView1.Rows[rowIndex].Cells[12].FindControl("TextBox12");
                        TextBox box13 = (TextBox)GridView1.Rows[rowIndex].Cells[13].FindControl("TextBox13");
                        TextBox box14 = (TextBox)GridView1.Rows[rowIndex].Cells[14].FindControl("TextBox14");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["UID"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["CustomerID"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["Description"] = box3.Text;
                        dtCurrentTable.Rows[i - 1]["Element"] = box4.Text;
                        dtCurrentTable.Rows[i - 1]["Multiplier"] = box5.Text;
                        dtCurrentTable.Rows[i - 1]["OrderQuantity"] = box6.Text;
                        dtCurrentTable.Rows[i - 1]["Total"] = box7.Text;
                        dtCurrentTable.Rows[i - 1]["QuantityToOrder"] = box8.Text;
                        dtCurrentTable.Rows[i - 1]["Grade"] = box9.Text;
                        dtCurrentTable.Rows[i - 1]["Model"] = box10.Text;
                        dtCurrentTable.Rows[i - 1]["OuterDiameter"] = box11.Text;
                        dtCurrentTable.Rows[i - 1]["Length"] = box12.Text;
                        dtCurrentTable.Rows[i - 1]["InternalDiameter"] = box13.Text;
                        dtCurrentTable.Rows[i - 1]["ArticleNumber"] = box14.Text;

                        rowIndex++;
                    }

                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;                    
                    GridView1.DataSource = dtCurrentTable;
                    GridView1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }

        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)GridView1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        TextBox box4 = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("TextBox4");
                        TextBox box5 = (TextBox)GridView1.Rows[rowIndex].Cells[5].FindControl("TextBox5");
                        TextBox box6 = (TextBox)GridView1.Rows[rowIndex].Cells[6].FindControl("TextBox6");
                        TextBox box7 = (TextBox)GridView1.Rows[rowIndex].Cells[7].FindControl("TextBox7");
                        TextBox box8 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("TextBox8");
                        TextBox box9 = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("TextBox9");
                        TextBox box10 = (TextBox)GridView1.Rows[rowIndex].Cells[10].FindControl("TextBox10");
                        TextBox box11= (TextBox)GridView1.Rows[rowIndex].Cells[11].FindControl("TextBox11");
                        TextBox box12= (TextBox)GridView1.Rows[rowIndex].Cells[12].FindControl("TextBox12");
                        TextBox box13 = (TextBox)GridView1.Rows[rowIndex].Cells[13].FindControl("TextBox13");
                        TextBox box14 = (TextBox)GridView1.Rows[rowIndex].Cells[14].FindControl("TextBox14");

                        box1.Text = dt.Rows[i]["UID"].ToString();
                        box2.Text = dt.Rows[i]["CustomerID"].ToString();
                        box3.Text = dt.Rows[i]["Description"].ToString();
                        box4.Text = dt.Rows[i]["Element"].ToString();
                        box5.Text = dt.Rows[i]["Multiplier"].ToString();
                        box6.Text = dt.Rows[i]["OrderQuantity"].ToString();
                        box7.Text = dt.Rows[i]["Total"].ToString();
                        box8.Text = dt.Rows[i]["QuantityToOrder"].ToString();
                        box9.Text = dt.Rows[i]["Grade"].ToString();
                        box10.Text = dt.Rows[i]["Model"].ToString();
                        box11.Text = dt.Rows[i]["OuterDiameter"].ToString();
                        box12.Text = dt.Rows[i]["Length"].ToString();
                        box13.Text = dt.Rows[i]["InternalDiameter"].ToString();
                        box14.Text = dt.Rows[i]["ArticleNumber"].ToString();

                        rowIndex++;
                    }
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
            GridViewRow row = GridView1.Rows[GridView1.Rows.Count - 1];
            TextBox uIdTextBox = (TextBox)row.FindControl("TextBox1");
            uIdTextBox.Focus();
            //totalRowsCount.Text = GridView1.Rows.Count.ToString();
        }

        protected void OnUidChanged(object sender, EventArgs e)
        {  
            try
            {
                TextBox uidTextBox = sender as TextBox;
                GridViewRow rows = uidTextBox.NamingContainer as GridViewRow;
                int rowIndex = rows.RowIndex;

                GridViewRow row = GridView1.Rows[rowIndex];
                TextBox customerIdTextBox = (TextBox)row.FindControl("TextBox2");
                TextBox descriptionTextBox = (TextBox)row.FindControl("TextBox3");
                TextBox elementTextBox = (TextBox)row.FindControl("TextBox4");
                TextBox multiplierTextBox = (TextBox)row.FindControl("TextBox5");
                TextBox orderQunatityTextBox = (TextBox)row.FindControl("TextBox6");
                TextBox totalTextBox = (TextBox)row.FindControl("TextBox7");
                TextBox quantityToOrderTextBox = (TextBox)row.FindControl("TextBox8");
                TextBox gradeTextBox = (TextBox)row.FindControl("TextBox9");
                TextBox modelTextBox = (TextBox)row.FindControl("TextBox10");
                TextBox outerDiameterTextBox = (TextBox)row.FindControl("TextBox11");
                TextBox lengthTextBox = (TextBox)row.FindControl("TextBox12");
                TextBox internalDiameterTextBox = (TextBox)row.FindControl("TextBox13");
                TextBox articleNumberTextBox = (TextBox)row.FindControl("TextBox14");

                OleDbConnection conn = new OleDbConnection(connectionString);
                OleDbCommand cmd = conn.CreateCommand();
                conn.Open();
                //cmd = new OleDbCommand("SELECT  CodPie,CtdPie, DiaExt, DiaInt, Longit, ModPie, CalPie, NumOrd,ArtOrd, PlaOrd, PieOrd, PinOrd, NumPed, CliPed FROM ([Artículos de clientes] INNER JOIN ([Pedidos de clientes] INNER JOIN [Ordenes de fabricación] ON [Pedidos de clientes].[NumPed] = [Ordenes de fabricación].[PinOrd]) ON [Artículos de clientes].[CodArt] = [Ordenes de fabricación].[ArtOrd]) INNER JOIN [Artículos de clientes (piezas)] ON [Artículos de clientes].[CodArt] = [Artículos de clientes (piezas)].[CodArt] WHERE NumOrd=" + uidTextBox.Text + "", conn);

                cmd = new OleDbCommand("SELECT numord, artord, plaord, pieord from [Ordenes de fabricación] WHERE NumOrd=" + uidTextBox.Text, conn);                

                OleDbDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    customerIdTextBox.Text = reader["artord"].ToString().Substring(0,6);
                    descriptionTextBox.Text = "DIE " + reader["plaord"].ToString();
                    articleNumberTextBox.Text = reader["ArtOrd"].ToString();                    
                    orderQunatityTextBox.Text = reader["PieOrd"].ToString();
                    multiplierTextBox.Text = "1";
                    OleDbCommand command = new OleDbCommand("Select codpie,ctdpie,diaext,diaint,longit,modpie,calpie from [Artículos de clientes (piezas)] where CodArt ='" + articleNumberTextBox.Text + "'", conn);

                    OleDbDataReader read = command.ExecuteReader();

                    if (read.Read())
                    {
                        if (!read["codpie"].ToString().Equals("A") & !read["codpie"].ToString().Equals("A1") & !read["codpie"].ToString().Equals("A2") & !read["codpie"].ToString().Equals("A3") & !read["codpie"].ToString().Equals("A4") & !read["codpie"].ToString().Equals("A5") & !read["codpie"].ToString().Equals("A6"))
                        {
                            if (read["CodPie"].ToString() != "")
                            {
                                elementTextBox.Text = read["CodPie"].ToString();
                            }
                            else
                            {
                                elementTextBox.Text = "B1";
                            }

                            if (read["CtdPie"].ToString() != "")
                            {
                                multiplierTextBox.Text = read["CtdPie"].ToString();
                            }
                            else
                            {
                                multiplierTextBox.Text = "1";
                            }

                            totalTextBox.Text = calculateTotal(multiplierTextBox.Text, orderQunatityTextBox.Text);

                            gradeTextBox.Text = read["CalPie"].ToString();

                            if (read["ModPie"].ToString() != "")
                            {
                                modelTextBox.Text = read["ModPie"].ToString();
                            }
                            else
                            {
                                modelTextBox.Text = "N1";                                
                            }
                            outerDiameterTextBox.Text = read["DiaExt"].ToString();
                            lengthTextBox.Text = read["Longit"].ToString();
                            internalDiameterTextBox.Text = read["DiaInt"].ToString();
                        }
                        else
                        {
                            elementTextBox.Text = "B1";
                            elementDataFetch(elementTextBox);
                            //multiplierTextBox.Text = "1";
                            //totalTextBox.Text = calculateTotal(multiplierTextBox.Text, orderQunatityTextBox.Text);
                            //gradeTextBox.Text = string.Empty;
                            //modelTextBox.Text = "N1";
                            //outerDiameterTextBox.Text = string.Empty;
                            //lengthTextBox.Text = string.Empty;
                            //internalDiameterTextBox.Text = string.Empty;
                        }
                    }
                    else
                    {
                        //elementTextBox.Text = string.Empty;
                        //multiplierTextBox.Text = string.Empty;
                        //orderQunatityTextBox.Text = string.Empty;
                        //totalTextBox.Text = string.Empty;
                        gradeTextBox.Text = string.Empty;
                        //modelTextBox.Text = string.Empty;
                        outerDiameterTextBox.Text = string.Empty;
                        lengthTextBox.Text = string.Empty;
                        internalDiameterTextBox.Text = string.Empty;
                    }

                    customerIdTextBox.Focus();
                    customerIdTextBox.Attributes.Add("onfocusin", " select();");
                    
                    //if (elementTextBox.Text == "")
                    //{
                    //    elementTextBox.Focus();
                    //}
                    //else
                    //{
                    //    quantityToOrderTextBox.Focus();
                    //}
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong...!')", true);
            }

           
        }
        protected void OnElementChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox elementTextBox = sender as TextBox;

                elementDataFetch(elementTextBox);
                //GridViewRow rows = elementTextBox.NamingContainer as GridViewRow;
                //int rowIndex = rows.RowIndex;

                //GridViewRow row = GridView1.Rows[rowIndex];
                //TextBox uidTextBox = (TextBox)row.FindControl("TextBox1");
                //TextBox multiplierTextBox = (TextBox)row.FindControl("TextBox5");
                //TextBox orderQunatityTextBox = (TextBox)row.FindControl("TextBox6");
                //TextBox totalTextBox = (TextBox)row.FindControl("TextBox7");
                //TextBox quantityToOrderTextBox = (TextBox)row.FindControl("TextBox8");
                //TextBox gradeTextBox = (TextBox)row.FindControl("TextBox9");
                //TextBox modelTextBox = (TextBox)row.FindControl("TextBox10");
                //TextBox outerDiameterTextBox = (TextBox)row.FindControl("TextBox11");
                //TextBox lengthTextBox = (TextBox)row.FindControl("TextBox12");
                //TextBox internalDiameterTextBox = (TextBox)row.FindControl("TextBox13");
                //TextBox articleNumberTextBox = (TextBox)row.FindControl("TextBox14");

                

                //quantityToOrderTextBox.Focus();

                //multiplierTextBox.Focus();
                //multiplierTextBox.Attributes.Add("onfocusin", " select();");
                //conn.Close();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong...!')", true);
            }            
        }

        public void elementDataFetch(TextBox elementTextBox)
        {
            GridViewRow rows = elementTextBox.NamingContainer as GridViewRow;
            int rowIndex = rows.RowIndex;

            GridViewRow row = GridView1.Rows[rowIndex];
            TextBox uidTextBox = (TextBox)row.FindControl("TextBox1");
            TextBox multiplierTextBox = (TextBox)row.FindControl("TextBox5");
            TextBox orderQunatityTextBox = (TextBox)row.FindControl("TextBox6");
            TextBox totalTextBox = (TextBox)row.FindControl("TextBox7");
            TextBox quantityToOrderTextBox = (TextBox)row.FindControl("TextBox8");
            TextBox gradeTextBox = (TextBox)row.FindControl("TextBox9");
            TextBox modelTextBox = (TextBox)row.FindControl("TextBox10");
            TextBox outerDiameterTextBox = (TextBox)row.FindControl("TextBox11");
            TextBox lengthTextBox = (TextBox)row.FindControl("TextBox12");
            TextBox internalDiameterTextBox = (TextBox)row.FindControl("TextBox13");
            TextBox articleNumberTextBox = (TextBox)row.FindControl("TextBox14");

            OleDbConnection conn = new OleDbConnection(connectionString);
            OleDbCommand cmd = conn.CreateCommand();
            conn.Open();
            //cmd = new OleDbCommand("SELECT  CodPie,CtdPie, DiaExt, DiaInt, Longit, ModPie, CalPie, NumOrd,ArtOrd, PlaOrd, PieOrd, PinOrd, NumPed, CliPed FROM ([Artículos de clientes] INNER JOIN ([Pedidos de clientes] INNER JOIN [Ordenes de fabricación] ON [Pedidos de clientes].[NumPed] = [Ordenes de fabricación].[PinOrd]) ON [Artículos de clientes].[CodArt] = [Ordenes de fabricación].[ArtOrd]) INNER JOIN [Artículos de clientes (piezas)] ON [Artículos de clientes].[CodArt] = [Artículos de clientes (piezas)].[CodArt] WHERE NumOrd=" + uidTextBox.Text + " AND CodPie='"+elementTextBox.Text+"'", conn);

            cmd = new OleDbCommand("Select codpie,ctdpie,diaext,diaint,longit,modpie,calpie from [Artículos de clientes (piezas)] where CodPie ='" + elementTextBox.Text + "' And CodArt = '" + articleNumberTextBox.Text + "'", conn);

            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (reader["CtdPie"].ToString() != "")
                {
                    multiplierTextBox.Text = reader["CtdPie"].ToString();
                }
                else
                {
                    multiplierTextBox.Text = "1";
                }
                //orderQunatityTextBox.Text = reader["PieOrd"].ToString();
                totalTextBox.Text = calculateTotal(multiplierTextBox.Text, orderQunatityTextBox.Text);

                gradeTextBox.Text = reader["CalPie"].ToString();
                modelTextBox.Text = reader["ModPie"].ToString();
                outerDiameterTextBox.Text = reader["DiaExt"].ToString();
                lengthTextBox.Text = reader["Longit"].ToString();
                internalDiameterTextBox.Text = reader["DiaInt"].ToString();
                //articleNumberTextBox.Text = reader["ArtOrd"].ToString();
            }
            else
            {
                gradeTextBox.Text = "";
                outerDiameterTextBox.Text = "";
                lengthTextBox.Text = "";
                internalDiameterTextBox.Text = "";
            }

            multiplierTextBox.Focus();
            multiplierTextBox.Attributes.Add("onfocusin", " select();");
            conn.Close();
        }

        public string calculateTotal(string multiplier, string orderQuantity)
        {
            return (Convert.ToInt32(multiplier) * Convert.ToInt32(orderQuantity)).ToString();
        }

        protected void Multiplier_change(object sender, EventArgs e)
        {
            TextBox elementTextBox = sender as TextBox;
            GridViewRow rows = elementTextBox.NamingContainer as GridViewRow;
            int rowIndex = rows.RowIndex;

            GridViewRow row = GridView1.Rows[rowIndex];
            TextBox multiplierTextBox = (TextBox)row.FindControl("TextBox5");
            TextBox orderQuantityTextBox = (TextBox)row.FindControl("TextBox6");
            TextBox totalTextBox = (TextBox)row.FindControl("TextBox7");

            if (multiplierTextBox.Text != "" && orderQuantityTextBox.Text!="")
            {
                totalTextBox.Text=calculateTotal(multiplierTextBox.Text, orderQuantityTextBox.Text);
            }
            else
            {
                totalTextBox.Text="";
            }
            orderQuantityTextBox.Focus();
            orderQuantityTextBox.Attributes.Add("onfocusin", " select();");
        }

        protected void OrderQuantity_change(object sender, EventArgs e)
        {
            TextBox elementTextBox = sender as TextBox;
            GridViewRow rows = elementTextBox.NamingContainer as GridViewRow;
            int rowIndex = rows.RowIndex;

            GridViewRow row = GridView1.Rows[rowIndex];
            TextBox multiplierTextBox = (TextBox)row.FindControl("TextBox5");
            TextBox orderQuantityTextBox = (TextBox)row.FindControl("TextBox6");
            TextBox totalTextBox = (TextBox)row.FindControl("TextBox7");

            if (multiplierTextBox.Text != "" && orderQuantityTextBox.Text!="")
            {
                totalTextBox.Text = calculateTotal(multiplierTextBox.Text, orderQuantityTextBox.Text);
            }
            else
            {
                totalTextBox.Text="";
            }

            totalTextBox.Focus();
            totalTextBox.Attributes.Add("onfocusin", " select();");
        }
        
        protected void submitButton_Click(object sender, EventArgs e)
        {
            string NumOfe = "";
            Boolean textFieldsFilled=true;
                        
            if (IsPostBack)
            {
                if (textFieldsFilled == true)
                {
                    if (GridView1.Rows.Count != 0)
                    {
                        try
                        {
                            OleDbConnection conn = new OleDbConnection(connectionString);
                            OleDbCommand cmd = conn.CreateCommand();
                            conn.Open();
                            cmd = new OleDbCommand("SELECT DISTINCTROW NumOfe FROM [Ofertas (cabeceras)] ORDER BY [Ofertas (cabeceras)].NumOfe DESC", conn);
                            OleDbDataReader reader = cmd.ExecuteReader();
                            if (reader.Read())
                            {
                                if (reader.FieldCount > 0)
                                {
                                    NumOfe = (Convert.ToInt32(reader["NumOfe"]) + 1).ToString();
                                    Session["PTNo"] = NumOfe;
                                }
                            }
                            conn.Close();
                        }
                        catch (Exception ex)
                        {
                            Response.Write(ex);
                        }
                        try
                        {
                            DateTime TodayDate = DateTime.Today;
                            string dt = TodayDate.ToString("yyyy-MM-dd");

                            OleDbConnection conn = new OleDbConnection(connectionString);
                            OleDbCommand cmd = conn.CreateCommand();
                            conn.Open();
                            cmd = new OleDbCommand("INSERT INTO [Ofertas (cabeceras)] (NumOfe,FecOfe) VALUES (" + NumOfe + ", '" + dt + "')", conn);
                            OleDbDataReader reader = cmd.ExecuteReader();
                            conn.Close();
                        }
                        catch (Exception ex1)
                        {
                            Response.Write(ex1);
                        }
                        try
                        {
                            foreach (GridViewRow row in GridView1.Rows)
                            {
                                if (row.RowType == DataControlRowType.DataRow)
                                {
                                    string order = NumOfe;
                                    TextBox NumOrd = row.FindControl("TextBox1") as TextBox;
                                    TextBox element = row.FindControl("TextBox4") as TextBox;
                                    TextBox total = row.FindControl("TextBox7") as TextBox;
                                    TextBox od = row.FindControl("TextBox11") as TextBox;
                                    TextBox id = row.FindControl("TextBox13") as TextBox;
                                    TextBox length = row.FindControl("TextBox12") as TextBox;
                                    OleDbConnection conn = new OleDbConnection(connectionString);
                                    OleDbCommand cmd = conn.CreateCommand();
                                    conn.Open();
                                    //cmd = new OleDbCommand("INSERT INTO [Ofertas (líneas)] (NumOfe, NumOrd, CodPie, TotPie, Dimen1, Dimen3, Dimen2) VALUES (" + order + "," + NumOrd.Text + ",'" + element.Text + "'," + total.Text + "," + od.Text + "," + id.Text + "," + length.Text+ ")", conn);
                                    cmd = new OleDbCommand("INSERT INTO [Ofertas (líneas)] (NumOfe, NumOrd, CodPie, TotPie, Dimen1, Dimen3, Dimen2) VALUES (@NumOfe,@NumOrd,@CodPie,@TotPie,@Dimen1,@Dimen2,@Dimen3)", conn);
                                    cmd.Parameters.Add("@NumOfe", OleDbType.Integer).Value = order;
                                    cmd.Parameters.Add("@NumOrd", OleDbType.Integer).Value = NumOrd.Text;
                                    cmd.Parameters.Add("@CodPie", OleDbType.VarChar).Value = element.Text;
                                    cmd.Parameters.Add("@TotPie", OleDbType.Integer).Value = total.Text;
                                    cmd.Parameters.Add("@Dimen1", OleDbType.Decimal).Value = od.Text;
                                    cmd.Parameters.Add("@Dimen2", OleDbType.Decimal).Value = id.Text;
                                    cmd.Parameters.Add("@Dimen3", OleDbType.Decimal).Value = length.Text;
                                    OleDbDataReader reader = cmd.ExecuteReader();
                                    conn.Close();
                                }
                            }
                        }
                        catch (Exception ex2)
                        {
                            Response.Write(ex2);
                        }
                        try
                        {
                            foreach (GridViewRow row in GridView1.Rows)
                            {
                                if (row.RowType == DataControlRowType.DataRow)
                                {
                                    string order = NumOfe;
                                    TextBox article = row.FindControl("TextBox14") as TextBox;
                                    TextBox element = row.FindControl("TextBox4") as TextBox;
                                    TextBox total = row.FindControl("TextBox7") as TextBox;
                                    TextBox od = row.FindControl("TextBox11") as TextBox;
                                    TextBox id = row.FindControl("TextBox13") as TextBox;
                                    TextBox length = row.FindControl("TextBox12") as TextBox;
                                    TextBox grade = row.FindControl("TextBox9") as TextBox;

                                    Session["art"] = article.Text;
                                    OleDbConnection conn = new OleDbConnection(connectionString);
                                    OleDbCommand cmd = conn.CreateCommand();
                                    cmd = new OleDbCommand("SELECT CodArt,CodPie FROM [Artículos de clientes (piezas)] WHERE CodArt = '" + article.Text + "' AND CodPie = '" + element.Text + "'", conn);
                                    conn.Open();
                                    OleDbDataReader reader = cmd.ExecuteReader();

                                    if (reader.Read())
                                    {
                                        OleDbConnection conn1 = new OleDbConnection(connectionString);
                                        OleDbCommand cmd1 = conn.CreateCommand();
                                        conn1.Open();
                                        cmd1 = new OleDbCommand("UPDATE [Artículos de clientes (piezas)] SET CalPie = @CalPie, DiaExt = @DiaExt , Longit = @Longit, DiaInt = @DiaInt WHERE CodArt = '" + article.Text + "' AND CodPie = '" + element.Text + "'", conn1);
                                        cmd1.Parameters.Add("@CalPie", OleDbType.VarChar).Value = grade.Text;
                                        cmd1.Parameters.Add("@DiaExt", OleDbType.Decimal).Value = od.Text;
                                        cmd1.Parameters.Add("@Longit", OleDbType.Decimal).Value = length.Text;
                                        cmd1.Parameters.Add("@DiaInt", OleDbType.Decimal).Value = id.Text;
                                        OleDbDataReader reader1 = cmd1.ExecuteReader();
                                        conn1.Close();
                                    }
                                    else
                                    {
                                        OleDbConnection conn2 = new OleDbConnection(connectionString);
                                        OleDbCommand cmd2 = conn.CreateCommand();
                                        conn2.Open();
                                        cmd2 = new OleDbCommand("INSERT INTO [Artículos de clientes (piezas)] (CodArt, CodPie, CalPie, ModPie, DiaExt, DiaInt, Longit,CtdPie) VALUES (@CodArt,@NumOrd,@CalPie,@CodPie,@Dimen1,@Dimen2,@Dimen3,@CtdPie)", conn2);
                                        cmd2.Parameters.Add("@CodArt", OleDbType.VarChar).Value = article.Text;
                                        cmd2.Parameters.Add("@NumOrd", OleDbType.VarChar).Value = element.Text;
                                        cmd2.Parameters.Add("@CalPie", OleDbType.VarChar).Value = grade.Text;
                                        cmd2.Parameters.Add("@CodPie", OleDbType.VarChar).Value = total.Text;
                                        cmd2.Parameters.Add("@Dimen1", OleDbType.Decimal).Value = od.Text;
                                        cmd2.Parameters.Add("@Dimen2", OleDbType.Decimal).Value = id.Text;
                                        cmd2.Parameters.Add("@Dimen3", OleDbType.Decimal).Value = length.Text;
                                        cmd2.Parameters.Add("@CtdPie", OleDbType.Integer).Value = 1;
                                        OleDbDataReader reader2 = cmd2.ExecuteReader();
                                        conn2.Close();
                                    }
                                    conn.Close();
                                }
                            }
                        }
                        catch (Exception ae)
                        {
                            Response.Write(ae);
                        }
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Carbide enquiry completed.')", true);
                        Response.Redirect("printCarbide.aspx");
                    }
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Details First.')", true);
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Determine the RowIndex of the Row whose Button was clicked.
                int rowIndex = Convert.ToInt32(e.CommandArgument);

                //Reference the GridView Row.
                GridViewRow row = GridView1.Rows[rowIndex];

                //Fetch value of Name.
                string name = (row.FindControl("TextBox1") as TextBox).Text;

                //Fetch value of Country
                //string country = row.Cells[1].Text;

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Name: " + name + "');", true);
            }
        }

        protected void removeBtn_Click(object sender, EventArgs e)
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;

                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)GridView1.Rows[rowIndex].Cells[1].FindControl("TextBox1");
                        TextBox box2 = (TextBox)GridView1.Rows[rowIndex].Cells[2].FindControl("TextBox2");
                        TextBox box3 = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("TextBox3");
                        TextBox box4 = (TextBox)GridView1.Rows[rowIndex].Cells[4].FindControl("TextBox4");
                        TextBox box5 = (TextBox)GridView1.Rows[rowIndex].Cells[5].FindControl("TextBox5");
                        TextBox box6 = (TextBox)GridView1.Rows[rowIndex].Cells[6].FindControl("TextBox6");
                        TextBox box7 = (TextBox)GridView1.Rows[rowIndex].Cells[7].FindControl("TextBox7");
                        TextBox box8 = (TextBox)GridView1.Rows[rowIndex].Cells[8].FindControl("TextBox8");
                        TextBox box9 = (TextBox)GridView1.Rows[rowIndex].Cells[9].FindControl("TextBox9");
                        TextBox box10 = (TextBox)GridView1.Rows[rowIndex].Cells[10].FindControl("TextBox10");
                        TextBox box11 = (TextBox)GridView1.Rows[rowIndex].Cells[11].FindControl("TextBox11");
                        TextBox box12 = (TextBox)GridView1.Rows[rowIndex].Cells[12].FindControl("TextBox12");
                        TextBox box13 = (TextBox)GridView1.Rows[rowIndex].Cells[13].FindControl("TextBox13");
                        TextBox box14 = (TextBox)GridView1.Rows[rowIndex].Cells[14].FindControl("TextBox14");

                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;
                        dtCurrentTable.Rows[i - 1]["UID"] = box1.Text;
                        dtCurrentTable.Rows[i - 1]["CustomerID"] = box2.Text;
                        dtCurrentTable.Rows[i - 1]["Description"] = box3.Text;
                        dtCurrentTable.Rows[i - 1]["Element"] = box4.Text;
                        dtCurrentTable.Rows[i - 1]["Multiplier"] = box5.Text;
                        dtCurrentTable.Rows[i - 1]["OrderQuantity"] = box6.Text;
                        dtCurrentTable.Rows[i - 1]["Total"] = box7.Text;
                        dtCurrentTable.Rows[i - 1]["QuantityToOrder"] = box8.Text;
                        dtCurrentTable.Rows[i - 1]["Grade"] = box9.Text;
                        dtCurrentTable.Rows[i - 1]["Model"] = box10.Text;
                        dtCurrentTable.Rows[i - 1]["OuterDiameter"] = box11.Text;
                        dtCurrentTable.Rows[i - 1]["Length"] = box12.Text;
                        dtCurrentTable.Rows[i - 1]["InternalDiameter"] = box13.Text;
                        dtCurrentTable.Rows[i - 1]["ArticleNumber"] = box14.Text;

                        rowIndex++;
                    }

                    //dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;
                    GridView1.DataSource = dtCurrentTable;
                    GridView1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            
            Button lb = (Button)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                dt.Rows.Remove(dt.Rows[rowID]);

                //Store the current data in ViewState for future reference  
                ViewState["CurrentTable"] = dt;

                //Re bind the GridView for the updated data  
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            //Set Previous Data on Postbacks  
            //totalRowsCount.Text = GridView1.Rows.Count.ToString();
            SetPreviousData();
        }  
    }
}